
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Application.DTOs
{
    public class ProcesarNominaRequest
    {
        public int IdPeriodo { get; set; }         
        public DateTime FechaProceso { get; set; }  
        public int UsuarioId { get; set; }
    }
}
