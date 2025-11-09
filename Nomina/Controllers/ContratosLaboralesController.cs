using Microsoft.AspNetCore.Mvc;
using Nomina.Application.DTOs;
using Nomina.Application.Interfaces;
using Nomina.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Nomina.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContratoLaboralController : ControllerBase
    {
        private readonly IContratoLaboralService _contratoService;

        public ContratoLaboralController(IContratoLaboralService contratoService)
        {
            _contratoService = contratoService;
        }
        [HttpGet("Mostrar")]
        public async Task<IActionResult> GetContratos()
        {
            var contratos = await _contratoService.ConsultarContratos();
            return Ok(contratos);
        }
        [HttpPost("Registrar")]
        public async Task<IActionResult> PostContrato([FromBody] ContratoLaboralDTO dto)
        {
            if (dto == null)
                return BadRequest("Los datos del contrato son obligatorios.");

            try
            {
                await _contratoService.RegistrarContrato(dto);
                return Ok("Contrato registrado correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpPut("Actualizar")]
        public async Task<IActionResult> PutContrato(string contratoCodigo, [FromBody] ContratoLaboralDTO dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(contratoCodigo))
                return BadRequest("Datos inválidos.");

            try
            {
                dto.ContratoCodigo = contratoCodigo;
                await _contratoService.ModificarContrato(dto);
                return Ok("Contrato modificado correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpDelete("Eliminar")]
        public async Task<IActionResult> DeleteContrato(string contratoCodigo)
        {
            if (string.IsNullOrWhiteSpace(contratoCodigo))
                return BadRequest("Código de contrato inválido.");

            try
            {
                await _contratoService.EliminarContrato(contratoCodigo);
                return Ok("Contrato eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpGet("TipoContrato")]
        public async Task<IActionResult> ListadoPorTipo()
        {
            var data = await _contratoService.ListarContratosPorTipo();
            return Ok(data);
        }

        [HttpGet("Modalidad")]
        public async Task<IActionResult> ListadoPorModalidad()
        {
            var data = await _contratoService.ListarContratosPorModalidad();
            return Ok(data);
        }

        [HttpGet("Jornada")]
        public async Task<IActionResult> ListadoPorJornada()
        {
            var data = await _contratoService.ListarContratosPorJornada();
            return Ok(data);
        }

        [HttpGet("Estado")]
        public async Task<IActionResult> ListadoPorEstado()
        {
            var data = await _contratoService.ListarContratosPorEstado();
            return Ok(data);
        }
        [HttpGet("DetallesHistorial")]
        public async Task<IActionResult> GetHistorialDetalles()
        {
            var result = await _contratoService.ListarHistorialDetalles();
            return Ok(result);
        }
        [HttpGet("EmpleadoCodigo")]
        public async Task<IActionResult> GetEmpleadosCodigo()
        {
            var result = await _contratoService.ListarEmpleadosCodigo();
            return Ok(result);
        }
        [HttpPut("cambiar-estado")]
        public async Task<IActionResult> CambiarEstadoContrato(string codigo, [FromQuery] string nuevoEstado, [FromQuery] string motivo)
        {
            if (string.IsNullOrWhiteSpace(motivo))
                return BadRequest("Debe ingresar un motivo para este cambio de estado.");

            await _contratoService.SuspenderContrato(codigo, nuevoEstado, motivo);
            return Ok(new { mensaje = $"Contrato {codigo} actualizado a estado {nuevoEstado}" });
        }
    }
}