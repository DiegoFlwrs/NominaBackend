using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.Entities
{
    public class Empleado
    {
        public string EmpleadoCodigo { get; set; } = null!;
        public string? EmpleadoNombre { get; set; }
        public string? EmpleadoApellido { get; set; }
        public string? EmpleadoDNI { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string DepartamentoCodigo { get; set; } = null!;
        public string? CargoCodigo { get; set; }
        public string EmpleadoEstado { get; set; }
        public bool? EmpleadoTieneHijos { get; set; }
        public string? EmpleadoTipoPension { get; set; }
        public string? EmpleadoAFP { get; set; }

        // Relaciones
        public Departamento? Departamento { get; set; }
        public Cargo? Cargo { get; set; }
        public ICollection<ContratoLaboral> ContratosLaborales { get; set; }

    }
}
