using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.ReadModels
{
    public class ContratoView
    {
        public string? ContratoCodigo { get; set; }
        public string? EmpleadoCodigo { get; set; }
        public string? EmpleadoNombre { get; set; }
        public string? EmpleadoApellido { get; set; }
        public string? TipoContratoCodigo { get; set; }
        public string? ModalidadCodigo { get; set; }
        public string? JornadaCodigo { get; set; }
        public string? UsuarioCodigo { get; set; }
        public string? TipoContratoDescripcion { get; set; }
        public string? ModalidadDescripcion { get; set; }
        public string? JornadaDescripcion { get; set; }
        public DateTime ContratoFechaInicio { get; set; }
        public DateTime? ContratoFechaFin { get; set; } 
        public decimal ContratoSalario { get; set; }
        public string? ContratoEstado { get; set; }
        public DateTime ContratoFechaRegistro { get; set; }
        public DateTime? ContratoFechaModificacion { get; set; }
    }
}
