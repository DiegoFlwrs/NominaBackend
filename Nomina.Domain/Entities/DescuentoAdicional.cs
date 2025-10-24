using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.Entities
{
    public class DescuentoAdicional
    {
        public string DescuentoCodigo { get; set; } = null!;
        public string? NominaCodigo { get; set; }
        public string? DescuentoTipo { get; set; }
        public decimal? DescuentoMonto { get; set; }
        public string? DescuentoMotivo { get; set; }
        public string? DescuentoAutorizadoPor { get; set; }
        public DateTime? DescuentoFecha { get; set; } = DateTime.Now;

        // Relaciones
        public Nominas? Nomina { get; set; }
    }
}
