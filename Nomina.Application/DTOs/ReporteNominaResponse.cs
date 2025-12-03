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
        public string NominaCodigo { get; set; } = string.Empty;
        public string EmpleadoApellido { get; set; } = string.Empty;
        public string EmpleadoNombre { get; set; } = string.Empty;
        public string DepartamentoNombre { get; set; } = string.Empty;
        public string CargoNombre { get; set; } = string.Empty;

        public int PeriodoAnio { get; set; }
        public int PeriodoMes { get; set; }

        public decimal ContratoSalario { get; set; }
        public decimal NominaHorasExtras { get; set; }
        public decimal NominaBonificacion { get; set; }
        public decimal NominaDescuentos { get; set; }

        // RN-12: Sueldo Neto (puede ser decimal o string)
        public decimal NominaSueldoNeto { get; set; }

        public string NominaEstado { get; set; } = string.Empty;
        public DateTime NominaFechaProcesamiento { get; set; }
    }
}
