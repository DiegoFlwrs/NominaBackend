using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Application.DTOs
{
    
    public class ReporteNominaResponse
    {
        public string Codigo { get; set; }                // ContratoCodigo
        public string Empleado { get; set; }              // Nombre completo
        public DateTime fechaIngreso { get; set; }
        public decimal SalarioBase { get; set; }          // ContratoSalario
        public int HorasExtras { get; set; }              // NominaHorasExtras
        public decimal MontoHorasExtras { get; set; }     // NominaMontoHorasExtras
        public decimal Bonificacion { get; set; }         // NominaBonificacion
        public decimal AsignacionFamiliar { get; set; }   // NominaAsignacionFamiliar
        public decimal TotalIngresos { get; set; }        // NominaTotalIngresos
        public decimal DescPension { get; set; }          // NominaDescuentoPension
        public decimal IR5ta { get; set; }                // NominaDescuentoIR5ta
        public decimal Essalud { get; set; }              // NominaAporteEssalud
        public decimal OtrosDesc { get; set; }            // NominaOtrosDescuentos
        public decimal TotalDescuentos { get; set; }      // NominaTotalDescuentos
        public decimal SueldoNeto { get; set; }           // NominaSueldoNeto
        public string PeriodoInicio { get; set; }         // CONVERT(VARCHAR(10), P.PeriodoInicio, 103)
        public string PeriodoFin { get; set; }            // CONVERT(VARCHAR(10), P.PeriodoFin, 103)
        public string PeriodoEstado { get; set; }
    }
}
