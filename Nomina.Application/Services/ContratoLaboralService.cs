using Nomina.Application.DTOs;
using Nomina.Application.Interfaces;
using Nomina.Domain.Entities;
using Nomina.Domain.Interfaces;
using Nomina.Domain.Constants;
using Nomina.API.Exceptions;
namespace Nomina.Application.Services
{
    public class ContratoLaboralService : IContratoLaboralService
    {
        private readonly IContratoLaboralRepository _contratoRepository;

        public ContratoLaboralService(IContratoLaboralRepository contratoRepository)
        {
            _contratoRepository = contratoRepository;
        }

        public async Task<IEnumerable<ContratoLaboralDTO>> ConsultarContratos()
        {
            var contratos = await _contratoRepository.ConsultarContratos();
            return contratos.Select(c => new ContratoLaboralDTO
            {
                ContratoCodigo = Guid.NewGuid().ToString(),
                EmpleadoCodigo = c.EmpleadoCodigo,
                TipoContratoCodigo = c.TipoContratoCodigo,
                ModalidadCodigo = c.ModalidadCodigo,
                JornadaCodigo = c.JornadaCodigo,
                UsuarioCodigo = c.UsuarioCodigo,
                ContratoFechaInicio = c.ContratoFechaInicio,
                ContratoFechaFin = c.ContratoFechaFin,
                ContratoSalario = c.ContratoSalario,
                ContratoBonificacion = c.ContratoBonificacion,
                ContratoDescuento = c.ContratoDescuento,
                ContratoEstado = c.ContratoEstado
            });
        }

        public async Task RegistrarContrato(ContratoLaboralDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.EmpleadoCodigo) ||
                string.IsNullOrWhiteSpace(dto.TipoContratoCodigo) ||
                dto.ContratoSalario <= 0)
                throw new BusinessException("Campos obligatorios faltantes o inválidos.");
            if (dto.ContratoFechaInicio < DateTime.Today)
                throw new BusinessException("La fecha de inicio no puede ser anterior a la actual.");
            if (dto.ContratoSalario < ValidacionesContrato.SALARIO_MINIMO)
                throw new BusinessException($"El salario no puede ser menor al mínimo legal ({ValidacionesContrato.SALARIO_MINIMO}).");
            bool empleadoExiste = await _contratoRepository.ExisteEmpleadoActivo(dto.EmpleadoCodigo);
            if (!empleadoExiste)
                throw new NotFoundException("El empleado no existe o ha sido eliminado del sistema.");


            bool existeVigente = await _contratoRepository.ExisteContratoVigente(dto.EmpleadoCodigo);
            if (existeVigente)
                throw new BusinessException("Exitoso");
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

            await _contratoRepository.InsertarContrato(contrato);
        }
        public async Task ModificarContrato(ContratoLaboralDTO dto)
        {
            var contrato = await _contratoRepository.ObtenerContrato(dto.ContratoCodigo);
            if (contrato == null)
                throw new NotFoundException("Contrato no encontrado.");

            if (dto.ContratoSalario < ValidacionesContrato.SALARIO_MINIMO)
                throw new BusinessException("El salario no puede ser menor al mínimo legal.");

            // Actualizar solo los campos editables
            contrato.ContratoFechaInicio = dto.ContratoFechaInicio;
            contrato.ContratoFechaFin = dto.ContratoFechaFin;
            contrato.ContratoSalario = dto.ContratoSalario;
            contrato.ContratoBonificacion = dto.ContratoBonificacion;
            contrato.ContratoDescuento = dto.ContratoDescuento;
            contrato.ContratoEstado = dto.ContratoEstado;
            contrato.JornadaCodigo = dto.JornadaCodigo;

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
    }
}