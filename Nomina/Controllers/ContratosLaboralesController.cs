using Microsoft.AspNetCore.Mvc;
using Nomina.Application.DTOs;
using Nomina.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace Nomina.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContratoLaboralController : ControllerBase
    {
        private readonly IContratoLaboralService _contratoService;

        public ContratoLaboralController(IContratoLaboralService contratoService)
        {
            _contratoService = contratoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetContratos()
        {
            var contratos = await _contratoService.ConsultarContratos();
            return Ok(contratos);
        }
        [HttpPost]
        public async Task<IActionResult> PostContrato([FromBody] ContratoLaboralDTO dto)
        {
            if (dto == null)
                return BadRequest("Los datos del contrato son obligatorios.");

            try
            {
                await _contratoService.RegistrarContrato(dto);
                return Ok(new { message = "Contrato registrado correctamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpPut("{contratoCodigo}")]
        public async Task<IActionResult> PutContrato(string contratoCodigo, [FromBody] ContratoLaboralDTO dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(contratoCodigo))
                return BadRequest("Datos inválidos.");

            try
            {
                dto.ContratoCodigo = contratoCodigo;
                await _contratoService.ModificarContrato(dto);
                return Ok(new { message = "Contrato modificado correctamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpDelete("{contratoCodigo}")]
        public async Task<IActionResult> DeleteContrato(string contratoCodigo)
        {
            if (string.IsNullOrWhiteSpace(contratoCodigo))
                return BadRequest("Código de contrato inválido.");

            try
            {
                await _contratoService.EliminarContrato(contratoCodigo);
                return Ok(new { message = "Contrato eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}