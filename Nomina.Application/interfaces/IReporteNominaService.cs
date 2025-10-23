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
        DateTime fechaInicio,
        DateTime fechaFin,
        string? departamentoCodigo,
        string? cargoCodigo,
        string? tipoContratoCodigo
    );

    Task<byte[]> GenerarReportePdfAsync(
        DateTime fechaInicio,
        DateTime fechaFin,
        string? departamentoCodigo,
        string? cargoCodigo,
        string? tipoContratoCodigo
    );
    }
}
