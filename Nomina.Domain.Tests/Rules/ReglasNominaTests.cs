using Nomina.Domain.rules;
using Xunit;

namespace Nomina.Domain.Tests.Rules
{
    public class ReglasNominaTests
    {
        [Fact]
        public void CalcularAsignacionFamiliar_ConHijos()
        {
            decimal resultado = ReglasNomina.CalcularAsignacionFamiliar(true, 1025m);
            Assert.Equal(102.5m, resultado);
        }

        [Fact]
        public void CalcularAsignacionFamiliar_SinHijos()
        {
            decimal resultado = ReglasNomina.CalcularAsignacionFamiliar(false, 1025m);
            Assert.Equal(0m, resultado);
        }

        [Fact]
        public void CalcularPagoHorasExtras_SinHorasExtras()
        {
            decimal resultado = ReglasNomina.CalcularPagoHorasExtras(1200m, 0);
            Assert.Equal(0m, resultado);
        }

        [Fact]
        public void CalcularPagoHorasExtras_ConHorasNormales()
        {
            decimal resultado = ReglasNomina.CalcularPagoHorasExtras(1200m, 2);
            decimal tarifaHora = 1200m / 240m;
            decimal esperado = 2 * tarifaHora * 1.25m;
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void CalcularPagoHorasExtras_ConHorasAdicionales()
        {
            decimal resultado = ReglasNomina.CalcularPagoHorasExtras(1200m, 4);
            decimal tarifaHora = 1200m / 240m;
            decimal esperado = (2 * tarifaHora * 1.25m) + (2 * tarifaHora * 1.35m);
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void CalcularTotalIngresos()
        {
            decimal resultado = ReglasNomina.CalcularTotalIngresos(1000m, 100m, 50m, 200m);
            Assert.Equal(1350m, resultado);
        }

        [Fact]
        public void CalcularEssalud()
        {
            decimal resultado = ReglasNomina.CalcularEssalud(2000m);
            Assert.Equal(180m, resultado);
        }

        [Fact]
        public void CalcularDescuentoPension_ONP()
        {
            decimal resultado = ReglasNomina.CalcularDescuentoPension("ONP", 2000m);
            Assert.Equal(260m, resultado);
        }

        [Fact]
        public void CalcularDescuentoPension_AFP()
        {
            decimal resultado = ReglasNomina.CalcularDescuentoPension("AFP", 2000m);
            decimal esperado = (2000m * 0.10m) + (2000m * 0.015m) + (2000m * 0.015m);
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void CalcularDescuentoPension_OtroTipo()
        {
            decimal resultado = ReglasNomina.CalcularDescuentoPension("NINGUNO", 2000m);
            Assert.Equal(0m, resultado);
        }

        [Fact]
        public void CalcularRentaQuinta_SueldoMenorADeduccion()
        {
            decimal resultado = ReglasNomina.CalcularRentaQuinta(50000m, 5150m);
            Assert.Equal(0m, resultado);
        }

        [Fact]
        public void CalcularRentaQuinta_SueldoMayorADeduccion()
        {
            decimal resultado = ReglasNomina.CalcularRentaQuinta(150000m, 5150m);
            Assert.True(resultado > 0);
        }

        [Fact]
        public void CalcularTotalDescuentosAdicionales()
        {
            decimal resultado = ReglasNomina.CalcularTotalDescuentosAdicionales(100m, 50m, 25m);
            Assert.Equal(175m, resultado);
        }

        [Fact]
        public void CalcularSueldoNeto()
        {
            decimal resultado = ReglasNomina.CalcularSueldoNeto(2000m, 300m);
            Assert.Equal(1700m, resultado);
        }

        [Fact]
        public void ValidarSueldoMinimo_SueldoMayorIgual()
        {
            bool resultado = ReglasNomina.ValidarSueldoMinimo(1200m, 1025m);
            Assert.True(resultado);
        }

        [Fact]
        public void ValidarSueldoMinimo_SueldoMenor()
        {
            bool resultado = ReglasNomina.ValidarSueldoMinimo(900m, 1025m);
            Assert.False(resultado);
        }
    }
}
