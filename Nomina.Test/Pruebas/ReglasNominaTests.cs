using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nomina.Domain.rules;

namespace Nomina.Test.Pruebas
{
    [TestClass]
    public class ReglasNominaTests
    {
        [TestMethod]
        public void TestCalcularAsignacionFamiliarConHijos()
        {
            decimal sueldoMinimo = 1025m;
            decimal resultadoEsperado = 102.50m;
            decimal resultado = ReglasNomina.CalcularAsignacionFamiliar(true, sueldoMinimo);
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void TestCalcularAsignacionFamiliarSinHijos()
        {
            decimal sueldoMinimo = 1025m;
            decimal resultadoEsperado = 0m;
            decimal resultado = ReglasNomina.CalcularAsignacionFamiliar(false, sueldoMinimo);
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void TestCalcularPagoHorasExtrasDosHoras()
        {
            decimal salarioBase = 2400m;
            decimal horasExtras = 2m;
            decimal tarifa = salarioBase / 240m;
            decimal resultadoEsperado = Math.Round(tarifa * 2m * 1.25m, 2);
            decimal resultado = ReglasNomina.CalcularPagoHorasExtras(salarioBase, horasExtras);
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void TestCalcularPagoHorasExtrasCincoHoras()
        {
            decimal salarioBase = 2400m;
            decimal horasExtras = 5m;
            decimal tarifa = salarioBase / 240m;
            decimal resultadoEsperado = Math.Round(2m * tarifa * 1.25m + 3m * tarifa * 1.35m, 2);
            decimal resultado = ReglasNomina.CalcularPagoHorasExtras(salarioBase, horasExtras);
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void TestCalcularPagoHorasExtrasCeroHoras()
        {
            decimal resultado = ReglasNomina.CalcularPagoHorasExtras(2400m, 0m);
            Assert.AreEqual(0m, resultado);
        }

        [TestMethod]
        public void TestCalcularSueldoBruto()
        {
            decimal resultado = ReglasNomina.CalcularSueldoBruto(1500m, 100m, 200m, 50m);
            Assert.AreEqual(1850m, resultado);
        }

        [TestMethod]
        public void TestCalcularEssalud()
        {
            decimal resultadoEsperado = 180m;
            decimal resultado = ReglasNomina.CalcularEssalud(2000m);
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void TestCalcularDescuentoPensionONP()
        {
            decimal resultado = ReglasNomina.CalcularDescuentoPension("ONP", 2000m, 0.13m);
            Assert.AreEqual(260m, resultado);
        }

        [TestMethod]
        public void TestCalcularDescuentoPensionAFP()
        {
            decimal sueldoBruto = 2000m;
            decimal porcentajeSeguro = 0.015m;
            decimal resultadoEsperado = Math.Round(sueldoBruto * 0.10m + sueldoBruto * porcentajeSeguro, 2);
            decimal resultado = ReglasNomina.CalcularDescuentoPension("AFP", sueldoBruto, porcentajeSeguro);
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void TestCalcularDescuentoPensionTipoInvalido()
        {
            decimal resultado = ReglasNomina.CalcularDescuentoPension("NINGUNO", 2000m, 0.13m);
            Assert.AreEqual(0m, resultado);
        }

        [TestMethod]
        public void TestCalcularRentaQuintaSueldoBajo()
        {
            decimal resultado = ReglasNomina.CalcularRentaQuinta(10000m, 4950m);
            Assert.AreEqual(0m, resultado);
        }

        [TestMethod]
        public void TestCalcularRentaQuintaSueldoAlto()
        {
            decimal resultado = ReglasNomina.CalcularRentaQuinta(200000m, 4950m);
            Assert.IsTrue(resultado > 0);
        }

        [TestMethod]
        public void TestCalcularTotalDescuentosAdicionales()
        {
            decimal resultado = ReglasNomina.CalcularTotalDescuentosAdicionales(100m, 50m, 25m, 0m);
            Assert.AreEqual(175m, resultado);
        }

        [TestMethod]
        public void TestCalcularSueldoNeto()
        {
            decimal resultado = ReglasNomina.CalcularSueldoNeto(2500m, 500m);
            Assert.AreEqual(2000m, resultado);
        }

        [TestMethod]
        public void TestValidarSueldoMinimoMayorIgualRemuneracion()
        {
            bool resultado = ReglasNomina.ValidarSueldoMinimo(1200m, 1025m);
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void TestValidarSueldoMinimoMenorRemuneracion()
        {
            bool resultado = ReglasNomina.ValidarSueldoMinimo(900m, 1025m);
            Assert.IsFalse(resultado);
        }
    }
}
