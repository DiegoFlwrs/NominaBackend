using ClosedXML.Excel;
using Nomina.Domain.ReadModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Nomina.Application.Helpers
{
    public static class ExcelGeneratorHelper
    {
        public static byte[] GenerarNominaExcel(List<ReporteNominaView> datos)
        {
            if (!datos.Any())
            {
                return Array.Empty<byte>();
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Reporte Nómina");

                var fechas = datos.First();

                worksheet.Cell(1, 1).Value = $"REPORTE DE NÓMINA - {fechas.PeriodoInicio} al {fechas.PeriodoFin}";
                worksheet.Range(1, 1, 1, 14).Merge();
                var titleCell = worksheet.Cell(1, 1);
                titleCell.Style.Font.Bold = true;
                titleCell.Style.Font.FontSize = 14;
                titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                titleCell.Style.Fill.BackgroundColor = XLColor.LightBlue;

                worksheet.Cell(2, 1).Value = $"Generado el: {DateTime.Now:dd/MM/yyyy HH:mm} - Total de registros: {datos.Count}";
                worksheet.Range(2, 1, 2, 14).Merge();
                worksheet.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(2, 1).Style.Font.Italic = true;

                worksheet.Row(3).Height = 5;

                string[] headers = {
                    "Código",               
                    "Empleado",             
                    "Salario Base",         
                    "Horas Extras",         
                    "Monto Horas Extras",   
                    "Bonificación",         
                    "Asignación Familiar",  
                    "Total Ingresos",       
                    "Desc. Pensión",        
                    "IR 5ta",               
                    "Essalud",              
                    "Otros Desc.",          
                    "Total Descuentos",     
                    "Sueldo Neto"           
                };

                for (int i = 0; i < headers.Length; i++)
                {
                    var cell = worksheet.Cell(4, i + 1);
                    cell.Value = headers[i];
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }

                int row = 5;
                decimal totalIngresos = 0;
                decimal totalDescuentos = 0;
                decimal totalNeto = 0;

                foreach (var item in datos)
                {
                    worksheet.Cell(row, 1).Value = item.Codigo;
                    worksheet.Cell(row, 2).Value = item.Empleado;
                    worksheet.Cell(row, 3).Value = item.SalarioBase;
                    worksheet.Cell(row, 4).Value = item.HorasExtras;
                    worksheet.Cell(row, 5).Value = item.MontoHorasExtras;
                    worksheet.Cell(row, 6).Value = item.Bonificacion;
                    worksheet.Cell(row, 7).Value = item.AsignacionFamiliar;
                    worksheet.Cell(row, 8).Value = item.TotalIngresos;
                    worksheet.Cell(row, 9).Value = item.DescPension;
                    worksheet.Cell(row, 10).Value = item.IR5ta;
                    worksheet.Cell(row, 11).Value = item.Essalud;
                    worksheet.Cell(row, 12).Value = item.OtrosDesc;
                    worksheet.Cell(row, 13).Value = item.TotalDescuentos;
                    worksheet.Cell(row, 14).Value = item.SueldoNeto;

                    totalIngresos += item.TotalIngresos;
                    totalDescuentos += item.TotalDescuentos;
                    totalNeto += item.SueldoNeto;

                    row++;
                }

                if (datos.Any())
                {
                    int totalRow = row + 1;

                    worksheet.Cell(totalRow, 7).Value = "TOTALES:";
                    worksheet.Cell(totalRow, 7).Style.Font.Bold = true;
                    worksheet.Cell(totalRow, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    worksheet.Cell(totalRow, 8).Value = totalIngresos;
                    worksheet.Cell(totalRow, 8).Style.Font.Bold = true;
                    worksheet.Cell(totalRow, 8).Style.Fill.BackgroundColor = XLColor.LightGreen;
                    worksheet.Cell(totalRow, 8).Style.NumberFormat.Format = "\"S/\" #,##0.00";

                    worksheet.Cell(totalRow, 13).Value = totalDescuentos;
                    worksheet.Cell(totalRow, 13).Style.Font.Bold = true;
                    worksheet.Cell(totalRow, 13).Style.Fill.BackgroundColor = XLColor.LightGreen;
                    worksheet.Cell(totalRow, 13).Style.NumberFormat.Format = "\"S/\" #,##0.00";

                    worksheet.Cell(totalRow, 14).Value = totalNeto;
                    worksheet.Cell(totalRow, 14).Style.Font.Bold = true;
                    worksheet.Cell(totalRow, 14).Style.Fill.BackgroundColor = XLColor.LightGreen;
                    worksheet.Cell(totalRow, 14).Style.NumberFormat.Format = "\"S/\" #,##0.00";

                    var totalRange = worksheet.Range(totalRow, 8, totalRow, 14);
                    totalRange.Style.Border.TopBorder = XLBorderStyleValues.Double;
                }

                int[] moneyColumns = { 3, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
                foreach (int col in moneyColumns)
                {
                    worksheet.Column(col).Style.NumberFormat.Format = "\"S/\" #,##0.00"; 
                    worksheet.Column(col).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                }

                worksheet.Column(1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Column(2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                worksheet.Column(4).Style.NumberFormat.Format = "0";
                worksheet.Column(4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                var dataRange = worksheet.Range(4, 1, row - 1, 14);
                dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                worksheet.Column(2).Width = 30;   
                worksheet.Column(8).Width = 15;   
                worksheet.Column(14).Width = 15;  

                for (int col = 1; col <= 14; col++)
                {
                    if (col != 2 && col != 8 && col != 14)
                    {
                        worksheet.Column(col).AdjustToContents();
                        if (worksheet.Column(col).Width < 10)
                        {
                            worksheet.Column(col).Width = 10;
                        }
                    }
                }

                worksheet.SheetView.Freeze(4, 0);

                for (int r = 5; r < row; r += 2)
                {
                    var rowRange = worksheet.Range(r, 1, r, 14);
                    rowRange.Style.Fill.BackgroundColor = XLColor.AliceBlue;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}