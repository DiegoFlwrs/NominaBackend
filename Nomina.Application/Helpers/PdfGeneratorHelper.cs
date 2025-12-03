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
                    page.Size(PageSizes.A4.Landscape());
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
                                columns.RelativeColumn(1);
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

                                header.Cell().BorderBottom(1).Padding(5).Text("Código").Style(headerStyle);
                                header.Cell().BorderBottom(1).Padding(5).Text("Empleado").Style(headerStyle);
                                header.Cell().BorderBottom(1).Padding(5).Text("Salario Base").Style(headerStyle);
                                header.Cell().BorderBottom(1).Padding(5).Text("Horas Extras").Style(headerStyle).AlignRight();
                                header.Cell().BorderBottom(1).Padding(5).Text("Monto Horas Extras").Style(headerStyle).AlignRight();
                                header.Cell().BorderBottom(1).Padding(5).Text("Bonificación").Style(headerStyle).AlignRight();
                                header.Cell().BorderBottom(1).Padding(5).Text("Asignación Familiar").Style(headerStyle).AlignRight();
                                header.Cell().BorderBottom(1).Padding(5).Text("Total Ingresos").Style(headerStyle).AlignRight();
                                header.Cell().BorderBottom(1).Padding(5).Text("Desc. Pensión").Style(headerStyle).AlignRight();
                                header.Cell().BorderBottom(1).Padding(5).Text("IR 5ta").Style(headerStyle).AlignRight();
                                header.Cell().BorderBottom(1).Padding(5).Text("Essalud").Style(headerStyle).AlignRight();
                                header.Cell().BorderBottom(1).Padding(5).Text("Otros Desc.").Style(headerStyle).AlignRight();
                                header.Cell().BorderBottom(1).Padding(5).Text("Total Descuentos").Style(headerStyle).AlignRight();
                                header.Cell().BorderBottom(1).Padding(5).Text("Sueldo Neto").Style(headerStyle).AlignRight();
                            });

                            foreach (var item in data)
                            {
                                string fechaIngresoFormato = item.fechaIngreso.ToString("dd/MM/yyyy");
                                string formatoMoneda = "N2";

                                table.Cell().BorderBottom(1).Padding(5).Text(item.Codigo);
                                table.Cell().BorderBottom(1).Padding(5).Text(item.Empleado);
                                table.Cell().BorderBottom(1).Padding(5).Text(item.SalarioBase.ToString(formatoMoneda)).AlignRight();
                                table.Cell().BorderBottom(1).Padding(5).Text(item.HorasExtras.ToString()).AlignRight();
                                table.Cell().BorderBottom(1).Padding(5).Text(item.MontoHorasExtras.ToString(formatoMoneda)).AlignRight();
                                table.Cell().BorderBottom(1).Padding(5).Text(item.Bonificacion.ToString(formatoMoneda)).AlignRight();
                                table.Cell().BorderBottom(1).Padding(5).Text(item.AsignacionFamiliar.ToString(formatoMoneda)).AlignRight();
                                table.Cell().BorderBottom(1).Padding(5).Text(item.TotalIngresos.ToString(formatoMoneda)).AlignRight();
                                table.Cell().BorderBottom(1).Padding(5).Text(item.DescPension.ToString(formatoMoneda)).AlignRight();
                                table.Cell().BorderBottom(1).Padding(5).Text(item.IR5ta.ToString(formatoMoneda)).AlignRight();
                                table.Cell().BorderBottom(1).Padding(5).Text(item.Essalud.ToString(formatoMoneda)).AlignRight();
                                table.Cell().BorderBottom(1).Padding(5).Text(item.OtrosDesc.ToString(formatoMoneda)).AlignRight();
                                table.Cell().BorderBottom(1).Padding(5).Text(item.TotalDescuentos.ToString(formatoMoneda)).AlignRight();
                                table.Cell().BorderBottom(1).Padding(5).Text(item.SueldoNeto.ToString(formatoMoneda)).AlignRight();

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