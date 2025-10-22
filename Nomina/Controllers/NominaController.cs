using Microsoft.AspNetCore.Mvc;
using Nomina.Application.DTOs;
using Nomina.Application.DTOs.NominaPeriodo;
using Nomina.Application.interfaces;
using Nomina.Application.Services;

namespace Nomina.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NominaController : ControllerBase
    {
        private readonly INominaService _service;

        public NominaController(INominaService service)
        {
            _service = service;
        }

        [HttpPost("procesar")]
        public async Task<IActionResult> ProcesarNomina([FromBody] NominaFiltroRequest request)
        {
            var (nominas, totalRows) = await _service.ProcesarNominaAsync(request);

            var response = new
            {
                data = nominas,
                totalRows
            };

            return Ok(response);
        }

        [HttpGet("periodo/anios")]
        public async Task<IActionResult> ListarAnios()
        {
            var anios = await _service.ObtenerAniosAsync();
            return Ok(anios);
        }

        [HttpGet("periodo/meses")]
        public async Task<IActionResult> ListarMeses()
        {
            var meses = await _service.ObtenerMesesAsync();
            return Ok(meses);
        }

        [HttpGet("departamentos")]
        public async Task<IActionResult> ListarDepartamentos()
        {
            var departamentos = await _service.ObtenerDepartamentosAsync();
            return Ok(departamentos);
        }
    }
}
