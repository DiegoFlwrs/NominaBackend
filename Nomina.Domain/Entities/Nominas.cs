using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.Entities
{
    public class Nominas
    {
        public string NominaCodigo { get; set; } = null!;
        public string? PeriodoCodigo { get; set; }
        public string? ContratoCodigo { get; set; }
        public int? NominaMontoHorasExtras { get; set; } = 0;
        public decimal? NominaBonificacion { get; set; } = 0;
        public decimal? NominaDescuentos { get; set; } = 0;
        public decimal? NominaTotalIngresos { get; set; }
        public decimal? NominaTotalDescuentos { get; set; }
        public decimal? NominaSueldoNeto { get; set; }
        public DateTime? NominaFechaProcesamiento { get; set; } = DateTime.Now;
        public string? NominaEstado { get; set; } = "A";

        // Relaciones
        public PeriodoNomina? Periodo { get; set; }
        public ContratoLaboral? Contrato { get; set; }
        public ICollection<DescuentoAdicional>? DescuentosAdicionales { get; set; }
    }
}
