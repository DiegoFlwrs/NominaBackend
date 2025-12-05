using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Application.DTOs
{
    public class NuevaNominaDto
    {
        public string ContratoCodigo { get; set; } = "";
        public string PeriodoCodigo { get; set; } = "";
        public int nominaHorasExtras { get; set; }
        public decimal nominaMontoHorasExtras { get; set; }
        public decimal Bonificaciones { get; set; }
        public decimal nominaAsignacionFamiliar { get; set; }
        public decimal nominaDescuentoPension { get; set; }
        public decimal nominaDescuentoIR5ta { get; set; }
        public decimal nominaAporteEssalud { get; set; }
        public decimal nominaOtrosDescuentos { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal TotalDescuentos { get; set; }
        public decimal SueldoNeto { get; set; }
    }
}
