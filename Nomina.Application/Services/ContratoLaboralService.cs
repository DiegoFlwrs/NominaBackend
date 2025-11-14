using Nomina.Application.DTOs;
using Nomina.Application.Interfaces;
using Nomina.Domain.Entities;
using Nomina.Domain.Interfaces;
using Nomina.Domain.Rules;
using Nomina.API.Exceptions;
using Nomina.Domain.Constants;
using Nomina.Application.DTOs.NominaPeriodo;
using Nomina.Domain.ReadModels;

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

        public async Task RegistrarContrato(ContratoLaboralDTO dto)
        {
            var contrato = new ContratoLaboral
            {
                ContratoCodigo = dto.ContratoCodigo,
                EmpleadoCodigo = dto.EmpleadoCodigo,
                TipoContratoCodigo = dto.TipoContratoCodigo,
                ModalidadCodigo = dto.ModalidadCodigo,
                JornadaCodigo = dto.JornadaCodigo,
                UsuarioCodigo = dto.UsuarioCodigo,
                ContratoFechaInicio = dto.ContratoFechaInicio,
                ContratoFechaFin = dto.ContratoFechaFin,
                ContratoSalario = dto.ContratoSalario,
                ContratoBonificacion = dto.ContratoBonificacion,
                ContratoDescuento = dto.ContratoDescuento,
                ContratoEstado = "A"
            };
            ContratoLaboralRules.ValidarCoherenciaGeneral(contrato);
            var existeEmpleado = await _contratoRepository.ExisteEmpleadoActivo(dto.EmpleadoCodigo);
            if (!existeEmpleado)
                throw new NotFoundException("El empleado no existe o está inactivo.");

            var vigente = await _contratoRepository.ExisteContratoVigente(dto.EmpleadoCodigo);
            ContratoLaboralRules.ValidarContratoDuplicado(vigente);

            await _contratoRepository.InsertarContrato(contrato);
        }

        public async Task ModificarContrato(ContratoLaboralDTO dto)
        {
            var contrato = await _contratoRepository.ObtenerContrato(dto.ContratoCodigo);
            if (contrato == null)
                throw new NotFoundException("Contrato no encontrado.");

            ContratoLaboralRules.ValidarEdicionPorEstado(contrato.ContratoEstado);
            ContratoLaboralRules.ValidarSalarioMinimo(dto.ContratoSalario, ValidacionesContrato.SALARIO_MINIMO);

            contrato.TipoContratoCodigo = dto.TipoContratoCodigo;
            contrato.ModalidadCodigo = dto.ModalidadCodigo;
            contrato.JornadaCodigo = dto.JornadaCodigo;
            contrato.UsuarioCodigo = dto.UsuarioCodigo;
            contrato.ContratoFechaInicio = dto.ContratoFechaInicio;
            contrato.ContratoFechaFin = dto.ContratoFechaFin;
            contrato.ContratoSalario = dto.ContratoSalario;
            contrato.ContratoBonificacion = dto.ContratoBonificacion;
            contrato.ContratoDescuento = dto.ContratoDescuento;

            await _contratoRepository.ModificarContrato(contrato);
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
            => await _contratoRepository.ListarContratosPorEstado();

        public async Task RegistrarHistorial(HistorialContrato historial)
        {
            await _contratoRepository.RegistrarHistorial(historial);
        }
        public async Task<IEnumerable<HistorialDetalle>> ListarHistorialDetalles()
        {
            return await _contratoRepository.ListarHistorialDetalles();
        }
        public async Task<IEnumerable<ResumenEmpleado>> ListarEmpleadosCodigo()
        {
            return await _contratoRepository.ListarEmpleadosCodigo();
        }
        public async Task SuspenderContrato(string contratoCodigo, string nuevoEstado, string motivo)
        {
            await _contratoRepository.SuspenderContrato(contratoCodigo, nuevoEstado, motivo);
        }


    }
}
