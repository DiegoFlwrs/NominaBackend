using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.Entities
{
    [Table("ConceptosNomina")]
    public class ConceptoNomina
    {
        [Key]
        [StringLength(10)]
        public string ConceptoCodigo { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string ContratoCodigo { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string PeriodoCodigo { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string TipoConcepto { get; set; } = string.Empty; // 'HorasExtras', 'Bonificacion', 'Descuento'

        [Column(TypeName = "numeric(10,2)")]
        public decimal? Monto { get; set; }

        public int? HorasExtras { get; set; }

        [StringLength(200)]
        public string? Descripcion { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public ContratoLaboral? Contrato { get; set; }
        public PeriodoNomina? Periodo { get; set; }
    }
}
