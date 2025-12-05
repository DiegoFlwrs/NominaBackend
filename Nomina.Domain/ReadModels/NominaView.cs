using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.ReadModels
{
    public class NominaView
    {
        public string NominaCodigo { get; set; }
        public string Nombre { get; set; } 

        public decimal? NominaHorasExtras { get; set; }
        public decimal? NominaMontoHorasExtras { get; set; }
        public decimal ContratoSalario { get; set; }
        public decimal? NominaBonificacion { get; set; }
        public decimal? NominaAsignacionFamiliar { get; set; }
        public decimal? NominaTotalIngresos { get; set; }

        public decimal? NominaDescuentoPension { get; set; }
        public decimal? NominaDescuentoIR5ta { get; set; }
        public decimal? NominaAporteEssalud { get; set; }
        public decimal? NominaOtrosDescuentos { get; set; }

        public decimal? NominaTotalDescuentos { get; set; }
        public decimal? NominaSueldoNeto { get; set; }
    }
}
