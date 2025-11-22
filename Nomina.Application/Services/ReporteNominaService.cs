using Nomina.Application.interfaces;
using Nomina.Domain.Interfaces;
using Nomina.Domain.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nomina.Application.Helpers;
using Nomina.API.Exceptions;

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
            string? PeriodoCodigo,
            string? departamentoCodigo,
            string? cargoCodigo,
            string? tipoContratoCodigo)
        {

            var reporte = await _reporteRepository.ObtenerReporteNominaAsync(
                PeriodoCodigo,
                departamentoCodigo,
                cargoCodigo,
                tipoContratoCodigo
            );

            return reporte ?? new List<ReporteNominaView>();
        }

        public async Task<byte[]> GenerarReportePdfAsync(
            string? PeriodoCodigo,
            string? departamentoCodigo,
            string? cargoCodigo,
            string? tipoContratoCodigo)
        {

            var reporteData = await _reporteRepository.ObtenerReporteNominaAsync(
                PeriodoCodigo, departamentoCodigo, cargoCodigo, tipoContratoCodigo
            );


            if (reporteData == null || !reporteData.Any())
            {
                throw new BusinessException("No hay datos disponibles para generar el reporte PDF en el rango seleccionado.");
            }

            var fechas = reporteData.FirstOrDefault();

            var fechaInicio = DateTime.ParseExact(fechas.PeriodoInicio, "dd/MM/yyyy", null);
            var fechaFin = DateTime.ParseExact(fechas.PeriodoFin, "dd/MM/yyyy", null);


            return PdfGeneratorHelper.GenerarNominaPdf(reporteData.ToList(), fechaInicio, fechaFin);
        }
    }
}