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
        public string PeriodoCodigo { get; set; }
        public int PeriodoAnio { get; set; }
        public int PeriodoMes { get; set; }
        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFin { get; set; }
        public string ContratoCodigo { get; set; }
        public string EmpleadoCodigo { get; set; }
        public string EmpleadoApellido { get; set; }
        public string EmpleadoNombre { get; set; }
        public string CargoNombre { get; set; }
        public string DepartamentoNombre { get; set; }
        public string TipoContratoDescripcion { get; set; }
        public decimal ContratoSalario { get; set; }

        public decimal? NominaHorasExtras { get; set; }
        public decimal? NominaBonificacion { get; set; }
        public decimal? NominaDescuentos { get; set; }
        public decimal? NominaTotalIngresos { get; set; }
        public decimal? NominaTotalDescuentos { get; set; }
        public decimal NominaSueldoNeto { get; set; }
        public DateTime? NominaFechaProcesamiento { get; set; }
        public string NominaEstado { get; set; }

        public string EstadoNominaNombre { get; set; }
    }
}
