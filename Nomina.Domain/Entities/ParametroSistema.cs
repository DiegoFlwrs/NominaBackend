using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.Entities
{
    public class ParametroSistema
    {
        public string ParametroCodigo { get; set; } = null!;
        public string? ParametroNombre { get; set; }
        public decimal? ParametroValor { get; set; }
        public int? ParametroAnio { get; set; }
    }
}
