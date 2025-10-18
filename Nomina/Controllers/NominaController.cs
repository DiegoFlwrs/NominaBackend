using Microsoft.AspNetCore.Mvc;
using Nomina.Application.DTOs;
using Nomina.Application.Services;

namespace Nomina.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NominaController : ControllerBase
    {
        private readonly NominaService _service;

        public NominaController(NominaService service)
        {
            _service = service;
        }

        [HttpPost("procesar")]
        public async Task<IActionResult> ProcesarNomina([FromBody] ProcesarNominaRequest request)
        {
            await _service.ProcesarNominaAsync(request);
            return Created(string.Empty,new { message = "Nómina procesada correctamente." });
        }
    }
}
