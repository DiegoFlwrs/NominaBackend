namespace Nomina.Domain.Entities
{
    public class Empleado
    {
        public string EmpleadoCodigo { get; set; } = string.Empty;
        public string EmpleadoNombre { get; set; } = string.Empty;
        public string EmpleadoApellido { get; set; } = string.Empty;
        public string EmpleadoEstado { get; set; } = "A";
    }
}
