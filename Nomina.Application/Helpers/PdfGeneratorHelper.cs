using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Drawing;
using Nomina.Domain.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nomina.Application.Helpers
{
    public static class PdfGeneratorHelper
    {
        public static byte[] GenerarNominaPdf(List<ReporteNominaView> data, DateTime fechaInicio, DateTime fechaFin)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(36);
                    page.DefaultTextStyle(x => x.FontSize(10));
                    page.Header()
                        .Column(column =>
                        {
                            column.Item().Text("Reporte de Nómina por Período").Style(TextStyle.Default.FontSize(16).Bold()).AlignCenter();
                            column.Item().Text($"Período: {fechaInicio:dd/MM/yyyy} - {fechaFin:dd/MM/yyyy}").AlignCenter();
                            column.Item().PaddingTop(10);
                        });

                    page.Content()
                        .PaddingVertical(5)
                        .Table(table =>
                        {
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

                            foreach (var item in data)
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

            return document.GeneratePdf();
        }
    }
}