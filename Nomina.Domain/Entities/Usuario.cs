using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.Entities
{
    public class Usuario
    {
        public string UsuarioCodigo { get; set; } = null!;
        public string? UsuarioNombre { get; set; }
        public string? UsuarioCorreo { get; set; }
        public string? UsuarioRol { get; set; }

        // Relaciones
        public ICollection<ContratoLaboral>? ContratosLaborales { get; set; }
    }
}
