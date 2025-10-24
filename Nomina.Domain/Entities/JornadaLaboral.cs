using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.Entities
{
    public class JornadaLaboral
    {
        public string JornadaCodigo { get; set; } = null!;
        public string? JornadaDescripcion { get; set; }

        // Relaciones
        public ICollection<ContratoLaboral>? ContratosLaborales { get; set; }
    }
}
