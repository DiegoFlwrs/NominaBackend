using Nomina.Application.DTOs;
using Nomina.Application.Interfaces;
using Nomina.Domain.Entities;
using Nomina.Domain.Interfaces;
using Nomina.Domain.Rules;
using Nomina.API.Exceptions;
using Nomina.Domain.Constants;
using Nomina.Application.DTOs.NominaPeriodo;
using Nomina.Domain.ReadModels;
using Nomina.Application.Helpers;

namespace Nomina.Application.Services
{
    public class ContratoLaboralService : IContratoLaboralService
    {
        private readonly IContratoLaboralRepository _contratoRepository;

        public ContratoLaboralService(IContratoLaboralRepository contratoRepository)
        {
            _contratoRepository = contratoRepository;
        }

        public async Task<IEnumerable<ContratoView>> ConsultarContratos()
        {
            var contrato = await _contratoRepository.ConsultarContratosAsync();
            return contrato;
        }

        public async Task<string> RegistrarContrato(RegistroContratoDto dto)
        {
            var contrato = new ContratoLaboral
            {
                EmpleadoCodigo = dto.EmpleadoCodigo,
                TipoContratoCodigo = dto.TipoContratoCodigo,
                ModalidadCodigo = dto.ModalidadCodigo,
                JornadaCodigo = dto.JornadaCodigo,
                UsuarioCodigo = dto.UsuarioCodigo,
                ContratoFechaInicio = dto.ContratoFechaInicio,
                ContratoFechaFin = dto.ContratoFechaFin,
                ContratoSalario = dto.ContratoSalario,
                ContratoEstado = "A"
            };
            ContratoLaboralRules.ValidarCoherenciaGeneral(contrato);
            ContratoLaboralRules.ValidarFechaInicio(contrato);
            ContratoLaboralRules.ValidarSalarioMinimo(dto.ContratoSalario, ValidacionesContrato.SALARIO_MINIMO);
            var existeEmpleado = await _contratoRepository.ExisteEmpleadoActivo(dto.EmpleadoCodigo);
            if (!existeEmpleado)
                throw new NotFoundException("El empleado no existe o está inactivo.");

            var vigente = await _contratoRepository.ExisteContratoVigente(dto.EmpleadoCodigo);
            ContratoLaboralRules.ValidarContratoDuplicado(vigente);
            await _contratoRepository.InsertarContrato(contrato);
            return "Contrato registrado exitosamente.";
        }

        public async Task ModificarContrato(ContratoLaboralDto dto)
        {
            var contrato = await _contratoRepository.ObtenerContrato(dto.ContratoCodigo);
            if (contrato == null)
                throw new NotFoundException("Contrato no encontrado.");

            ContratoLaboralRules.ValidarEdicionPorEstado(contrato.ContratoEstado);

            contrato.TipoContratoCodigo = dto.TipoContratoCodigo;
            contrato.ModalidadCodigo = dto.ModalidadCodigo;
            contrato.JornadaCodigo = dto.JornadaCodigo;
            contrato.UsuarioCodigo = dto.UsuarioCodigo;
            contrato.ContratoFechaInicio = dto.ContratoFechaInicio;
            contrato.ContratoFechaFin = dto.ContratoFechaFin;
            contrato.ContratoSalario = dto.ContratoSalario;
            ContratoLaboralRules.ValidarSalarioMinimo(dto.ContratoSalario, ValidacionesContrato.SALARIO_MINIMO);
            ContratoLaboralRules.ValidarCoherenciaGeneral(contrato);
            await _contratoRepository.ModificarContrato(contrato, dto.Motivo);
        }

        public async Task EliminarContrato(string contratoCodigo)
        {
            await _contratoRepository.EliminarContrato(contratoCodigo);
        }

        public async Task<ContratoLaboral> ObtenerContrato(string codigo)
        {
            var contrato = await _contratoRepository.ObtenerContrato(codigo);
            if (contrato == null)
                throw new NotFoundException("Contrato no encontrado.");
            return contrato;
        }
        public async Task<IEnumerable<ContratoResumen>> ListarContratosPorTipo()
            => await _contratoRepository.ListarContratosPorTipo();

        public async Task<IEnumerable<ContratoResumen>> ListarContratosPorModalidad()
            => await _contratoRepository.ListarContratosPorModalidad();

        public async Task<IEnumerable<ContratoResumen>> ListarContratosPorJornada()
            => await _contratoRepository.ListarContratosPorJornada();

        public async Task<IEnumerable<ContratoResumen>> ListarContratosPorEstado()
        {
            var contratos = await _contratoRepository.ListarContratosPorEstado();

            return contratos.Select(c => new ContratoResumen
            {
                Codigo = c.Codigo,
                Descripcion = Helper.ObtenerDescripcionEstado(c.Descripcion) 
            });
        }

        public async Task RegistrarHistorial(HistorialContrato historial)
        {
            await _contratoRepository.RegistrarHistorial(historial);
        }
        public async Task<IEnumerable<HistorialDetalle>> ListarHistorialDetalles()
        {
            return await _contratoRepository.ListarHistorialDetalles();
        }
        public async Task SuspenderContrato(string contratoCodigo, string nuevoEstado, string motivo)
        {
            await _contratoRepository.SuspenderContrato(contratoCodigo, nuevoEstado, motivo);
        }
         public async Task<IEnumerable<object>> ListarEmpleadosSinContrato()
        {
            return await _contratoRepository.ListarEmpleadosSinContrato();
        }
    }
}
