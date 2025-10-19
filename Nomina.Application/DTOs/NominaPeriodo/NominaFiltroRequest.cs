using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Application.DTOs.NominaPeriodo
{
    public class NominaFiltroRequest
    {
        public int? PeriodoAnio { get; set; }
        public int? PeriodoMes { get; set; }
        public string? NominaEstado { get; set; }
        public string? EmpleadoNombre { get; set; }
        public string? EmpleadoApellido { get; set; }
        public string? DepartamentoCodigo { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
