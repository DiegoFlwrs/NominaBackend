using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.ReadModels
{
    public class ReporteNominaView
    {
        public string NombreCompleto { get; set; }
        public string CargoNombre { get; set; }
        public string DepartamentoNombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public decimal SueldoBase { get; set; }
        public decimal NominaBonificacion { get; set; }
        public decimal NominaDescuentos { get; set; }
        public decimal NominaSueldoNeto { get; set; }
        public string PeriodoInicio { get; set; }
        public string PeriodoFin { get; set; }
    }
}
