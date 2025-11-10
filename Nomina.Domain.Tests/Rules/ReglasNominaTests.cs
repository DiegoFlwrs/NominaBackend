using Nomina.Domain.rules;
using Xunit;

namespace Nomina.Domain.Tests.Rules
{
    public class ReglasNominaTests
    {
        [Fact]
        public void TestCalcularAsignacionFamiliarConHijos()
        {
            decimal sueldoMinimo = 1025m;
            decimal resultadoEsperado = 102.5m;
            decimal resultado = ReglasNomina.CalcularAsignacionFamiliar(true, sueldoMinimo);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void TestCalcularAsignacionFamiliarSinHijos()
        {
            decimal sueldoMinimo = 1025m;
            decimal resultadoEsperado = 0m;
            decimal resultado = ReglasNomina.CalcularAsignacionFamiliar(false, sueldoMinimo);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void TestCalcularPagoHorasExtrasDosHoras()
        {
            decimal salarioBase = 2400m;
            decimal horasExtras = 2m;
            decimal resultadoEsperado = (salarioBase / 240m) * horasExtras * 1.25m;
            decimal resultado = ReglasNomina.CalcularPagoHorasExtras(salarioBase, horasExtras);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void TestCalcularPagoHorasExtrasCincoHoras()
        {
            decimal salarioBase = 2400m;
            decimal horasExtras = 5m;
            decimal tarifa = salarioBase / 240m;
            decimal resultadoEsperado = (2m * tarifa * 1.25m) + (3m * tarifa * 1.35m);
            decimal resultado = ReglasNomina.CalcularPagoHorasExtras(salarioBase, horasExtras);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void TestCalcularPagoHorasExtrasCeroHoras()
        {
            decimal salarioBase = 2400m;
            decimal resultadoEsperado = 0m;
            decimal resultado = ReglasNomina.CalcularPagoHorasExtras(salarioBase, 0m);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void TestCalcularTotalIngresos()
        {
            decimal resultadoEsperado = 1850m;
            decimal resultado = ReglasNomina.CalcularTotalIngresos(1500m, 100m, 200m, 50m);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void TestCalcularEssalud()
        {
            decimal resultadoEsperado = 180m;
            decimal resultado = ReglasNomina.CalcularEssalud(2000m);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void TestCalcularDescuentoPensionONP()
        {
            decimal resultadoEsperado = 260m;
            decimal resultado = ReglasNomina.CalcularDescuentoPension("ONP", 2000m);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void TestCalcularDescuentoPensionAFP()
        {
            decimal sueldoBruto = 2000m;
            decimal resultadoEsperado = (sueldoBruto * 0.10m) + (sueldoBruto * 0.015m) + (sueldoBruto * 0.015m);
            decimal resultado = ReglasNomina.CalcularDescuentoPension("AFP", sueldoBruto);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void TestCalcularDescuentoPensionTipoInvalido()
        {
            decimal resultadoEsperado = 0m;
            decimal resultado = ReglasNomina.CalcularDescuentoPension("NINGUNO", 2000m);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void TestCalcularRentaQuintaSueldoBajo()
        {
            decimal resultadoEsperado = 0m;
            decimal resultado = ReglasNomina.CalcularRentaQuinta(10000m, 4950m);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void TestCalcularRentaQuintaSueldoAlto()
        {
            decimal resultado = ReglasNomina.CalcularRentaQuinta(200000m, 4950m);
            Assert.True(resultado > 0);
        }

        [Fact]
        public void TestCalcularTotalDescuentosAdicionales()
        {
            decimal resultadoEsperado = 175m;
            decimal resultado = ReglasNomina.CalcularTotalDescuentosAdicionales(100m, 50m, 25m);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void TestCalcularSueldoNeto()
        {
            decimal resultadoEsperado = 2000m;
            decimal resultado = ReglasNomina.CalcularSueldoNeto(2500m, 500m);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void TestValidarSueldoMinimoMayorIgualRemuneracion()
        {
            bool resultadoEsperado = true;
            bool resultado = ReglasNomina.ValidarSueldoMinimo(1200m, 1025m);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void TestValidarSueldoMinimoMenorRemuneracion()
        {
            bool resultadoEsperado = false;
            bool resultado = ReglasNomina.ValidarSueldoMinimo(900m, 1025m);
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
