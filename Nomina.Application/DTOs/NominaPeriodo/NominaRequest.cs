using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Application.DTOs.NominaPeriodo
{
    public class NominaRequest
    {
        public string NominaCodigo { get; set; } = string.Empty;
        public string PeriodoCodigo { get; set; } = string.Empty;
        public string ContratoCodigo { get; set; } = string.Empty;
        public int NominaHorasExtras { get; set; }
        public decimal NominaBonificacion { get; set; }
        public decimal NominaDescuentos { get; set; }
    }
}
