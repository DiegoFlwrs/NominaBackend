using System;

namespace Nomina.Domain.Entities
{
    public class HistorialContrato
    {
        public string HistorialCodigo { get; set; } = string.Empty;
        public string ContratoCodigo { get; set; } = string.Empty;
        public string EventoCodigo { get; set; } = string.Empty;
        public string HistorialMotivo { get; set; } = string.Empty;
        public string HistorialDetalle { get; set; } = string.Empty;
        public DateTime HistorialFecha { get; set; } = DateTime.Now;
    }
}
