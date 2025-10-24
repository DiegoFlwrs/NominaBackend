using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.Entities
{
    public class ModalidadPago
    {
        public string ModalidadCodigo { get; set; } = null!;
        public string? ModalidadDescripcion { get; set; }

        // Relaciones
        public ICollection<ContratoLaboral>? ContratosLaborales { get; set; }
    }
}
