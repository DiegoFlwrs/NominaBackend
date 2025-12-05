using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Application.DTOs
{
    // View Model utilizado para enviar los datos de la nómina al Front-End (RN-02)
    public class ReporteNominaResponse
    {
        public string NominaCodigo { get; set; } = null!;
        public string EmpleadoApellido { get; set; } = null!;
        public string EmpleadoNombre { get; set; } = null!;
        public string DepartamentoNombre { get; set; } = null!;
        public string CargoNombre { get; set; } = null!;

        public int PeriodoAnio { get; set; }
        public int PeriodoMes { get; set; }

        public decimal ContratoSalario { get; set; }
        public decimal NominaHorasExtras { get; set; }
        public decimal NominaBonificacion { get; set; }
        public decimal NominaDescuentos { get; set; }

        // RN-12: Sueldo Neto (puede ser decimal o string)
        public decimal NominaSueldoNeto { get; set; }

        public string NominaEstado { get; set; } = null!;
        public DateTime NominaFechaProcesamiento { get; set; }
    }
}
