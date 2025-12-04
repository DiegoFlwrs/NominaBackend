using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.ReadModels
{
    public class ContratoView
    {
        public string? ContratoCodigo { get; set; } = null!;
        public string? EmpleadoCodigo { get; set; } = null!;
        public string? EmpleadoNombre { get; set; } = null!;
        public string? EmpleadoApellido { get; set; } = null!;
        public string? TipoContratoCodigo { get; set; } = null!;
        public string? ModalidadCodigo { get; set; } = null!;
        public string? JornadaCodigo { get; set; } = null!;
        public string? UsuarioCodigo { get; set; } = null!;
        public string? TipoContratoDescripcion { get; set; } = null!;
        public string? ModalidadDescripcion { get; set; } = null!;
        public string? JornadaDescripcion { get; set; }
        public DateTime ContratoFechaInicio { get; set; }
        public DateTime? ContratoFechaFin { get; set; } 
        public decimal ContratoSalario { get; set; }
        public string? ContratoEstado { get; set; } = null!;
        public DateTime ContratoFechaRegistro { get; set; }
        public DateTime? ContratoFechaModificacion { get; set; }
    }
}
