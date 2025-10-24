using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.Entities
{
    public class Cargo
    {
        public string CargoCodigo { get; set; } = null!;
        public string? CargoNombre { get; set; }

        // Relaciones
        public ICollection<Empleado>? Empleados { get; set; }
    }
}
