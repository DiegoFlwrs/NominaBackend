using System;

namespace Nomina.Application.DTOs
{
    public class ContratoLaboralDTO
    {
        public string ContratoCodigo { get; set; } = string.Empty;
        public string EmpleadoCodigo { get; set; } = string.Empty;
        public string Empleado{ get; set; } = string.Empty;
        public string TipoContratoCodigo { get; set; } = string.Empty;
        public string ModalidadCodigo { get; set; } = string.Empty;
        public string JornadaCodigo { get; set; } = string.Empty;
        public string UsuarioCodigo { get; set; } = string.Empty;
        public DateTime? ContratoFechaInicio { get; set; }
        public DateTime? ContratoFechaFin { get; set; }
        public decimal ContratoSalario { get; set; }
        public string ContratoEstado { get; set; } = "A";
        public string? Motivo { get; set; }
    }
}