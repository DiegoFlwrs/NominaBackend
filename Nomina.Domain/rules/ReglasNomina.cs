using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.rules
{
    public static class ReglasNomina
{
    public static decimal CalcularAsignacionFamiliar(bool tieneHijos, decimal rmv)
        => tieneHijos ? rmv * 0.10m : 0m;

    public static decimal CalcularPagoHorasExtras(decimal salarioBase, decimal horasExtras)
    {
        if (horasExtras <= 0) return 0m;
        decimal tarifaHora = salarioBase / 240m;

        decimal horasNormales = Math.Min(horasExtras, 2);
        decimal horasAdicionales = Math.Max(horasExtras - 2, 0);

        decimal pagoNormales = horasNormales * tarifaHora * 1.25m;
        decimal pagoAdicionales = horasAdicionales * tarifaHora * 1.35m;

        return pagoNormales + pagoAdicionales;
    }

    public static decimal CalcularTotalIngresos(decimal sueldoBasico, decimal asignacionFamiliar, decimal pagoHorasExtras, decimal bonificacion)
        => sueldoBasico + asignacionFamiliar + pagoHorasExtras + bonificacion;

    public static decimal CalcularEssalud(decimal sueldoBruto) => sueldoBruto * 0.09m;


    public static decimal CalcularDescuentoPension(string tipoPension, decimal sueldoBruto, string? afp = null)
    {
        tipoPension = tipoPension?.ToUpper() ?? "";
        if (tipoPension == "ONP")
            return sueldoBruto * 0.13m;
        else if (tipoPension == "AFP")
        {
            decimal aporte = sueldoBruto * 0.10m;
            decimal primaSeguro = sueldoBruto * 0.015m;
            decimal comision = sueldoBruto * 0.015m;
            return aporte + primaSeguro + comision;
        }
        return 0m;
    }

    public static decimal CalcularRentaQuinta(decimal sueldoAnual, decimal UIT)
    {
        decimal deduccion = UIT * 7;
        decimal rentaNeta = sueldoAnual - deduccion;
        if (rentaNeta <= 0) return 0m;

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

        return impuesto / 12;
    }

    public static decimal CalcularTotalDescuentosAdicionales(params decimal[] descuentos)
        => descuentos.Sum();

    public static decimal CalcularSueldoNeto(decimal totalIngresos, decimal totalDescuentos)
        => totalIngresos - totalDescuentos;

    public static bool ValidarSueldoMinimo(decimal sueldoNeto, decimal rmv)
        => sueldoNeto >= rmv;
}

}
