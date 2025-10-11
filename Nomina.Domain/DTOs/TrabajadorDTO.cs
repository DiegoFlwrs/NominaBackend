using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.DTOs
{
    public class TrabajadorDTO
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string SistemaPension { get; set; }
    }
}
