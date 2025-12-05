using System.Text.Json.Serialization;
namespace Nomina.Domain.Entities

{
    public class HistorialDetalle
    {
        public string? ContratoCodigo { get; set; }
        public string? Detalle { get; set; }
        public string? Motivo { get; set; }
        [JsonIgnore]
        public DateTime HistorialFecha { get; set; }
        public string HistorialFechaF => HistorialFecha.ToString("dd/MM/yyyy HH:mm:ss");
    }
}
