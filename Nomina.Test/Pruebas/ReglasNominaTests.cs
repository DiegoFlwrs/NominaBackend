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
            decimal resultadoEsperado = 102.5m;
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
            decimal resultadoEsperado = (salarioBase / 240m) * horasExtras * 1.25m;
            decimal resultado = ReglasNomina.CalcularPagoHorasExtras(salarioBase, horasExtras);
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void TestCalcularPagoHorasExtrasCincoHoras()
        {
            decimal salarioBase = 2400m;
            decimal horasExtras = 5m;
            decimal tarifa = salarioBase / 240m;
            decimal resultadoEsperado = (2m * tarifa * 1.25m) + (3m * tarifa * 1.35m);
            decimal resultado = ReglasNomina.CalcularPagoHorasExtras(salarioBase, horasExtras);
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void TestCalcularPagoHorasExtrasCeroHoras()
        {
            decimal salarioBase = 2400m;
            decimal resultadoEsperado = 0m;
            decimal resultado = ReglasNomina.CalcularPagoHorasExtras(salarioBase, 0m);
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void TestCalcularTotalIngresos()
        {
            decimal resultadoEsperado = 1850m;
            decimal resultado = ReglasNomina.CalcularTotalIngresos(1500m, 100m, 200m, 50m);
            Assert.AreEqual(resultadoEsperado, resultado);
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
            decimal resultadoEsperado = 260m;
            decimal resultado = ReglasNomina.CalcularDescuentoPension("ONP", 2000m);
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void TestCalcularDescuentoPensionAFP()
        {
            decimal sueldoBruto = 2000m;
            decimal resultadoEsperado = (sueldoBruto * 0.10m) + (sueldoBruto * 0.015m) + (sueldoBruto * 0.015m);
            decimal resultado = ReglasNomina.CalcularDescuentoPension("AFP", sueldoBruto);
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void TestCalcularDescuentoPensionTipoInvalido()
        {
            decimal resultadoEsperado = 0m;
            decimal resultado = ReglasNomina.CalcularDescuentoPension("NINGUNO", 2000m);
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void TestCalcularRentaQuintaSueldoBajo()
        {
            decimal resultadoEsperado = 0m;
            decimal resultado = ReglasNomina.CalcularRentaQuinta(10000m, 4950m);
            Assert.AreEqual(resultadoEsperado, resultado);
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
            decimal resultadoEsperado = 175m;
            decimal resultado = ReglasNomina.CalcularTotalDescuentosAdicionales(100m, 50m, 25m);
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void TestCalcularSueldoNeto()
        {
            decimal resultadoEsperado = 2000m;
            decimal resultado = ReglasNomina.CalcularSueldoNeto(2500m, 500m);
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void TestValidarSueldoMinimoMayorIgualRemuneracion()
        {
            bool resultadoEsperado = true;
            bool resultado = ReglasNomina.ValidarSueldoMinimo(1200m, 1025m);
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void TestValidarSueldoMinimoMenorRemuneracion()
        {
            bool resultadoEsperado = false;
            bool resultado = ReglasNomina.ValidarSueldoMinimo(900m, 1025m);
            Assert.AreEqual(resultadoEsperado, resultado);
        }
    }
}
