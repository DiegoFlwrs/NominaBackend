using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.rules
{
    public static class ReglasNomina
    {
        public static decimal CalcularAsignacionFamiliar(bool tieneHijos, decimal remuneracionMinimaVigente)
        {
            return Math.Round(tieneHijos ? remuneracionMinimaVigente * 0.10m : 0m, 2, MidpointRounding.AwayFromZero);
        }

        public static decimal CalcularPagoHorasExtras(decimal salarioBase, decimal horasExtras)
        {
            if (horasExtras <= 0) return 0m;

            decimal tarifaHora = salarioBase / 240m;

            decimal horasNormales = Math.Min(horasExtras, 2);
            decimal horasAdicionales = Math.Max(horasExtras - 2, 0);

            decimal pagoNormales = horasNormales * tarifaHora * 1.25m;
            decimal pagoAdicionales = horasAdicionales * tarifaHora * 1.35m;

            return Math.Round(pagoNormales + pagoAdicionales, 2, MidpointRounding.AwayFromZero);
        }

        public static decimal CalcularSueldoBruto(decimal sueldoBasico, decimal asignacionFamiliar, decimal pagoHorasExtras, decimal bonificacion)
        {
            return Math.Round(sueldoBasico + asignacionFamiliar + pagoHorasExtras + bonificacion, 2, MidpointRounding.AwayFromZero);
        }

        public static decimal CalcularEssalud(decimal sueldoBruto)
        {
            return Math.Round(sueldoBruto * 0.09m, 2, MidpointRounding.AwayFromZero);
        }

        public static decimal CalcularDescuentoPension(string tipoPension, decimal sueldoBruto, decimal porcetajePension)
        {
            tipoPension = tipoPension?.ToUpper() ?? "";

            decimal resultado = 0m;

            if (tipoPension == "ONP")
            {
                resultado = sueldoBruto * porcetajePension;
            }
            else if (tipoPension == "AFP")
            {
                decimal aporte = sueldoBruto * 0.10m;
                decimal descuentoSeguro = sueldoBruto * porcetajePension;
                resultado = aporte + descuentoSeguro;
            }

            return Math.Round(resultado, 2, MidpointRounding.AwayFromZero);
        }

        public static decimal CalcularRentaQuinta(decimal sueldoAnual, decimal UIT)
        {
            decimal deduccion = UIT * 7;
            decimal rentaNeta = sueldoAnual - deduccion;
            if (rentaNeta <= 0)
                return 0m;

            decimal impuesto = 0m;

            decimal[] tramos = { UIT * 5, UIT * 20, UIT * 35, UIT * 45 };
            decimal[] tasas = { 0.08m, 0.14m, 0.17m, 0.20m, 0.30m };

            decimal restante = rentaNeta;
            decimal anterior = 0;

            for (int i = 0; i < tasas.Length; i++)
            {
                decimal limite = i < tramos.Length ? tramos[i] - anterior : decimal.MaxValue;
                decimal baseImponible = Math.Min(restante, limite);

                impuesto += baseImponible * tasas[i];
                restante -= baseImponible;
                if (restante <= 0) break;

                anterior = tramos[Math.Min(i, tramos.Length - 1)];
            }

            return Math.Round(impuesto / 12, 2, MidpointRounding.AwayFromZero);
        }

        public static decimal CalcularTotalDescuentosAdicionales(decimal descuentosPension, decimal impuestoRenta, decimal descuentoEssalud, decimal otrosDescuentos)
        {
            return Math.Round(descuentosPension + impuestoRenta + descuentoEssalud + otrosDescuentos, 2, MidpointRounding.AwayFromZero);
        }

        public static decimal CalcularSueldoNeto(decimal totalIngresos, decimal totalDescuentos)
        {
            return Math.Round(totalIngresos - totalDescuentos, 2, MidpointRounding.AwayFromZero);
        }

        public static bool ValidarSueldoMinimo(decimal sueldoNeto, decimal rmv)
        {
            return sueldoNeto >= rmv;
        }
    }

}
