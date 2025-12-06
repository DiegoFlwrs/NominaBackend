using Microsoft.AspNetCore.Mvc;
using Nomina.Application.interfaces;
using Nomina.Application.Services;
using Nomina.Domain.ReadModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nomina.Application.DTOs;
using Nomina.API.Exceptions;

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

            string nombreArchivo = $"Reporte_Nomina_{DateTime.Now:ddMMyyyy}.pdf";
            return File(pdfBytes, "application/pdf", nombreArchivo);
        }
        catch (BusinessException ex)
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

    [HttpPost("nomina/excel")]
    [ProducesResponseType(typeof(FileResult), 200)]
    public async Task<IActionResult> GenerarReporteNominaExcel(
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

            byte[] excelBytes = await _reporteService.GenerarReporteExcelAsync(
                PeriodoCodigo,
                departamentoCodigo,
                cargoCodigo,
                tipoContratoCodigo
            );


            string nombreArchivo;
            if (!string.IsNullOrEmpty(PeriodoCodigo))
            {
                nombreArchivo = $"Reporte_Nomina_{PeriodoCodigo}_{DateTime.Now:ddMMyyyyHHmm}.xlsx";
            }
            else
            {
                nombreArchivo = $"Reporte_Nomina_{DateTime.Now:ddMMyyyyHHmm}.xlsx";
            }

            return File(excelBytes,
                       "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                       nombreArchivo);
        }
        catch (BusinessException ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { success = false, message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { success = false, message = $"Error al generar el Excel: {ex.Message}" });
        }
    }
}
