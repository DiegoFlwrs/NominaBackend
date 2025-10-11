using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.Entities
{
    public class Trabajador
    {
        public int IdTrabajador { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }
        public string SistemaPension { get; set; }
        public bool TieneHijos { get; set; }
    }
}
