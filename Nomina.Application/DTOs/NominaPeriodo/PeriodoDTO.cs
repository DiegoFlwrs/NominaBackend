using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Application.DTOs.NominaPeriodo
{
    public class PeriodoDto
    {
        public string PeriodoCodigo { get; set; } = null!;
        public string PeriodoDescripcion { get; set; } = null!;
        public string PeriodoEstado{ get; set; } = null!;
    }
}
