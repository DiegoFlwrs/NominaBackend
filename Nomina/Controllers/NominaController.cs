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
             var nominas = await _service.ProcesarNominaAsync(request);
            return Ok(nominas);
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
    }
}
