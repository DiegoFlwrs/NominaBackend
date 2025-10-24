using Nomina.Application.interfaces;
using Nomina.Domain.Interfaces;
using Nomina.Domain.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nomina.Application.Helpers;

namespace Nomina.Application.Services
{
    public class ReporteNominaService : IReporteNominaService
    {
        private readonly IReporteNominaRepository _reporteRepository;

        public ReporteNominaService(IReporteNominaRepository reporteRepository)
        {
            _reporteRepository = reporteRepository;
        }

        public async Task<List<ReporteNominaView>> GenerarReporteAsync(
            DateTime fechaInicio,
            DateTime fechaFin,
            string? departamentoCodigo,
            string? cargoCodigo,
            string? tipoContratoCodigo)
        {
            if (fechaInicio > fechaFin)
            {
                throw new ArgumentException("La fecha de inicio no puede ser posterior a la fecha de fin.");
            }

            var reporte = await _reporteRepository.ObtenerReporteNominaAsync(
                fechaInicio,
                fechaFin,
                departamentoCodigo,
                cargoCodigo,
                tipoContratoCodigo
            );

            return reporte ?? new List<ReporteNominaView>();
        }

        public async Task<byte[]> GenerarReportePdfAsync(
            DateTime fechaInicio,
            DateTime fechaFin,
            string? departamentoCodigo,
            string? cargoCodigo,
            string? tipoContratoCodigo)
        {
         
            if (fechaInicio > fechaFin)
            {
                throw new ArgumentException("La fecha de inicio no puede ser posterior a la fecha de fin.");
            }

            var reporteData = await _reporteRepository.ObtenerReporteNominaAsync(
                fechaInicio, fechaFin, departamentoCodigo, cargoCodigo, tipoContratoCodigo
            );

            if (reporteData == null || !reporteData.Any())
            {
                throw new InvalidOperationException("No hay datos disponibles para generar el reporte PDF en el rango seleccionado.");
            }

            return PdfGeneratorHelper.GenerarNominaPdf(reporteData.ToList(), fechaInicio, fechaFin);
        }
    }
}