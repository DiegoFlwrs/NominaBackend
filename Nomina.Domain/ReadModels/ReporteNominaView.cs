using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.ReadModels
{
    public class ReporteNominaView
    {
        public string Codigo { get; set; } = null!;               
        public string Empleado { get; set; } = null!;              
        public DateTime fechaIngreso { get; set; }         
        public decimal SalarioBase { get; set; }          
        public int HorasExtras { get; set; }              
        public decimal MontoHorasExtras { get; set; }     
        public decimal Bonificacion { get; set; }         
        public decimal AsignacionFamiliar { get; set; }   
        public decimal TotalIngresos { get; set; }        
        public decimal DescPension { get; set; }          
        public decimal IR5ta { get; set; }                
        public decimal Essalud { get; set; }              
        public decimal OtrosDesc { get; set; }            
        public decimal TotalDescuentos { get; set; }      
        public decimal SueldoNeto { get; set; }           
        public string PeriodoInicio { get; set; } = null!;            
        public string PeriodoFin { get; set; } = null!;               
    }
}
