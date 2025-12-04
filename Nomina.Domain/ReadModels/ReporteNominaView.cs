using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.ReadModels
{
    public class ReporteNominaView
    {
        public string NombreCompleto { get; set; } = null!;
        public string CargoNombre { get; set; } = null!;
        public string DepartamentoNombre { get; set; } = null!;
        public DateTime FechaIngreso { get; set; }
        public decimal SueldoBase { get; set; }
        public decimal NominaBonificacion { get; set; }
        public decimal NominaDescuentos { get; set; }
        public decimal NominaSueldoNeto { get; set; }
        public string PeriodoInicio { get; set; } = null!;
        public string PeriodoFin { get; set; } = null!;
    }
}
