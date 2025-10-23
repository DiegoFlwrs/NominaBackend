using Nomina.Application.interfaces;
using Nomina.Domain.Interfaces;
using Nomina.Domain.ReadModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Drawing;

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
            // RN-01
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

            // RN-03: 
            return reporte ?? new List<ReporteNominaView>();
        }

        // RN-06: Implementación de QuestPDF para generar el PDF
        public async Task<byte[]> GenerarReportePdfAsync(
            DateTime fechaInicio,
            DateTime fechaFin,
            string? departamentoCodigo,
            string? cargoCodigo,
            string? tipoContratoCodigo)
        {
            // RN-01
            if (fechaInicio > fechaFin)
            {
                throw new ArgumentException("La fecha de inicio no puede ser posterior a la fecha de fin.");
            }

            var reporteData = await _reporteRepository.ObtenerReporteNominaAsync(
                fechaInicio, fechaFin, departamentoCodigo, cargoCodigo, tipoContratoCodigo
            );

            // RN-03
            if (reporteData == null || !reporteData.Any())
            {
                throw new InvalidOperationException("No hay datos disponibles para generar el reporte PDF en el rango seleccionado.");
            }


            // 1. Definición del documento (Declarative C# de QuestPDF)
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(36);
                    page.DefaultTextStyle(x => x.FontSize(10)); // Fuente base por defecto

                    // Encabezado (Header)
                    page.Header()
                        .Column(column =>
                        {
                            // Título
                            column.Item().Text("Reporte de Nómina por Período").Style(TextStyle.Default.FontSize(16).Bold()).AlignCenter();
                            // Período
                            column.Item().Text($"Período: {fechaInicio:dd/MM/yyyy} - {fechaFin:dd/MM/yyyy}").AlignCenter();
                            column.Item().PaddingTop(10);
                        });

                    // Contenido (Content) - La Tabla
                    page.Content()
                        .PaddingVertical(5)
                        .Table(table =>
                        {
                            // Definición de las 7 columnas: 1.5 para Nombre, 1.0 para las demás
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(1.5f);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                            });

                            // Fila de Encabezados (Header)
                            table.Header(header =>
                            {
                                TextStyle headerStyle = TextStyle.Default.Bold().BackgroundColor(Colors.Grey.Lighten3);

                                header.Cell().BorderBottom(1).Padding(5).Text("Nombre Completo").Style(headerStyle);
                                header.Cell().BorderBottom(1).Padding(5).Text("Cargo").Style(headerStyle);
                                header.Cell().BorderBottom(1).Padding(5).Text("Fecha Ingreso").Style(headerStyle);
                                header.Cell().BorderBottom(1).Padding(5).Text("Sueldo Base").Style(headerStyle).AlignRight();
                                header.Cell().BorderBottom(1).Padding(5).Text("Bonificación").Style(headerStyle).AlignRight();
                                header.Cell().BorderBottom(1).Padding(5).Text("Descuentos").Style(headerStyle).AlignRight();
                                header.Cell().BorderBottom(1).Padding(5).Text("Sueldo Neto").Style(headerStyle).AlignRight();
                            });

                            // Celdas de Datos
                            foreach (var item in reporteData)
                            {
                                string fechaIngresoFormato = item.FechaIngreso.ToString("dd/MM/yyyy");
                                string formatoMoneda = "N2";

                                table.Cell().BorderBottom(1).Padding(5).Text(item.NombreCompleto);
                                table.Cell().BorderBottom(1).Padding(5).Text(item.CargoNombre);
                                table.Cell().BorderBottom(1).Padding(5).Text(fechaIngresoFormato);
                                table.Cell().BorderBottom(1).Padding(5).Text(item.SueldoBase.ToString(formatoMoneda)).AlignRight();
                                table.Cell().BorderBottom(1).Padding(5).Text(item.NominaBonificacion.ToString(formatoMoneda)).AlignRight();
                                table.Cell().BorderBottom(1).Padding(5).Text(item.NominaDescuentos.ToString(formatoMoneda)).AlignRight();
                                table.Cell().BorderBottom(1).Padding(5).Text(item.NominaSueldoNeto.ToString(formatoMoneda)).AlignRight();
                            }
                        });

                    // Pie de página (Footer)
                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Página ").FontSize(9);
                            x.CurrentPageNumber().FontSize(9);
                            x.Span(" de ").FontSize(9);
                            x.TotalPages().FontSize(9);
                        });
                });
            });

            // 2. Generar y devolver los bytes del PDF
            return document.GeneratePdf();
        }
    }
}