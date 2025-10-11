using Microsoft.AspNetCore.Mvc;
using Nomina.Application.Services;

namespace Nomina.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrabajadoresController : ControllerBase
    {
        private readonly TrabajadorService _service;

        public TrabajadoresController(TrabajadorService service)
        {
            _service = service;
        }

        [HttpGet("activos")]
        public async Task<IActionResult> GetActivos()
        {
            var trabajadores = await _service.ListarActivosAsync();
            return Ok(trabajadores);
        }
    }
}
