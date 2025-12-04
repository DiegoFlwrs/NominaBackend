using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.Entities
{
    public class ContratoLaboral
    {
        public string ContratoCodigo { get; set; } = null!;
        public string EmpleadoCodigo { get; set; } = null!;
        public string? TipoContratoCodigo { get; set; }
        public string? ModalidadCodigo { get; set; }
        public string? JornadaCodigo { get; set; }
        public string? UsuarioCodigo { get; set; }
        public DateTime? ContratoFechaInicio { get; set; }
        public DateTime? ContratoFechaFin { get; set; }
        public decimal ContratoSalario { get; set; }
        public string ContratoEstado { get; set; } = "A";
        public DateTime? ContratoFechaRegistro { get; set; } = DateTime.Now;
        public DateTime? ContratoFechaModificacion { get; set; }

        public Empleado? Empleado { get; set; }
        public TipoContrato? TipoContrato { get; set; }
        public ModalidadPago? Modalidad { get; set; }
        public JornadaLaboral? Jornada { get; set; }
        public Usuario? Usuario { get; set; }
        public ICollection<Nominas> Nominas { get; set; } = null!;
    }
}