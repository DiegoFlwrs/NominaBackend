using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.Entities
{
    public class EventoContrato
    {
        public string EventoCodigo { get; set; } = null!;
        public string? EventoNombre { get; set; }
        public string? EventoDescripcion { get; set; }

    }
}
