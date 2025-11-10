using System.Text.Json.Serialization;
namespace Nomina.Domain.Entities

{
    public class HistorialDetalle
    {
        public string? HistorialCodigo { get; set; }
        public string? ContratoCodigo { get; set; }
        public string? Detalle { get; set; }
        [JsonIgnore]
        public DateTime HistorialFecha { get; set; }
        public string HistorialFechaTexto => HistorialFecha.ToString("dd/MM/yyyy HH:mm:ss");
    }
}
