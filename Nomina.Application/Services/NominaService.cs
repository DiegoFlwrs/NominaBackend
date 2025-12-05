using Nomina.API.Exceptions;
using Nomina.Application.DTOs;
using Nomina.Application.DTOs.NominaPeriodo;
using Nomina.Application.Helpers;
using Nomina.Application.interfaces;
using Nomina.Domain.Entities;
using Nomina.Domain.Interfaces;
using Nomina.Domain.ReadModels;
using Nomina.Domain.rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Application.Services
{
    public class NominaService : INominaService
    {
        private readonly INominaRepository _repository;
        public Helper helper = new Helper();

        public NominaService(INominaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<NominaView>> ProcesarNominaAsync(NominaFiltroRequest request)
        {
            return await _repository.ConsultarNominasAsync(request.CodigoPeriodo);
        }

        public async Task<IEnumerable<int>> ObtenerAniosAsync()
        {
            var periodos = await _repository.ObtenerPeriodosAsync();
            var aniosDistintos = periodos
                .Select(p => p.PeriodoAnio)
                .Distinct()
                .OrderByDescending(a => a)
                .ToList();

            return aniosDistintos;
        }

        public async Task<IEnumerable<int>> ObtenerMesesAsync()
        {
            var periodos = await _repository.ObtenerPeriodosAsync();
            var mesesDistintos = periodos
                .Select(p => p.PeriodoMes)
                .Distinct()
                .OrderByDescending(m => m)
                .ToList();

            return mesesDistintos;
        }

        public async Task<IEnumerable<DepartamentoDTO>> ObtenerDepartamentosAsync()
        {
            var departamentos = await _repository.ObtenerDepartamentosAsync();

            var resultado = departamentos.Select(t => new DepartamentoDTO
            {
                DepartamentoCodigo = t.DepartamentoCodigo,
                DepartamentoNombre = t.DepartamentoNombre
            });

            return resultado;
        }

        public async Task<IEnumerable<PeriodoDTO>> ObtenerPeriodoAsync()
        {
            var periodos = await _repository.ObtenerPeriodosAsync();

            var resultado = periodos.Select(t => new PeriodoDTO
            {
                PeriodoCodigo = t.PeriodoCodigo.Trim(),
                PeriodoDescripcion = t.PeriodoAnio + " - " + helper.ObtenerNombreMes(t.PeriodoMes) + " (" + helper.ObtenerNombreEstado(t.PeriodoEstado) + ") ",
                PeriodoEstado = t.PeriodoEstado
            });

            return resultado;
        }

        public async Task<IEnumerable<ContratoDTO>> ObtenerContratoAsync()
        {
            var contratos = await _repository.ObtenerContratoAsync();

            var resultado = contratos.Select(t => new ContratoDTO
            {
                ContratoCodigo = t.ContratoCodigo.Trim(),
                EmpleadoDescripcion = t.ContratoCodigo.Trim() + " - " + t.Empleado.EmpleadoNombre + " " + t.Empleado.EmpleadoApellido
            });

            return resultado;
        }


        public async Task CrearNominaAsync(NominaRequest request)
        {
            //VALIDACION DE PERIODOS
            var periodos = await _repository.ObtenerPeriodosAsync();
            var periodo = periodos.FirstOrDefault(p => p.PeriodoCodigo.Trim() == request.PeriodoCodigo);
            var hoy = DateTime.Now.Date;

            if (periodo == null)
                throw new BusinessException("El periodo especificado no existe.");

            if (periodo.PeriodoEstado == "P")
                throw new BusinessException("El periodo ya está procesado.");

            if (periodo.PeriodoEstado == "I")
            {
                throw new BusinessException("El periodo aun no se puede procesar.");
            }

            //OBTENGO PARAMETROS DEL SISTEMA

            var parametrosSistema = await _repository.ObtenerParametrosSistemaAsync();
            if (parametrosSistema == null)
                throw new BusinessException("No se encontraron los parámetros del sistema.");

            decimal RMV = parametrosSistema.FirstOrDefault(p => p.ParametroCodigo == "RMV25")?.ParametroValor ?? 0m;
            decimal UIT = parametrosSistema.FirstOrDefault(p => p.ParametroCodigo == "UIT25")?.ParametroValor ?? 0m;

            if (RMV <= 0 || UIT <= 0)
            {
                throw new BusinessException("Los parámetros RMV25 o UIT25 no están configurados correctamente.");
            }

            var contratos = await _repository.ObtenerContratoAsync();

            //TRAER CONTRATOS ACTIVOS Y VIGENTES

            var contratosVigentes = contratos.Where(c =>
                c.ContratoEstado.Trim() == "A" &&
                c.ContratoFechaInicio.HasValue &&
                c.ContratoFechaFin.HasValue &&
                c.ContratoFechaInicio.Value <= hoy &&
                c.ContratoFechaFin.Value >= hoy
            ).ToList();

            if (!contratosVigentes.Any())
            {
                throw new BusinessException("No se encontraron contratos vigentes para generar la nómina.");
            }

            var nominasGeneradas = new List<nuevaNominadto>(); 

            foreach (var contrato in contratosVigentes)
            {
                var empleado = contrato.Empleado;

                //RN01  -   obtener sueldo basico segun su contrato

                //RN02  -   Asginacion Familiar
                decimal asignacionFamiliar = ReglasNomina.CalcularAsignacionFamiliar(empleado.EmpleadoTieneHijos ?? false, RMV);

                var conceptos = await _repository.ObtenerConceptosPorContratoYPeriodoAsync(
                    contrato.ContratoCodigo, request.PeriodoCodigo);

                int horasExtras = conceptos
                    .Where(c => c.TipoConcepto == "HorasExtras")
                    .Sum(c => c.HorasExtras ?? 0);

                // RN03 -   Calculo Horas extras
                decimal pagoHorasExtras = ReglasNomina.CalcularPagoHorasExtras(
                    contrato.ContratoSalario, horasExtras);

                // RN04 -   Bonificacion por pagos Adicionales
                decimal bonificaciones = conceptos
                    .Where(c => c.TipoConcepto == "Bonificacion")
                    .Sum(c => c.Monto ?? 0);

                // RN05 -   Calcular Sueldo
                decimal totalIngresos = ReglasNomina.CalcularSueldoBruto(contrato.ContratoSalario, asignacionFamiliar, pagoHorasExtras, bonificaciones);

                // RN06 -   Calcular AFP
                decimal descuentoEssalud = ReglasNomina.CalcularEssalud(totalIngresos);

                // RN07 -   Descuento de pensiones

                decimal porcetajePension = parametrosSistema.FirstOrDefault(p => p.ParametroCodigo == empleado.EmpleadoAFP)?.ParametroValor ?? 0m;

                decimal descuentoPension = ReglasNomina.CalcularDescuentoPension(empleado.EmpleadoTipoPension ?? "", totalIngresos, (porcetajePension/100));

                // RN08 -   Descuento renta quinta
                decimal rentaQuinta = ReglasNomina.CalcularRentaQuinta(totalIngresos * 12, UIT);

                // RN09 -   Descuento Adicionales
                decimal descuentosAdicionales = conceptos
                    .Where(c => c.TipoConcepto == "Descuento")
                    .Sum(c => c.Monto ?? 0);

                // RN10 -   Descuento Adicionales
                decimal totalDescuentos = ReglasNomina.CalcularTotalDescuentosAdicionales(descuentoEssalud, descuentoPension, rentaQuinta, descuentosAdicionales);

                //decimal totalDescuentos = descuentoPension + rentaQuinta + otrosDescuentos;

                // RN11 -   calcualr Sueldo Neto
                decimal sueldoNeto = ReglasNomina.CalcularSueldoNeto(totalIngresos, totalDescuentos);

                //  RN12    -   
                if (!ReglasNomina.ValidarSueldoMinimo(sueldoNeto, RMV))
                {
                    throw new BusinessException(
                        $"El sueldo neto de {empleado.EmpleadoNombre} es menor a la remuneración mínima vital vigente.");
                }

                nominasGeneradas.Add(new nuevaNominadto
                {
                    ContratoCodigo = contrato.ContratoCodigo,
                    PeriodoCodigo = request.PeriodoCodigo,
                    nominaHorasExtras = horasExtras,
                    nominaMontoHorasExtras = pagoHorasExtras,
                    Bonificaciones = bonificaciones,
                    nominaAsignacionFamiliar = asignacionFamiliar,
                    nominaDescuentoPension = descuentoPension,
                    nominaDescuentoIR5ta= rentaQuinta,
                    nominaAporteEssalud= descuentoEssalud,
                    nominaOtrosDescuentos= descuentosAdicionales,
                    TotalIngresos = totalIngresos,
                    TotalDescuentos = totalDescuentos,
                    SueldoNeto = sueldoNeto
                });
            }

            var ultimoCodigo = await _repository.ObtenerUltimoCodigoNominaAsync();
            int numero = string.IsNullOrEmpty(ultimoCodigo) ? 0 : int.Parse(ultimoCodigo.Substring(3));

            foreach (var nomina in nominasGeneradas)
            {
                numero++;
                string nuevoCodigo = $"NOM{numero.ToString("D3")}";

                await _repository.InsertarNominaAsync(
                    nominaCodigo: nuevoCodigo,
                    periodoCodigo: nomina.PeriodoCodigo,
                    contratoCodigo: nomina.ContratoCodigo,
                    nominaHorasExtras: nomina.nominaHorasExtras,
                    nominaMontoHorasExtras: nomina.nominaMontoHorasExtras,
                    nominaBonificacion: nomina.Bonificaciones,
                    nominaAsignacionFamiliar: nomina.nominaAsignacionFamiliar,
                    nominaDescuentoPension: nomina.nominaDescuentoPension,
                    nominaDescuentoIR5ta: nomina.nominaDescuentoIR5ta,
                    nominaAporteEssalud: nomina.nominaAporteEssalud,
                    nominaOtrosDescuentos: nomina.nominaOtrosDescuentos,
                    nominaTotalIngresos: nomina.TotalIngresos,
                    nominaTotalDescuentos: nomina.TotalDescuentos,
                    nominaSueldoNeto: nomina.SueldoNeto
                );
            }

            periodo.PeriodoEstado = "P";
            await _repository.ActualizarPeriodoAsync(periodo);

            await _repository.SaveChangesAsync();

        }

    }
}

