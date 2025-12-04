using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Application.DTOs
{
    public class ReporteNominaRequest
    {
        [Required]
        public string PeriodoCodigo { get; set; } = null!;
        public string? DepartamentoCodigo { get; set; }
        public string? CargoCodigo { get; set; }
        public string? TipoContratoCodigo { get; set; }
    }
}
