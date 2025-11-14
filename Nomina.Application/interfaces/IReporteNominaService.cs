using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nomina.Domain.ReadModels;

namespace Nomina.Application.interfaces
{
    public interface IReporteNominaService
    {
    Task<List<ReporteNominaView>> GenerarReporteAsync(
        string? PeriodoCodigo,
        string? departamentoCodigo,
        string? cargoCodigo,
        string? tipoContratoCodigo
    );

    Task<byte[]> GenerarReportePdfAsync(
        string? PeriodoCodigo,
        string? departamentoCodigo,
        string? cargoCodigo,
        string? tipoContratoCodigo
    );
    }
}
