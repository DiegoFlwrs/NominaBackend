using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.rules
{
    public static class ReglasNomina
    {
        public static decimal CalcularTotalIngresos(decimal salarioBase, decimal bonificacion, decimal horasExtras)
        {
            decimal pagoHorasExtras = horasExtras * (salarioBase / 240m) * 1.5m;
            return salarioBase + bonificacion + pagoHorasExtras;
        }

        public static decimal CalcularAsignacionFamiliar(bool tieneHijos, decimal rmv)
        {
            return tieneHijos ? rmv * 0.10m : 0m;
        }

        public static decimal CalcularEssalud(decimal salarioBase)
        {
            return salarioBase * 0.09m;
        }

        public static decimal CalcularDescuentoPension(string tipoPension, decimal salarioBase)
        {
            if (tipoPension == "ONP")
                return salarioBase * 0.13m;
            else if (tipoPension == "AFP")
                return salarioBase * 0.12m;
            else
                return 0m;
        }

        public static decimal CalcularRentaQuinta(decimal sueldoAnual, decimal valorUIT)
        {
            decimal limite = valorUIT * 7;
            if (sueldoAnual <= limite)
                return 0m;

            decimal excedente = sueldoAnual - limite;
            return excedente * 0.05m;
        }

        public static decimal CalcularTotalDescuentosAdicionales(params decimal[] descuentos)
        {
            decimal total = 0;
            foreach (var d in descuentos)
                total += d;
            return total;
        }

        public static decimal CalcularDescuentos(string? tipoPension, string? afp, decimal salarioBase)
        {
            decimal descuentoPension = CalcularDescuentoPension(tipoPension ?? "", salarioBase);
            decimal descuentoEssalud = CalcularEssalud(salarioBase);

            return CalcularTotalDescuentosAdicionales(descuentoPension, descuentoEssalud);
        }

        public static decimal CalcularSueldoNeto(decimal totalIngresos, decimal totalDescuentos)
        {
            return totalIngresos - totalDescuentos;
        }

        public static bool ValidarSueldoMinimo(decimal sueldoNeto, decimal rmv)
        {
            return sueldoNeto >= rmv;
        }
    }
}
