using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.Entities
{
    public class TipoContrato
    {
        public string TipoContratoCodigo { get; set; } = null!;
        public string? TipoContratoDescripcion { get; set; }

        // Relaciones
        public ICollection<ContratoLaboral>? ContratosLaborales { get; set; }
    }
}
