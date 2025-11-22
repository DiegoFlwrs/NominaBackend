using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nomina.Domain.ReadModels;

namespace Nomina.Domain.Interfaces
{
    public interface IReporteNominaRepository
    {
        
        Task<List<ReporteNominaView>> ObtenerReporteNominaAsync(
            string? PeriodoCodigo = null,
            string departamentoCodigo = null, 
            string cargoCodigo = null,       
            string tipoContratoCodigo = null 
        );
    }
}
