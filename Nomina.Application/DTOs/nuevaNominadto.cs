using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Application.DTOs
{
    public class nuevaNominadto
    {
        public string ContratoCodigo { get; set; } = "";
        public string PeriodoCodigo { get; set; } = "";
        public int HorasExtras { get; set; }
        public decimal Bonificaciones { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal TotalDescuentos { get; set; }
        public decimal SueldoNeto { get; set; }
    }
}
