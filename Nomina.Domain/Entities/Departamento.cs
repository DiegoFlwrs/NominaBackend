using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.Entities
{
    public class Departamento
    {
        public string DepartamentoCodigo { set; get; } = null!;
        public string DepartamentoNombre { set; get; } = null!;
        // Relaciones
        public ICollection<Empleado>? Empleados { get; set; }
    }
}
