using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.Entities
{
    public class PeriodoNomina
    {
        public string? PeriodoCodigo { get; set; } = null!;
        public string? PeriodoTipo { get; set; } = null!;
        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFin { get; set; }
        public string? PeriodoEstado { get; set; } = null!;
        public int PeriodoAnio { get; set; }
        public int PeriodoMes { get; set; }
        public DateTime PeriodoFechaPago { get; set; }
        // Relaciones
        public ICollection<Nominas>? Nominas { get; set; }
    }
}
