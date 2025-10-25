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

        public async Task<(IEnumerable<NominaView> Nominas, int TotalRows)> ProcesarNominaAsync(NominaFiltroRequest request)
        {
            if (request.PageSize <= 0) request.PageSize = 10;
            if (request.PageNumber <= 0) request.PageNumber = 1;

            var (nominas, totalRows) = await _repository.ConsultarNominasAsync(
                request.PeriodoAnio,
                request.PeriodoMes,
                request.NominaEstado,
                request.EmpleadoNombre,
                request.EmpleadoApellido,
                request.DepartamentoCodigo,
                request.PageNumber,
                request.PageSize
            );

            return (nominas, totalRows);
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
                PeriodoDescripcion = t.PeriodoAnio + " - " + helper.ObtenerNombreMes(t.PeriodoMes)
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
            var contratoEmpleado = await _repository.ObtenerContratoConEmpleadoAsync(request.ContratoCodigo);
            if (contratoEmpleado == null)
                throw new BusinessException("Empleado no encontrado o contrato inválido.");

            var empleado = contratoEmpleado.Empleado;

            const decimal RMV = 1025m;
            const decimal UIT = 5200m; 

            decimal asignacionFamiliar = ReglasNomina.CalcularAsignacionFamiliar(empleado.EmpleadoTieneHijos ?? false, RMV);

            decimal pagoHorasExtras = ReglasNomina.CalcularPagoHorasExtras(
                contratoEmpleado.ContratoSalario,
                request.NominaHorasExtras
            );

            decimal totalIngresos = ReglasNomina.CalcularTotalIngresos(
                contratoEmpleado.ContratoSalario,
                asignacionFamiliar,
                pagoHorasExtras,
                request.NominaBonificacion
            );

            decimal aporteEssalud = ReglasNomina.CalcularEssalud(totalIngresos);

            decimal descuentoPension = ReglasNomina.CalcularDescuentoPension(
                empleado.EmpleadoTipoPension ?? "",
                totalIngresos,
                empleado.EmpleadoAFP
            );

            decimal rentaQuinta = ReglasNomina.CalcularRentaQuinta(totalIngresos * 12, UIT);

            decimal otrosDescuentos = ReglasNomina.CalcularTotalDescuentosAdicionales(
                request.NominaDescuentos
            );

            decimal totalDescuentos = descuentoPension + rentaQuinta + otrosDescuentos;

            decimal sueldoNeto = ReglasNomina.CalcularSueldoNeto(totalIngresos, totalDescuentos);

            if (!ReglasNomina.ValidarSueldoMinimo(sueldoNeto, RMV))
                throw new BusinessException("El sueldo neto no puede ser menor a la RMV vigente.");

            await _repository.InsertarNominaAsync(
                request.NominaCodigo,
                request.PeriodoCodigo,
                request.ContratoCodigo,
                request.NominaHorasExtras,
                request.NominaBonificacion,
                totalDescuentos,
                totalIngresos,
                totalDescuentos,
                sueldoNeto
            );
        }

        public async Task ActualizarNominaAsync(NominaRequest request)
        {
            var contratoEmpleado = await _repository.ObtenerContratoConEmpleadoAsync(request.ContratoCodigo);
            if (contratoEmpleado == null)
                throw new BusinessException("Empleado no encontrado o contrato inválido.");

            var empleado = contratoEmpleado.Empleado;

            const decimal RMV = 1025m; 
            const decimal UIT = 5200m; 

            decimal asignacionFamiliar = ReglasNomina.CalcularAsignacionFamiliar(empleado.EmpleadoTieneHijos ?? false, RMV);

            decimal pagoHorasExtras = ReglasNomina.CalcularPagoHorasExtras(
                contratoEmpleado.ContratoSalario,
                request.NominaHorasExtras
            );

            decimal totalIngresos = ReglasNomina.CalcularTotalIngresos(
                contratoEmpleado.ContratoSalario,
                asignacionFamiliar,
                pagoHorasExtras,
                request.NominaBonificacion
            );

            decimal aporteEssalud = ReglasNomina.CalcularEssalud(totalIngresos);

            decimal descuentoPension = ReglasNomina.CalcularDescuentoPension(
                empleado.EmpleadoTipoPension ?? "",
                totalIngresos,
                empleado.EmpleadoAFP
            );

            decimal rentaQuinta = ReglasNomina.CalcularRentaQuinta(totalIngresos * 12, UIT);

            decimal otrosDescuentos = ReglasNomina.CalcularTotalDescuentosAdicionales(
                request.NominaDescuentos
            );

            decimal totalDescuentos = descuentoPension + rentaQuinta + otrosDescuentos;

            decimal sueldoNeto = ReglasNomina.CalcularSueldoNeto(totalIngresos, totalDescuentos);

            if (!ReglasNomina.ValidarSueldoMinimo(sueldoNeto, RMV))
                throw new BusinessException("El sueldo neto no puede ser menor a la RMV vigente.");

            await _repository.ActualizarNominaAsync(
                request.NominaCodigo,
                request.NominaHorasExtras,
                request.NominaBonificacion,
                request.NominaDescuentos,
                totalIngresos,
                totalDescuentos,
                sueldoNeto
            );
        }

    }
}
