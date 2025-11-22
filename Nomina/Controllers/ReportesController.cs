using Microsoft.AspNetCore.Mvc;
using Nomina.Application.interfaces;
using Nomina.Domain.ReadModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Nomina.Application.DTOs;

[Route("api/[controller]")]
[ApiController]
public class ReportesController : ControllerBase
{
    private readonly IReporteNominaService _reporteService;

    public ReportesController(IReporteNominaService reporteService)
    {
        _reporteService = reporteService;
    }

    [HttpGet("nomina")]
    [ProducesResponseType(typeof(List<ReporteNominaView>), 200)]
    public async Task<IActionResult> GenerarReporteNomina(
        [FromQuery] string? PeriodoCodigo,
        [FromQuery] string? departamentoCodigo,
        [FromQuery] string? cargoCodigo,
        [FromQuery] string? tipoContratoCodigo)
    {
        try
        {
            var reporte = await _reporteService.GenerarReporteAsync(
                PeriodoCodigo,
                departamentoCodigo,
                cargoCodigo,
                tipoContratoCodigo
            );

            return Ok(reporte);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { success = false, message = $"Error al obtener el reporte: {ex.Message}" });
        }
    }

    [HttpPost("nomina/pdf")]
    [ProducesResponseType(typeof(FileResult), 200)]
    public async Task<IActionResult> GenerarReporteNominaPdf(
        [FromBody] ReporteNominaRequest request)
    {
        var PeriodoCodigo = request.PeriodoCodigo;
        var departamentoCodigo = request.DepartamentoCodigo;
        var cargoCodigo = request.CargoCodigo;
        var tipoContratoCodigo = request.TipoContratoCodigo;

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            byte[] pdfBytes = await _reporteService.GenerarReportePdfAsync(
                PeriodoCodigo,
                departamentoCodigo,
                cargoCodigo,
                tipoContratoCodigo
            );

            //string nombreArchivo = $"Reporte Nomina {fechaInicio:dd-MM-yy}_{fechaFin:dd-MM-yy}.pdf";
            string nombreArchivo = $"Reporte Nomina {DateTime.Now:dd-MM-yy}.pdf";

            return File(pdfBytes, "application/pdf", nombreArchivo);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { success = false, message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { success = false, message = $"Error al generar el PDF: {ex.Message}" });
        }
    }
}