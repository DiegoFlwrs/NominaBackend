using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nomina.Domain.Entities;
using Nomina.Domain.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Test.Pruebas
{
    [TestClass]
    public class ContratoLaboralRulesTests
    {
        [TestMethod]
        public void TestValidarSalarioMinimo_SalarioInferior()
        {
            decimal salario = 900m;
            decimal minimo = 1030m;

            var ex = Assert.ThrowsException<ArgumentException>(() =>
                ContratoLaboralRules.ValidarSalarioMinimo(salario, minimo));

            StringAssert.Contains(ex.Message, "El salario no puede ser inferior al salario mínimo legal vigente");
        }

        [TestMethod]
        public void TestValidarCamposObligatorios_CamposVacios()
        {
            var contrato = new ContratoLaboral();

            var ex = Assert.ThrowsException<ArgumentException>(() =>
                ContratoLaboralRules.ValidarCamposObligatorios(contrato));

            Assert.AreEqual("El empleado es obligatorio.", ex.Message);
        }

        [TestMethod]
        public void TestValidarFechas_FechaFinMenorQueInicio()
        {
            var contrato = new ContratoLaboral
            {
                ContratoFechaInicio = DateTime.Today.AddDays(5),
                ContratoFechaFin = DateTime.Today
            };

            var ex = Assert.ThrowsException<ArgumentException>(() =>
                ContratoLaboralRules.ValidarFechas(contrato));

            Assert.AreEqual("La fecha de fin debe ser mayor que la fecha de inicio.", ex.Message);
        }

        [TestMethod]
        public void TestValidarFechaInicio_FechaInicioPasada()
        {
            var contrato = new ContratoLaboral
            {
                ContratoFechaInicio = DateTime.Today.AddDays(-1)
            };

            var ex = Assert.ThrowsException<ArgumentException>(() =>
                ContratoLaboralRules.ValidarFechaInicio(contrato));

            Assert.AreEqual("La fecha de inicio del contrato no puede ser anterior a la fecha actual.", ex.Message);
        }

        [TestMethod]
        public void TestValidarContratoDuplicado_ExisteContratoVigente()
        {
            var ex = Assert.ThrowsException<InvalidOperationException>(() =>
                ContratoLaboralRules.ValidarContratoDuplicado(true));

            Assert.AreEqual("El empleado ya posee un contrato vigente.", ex.Message);
        }

        [TestMethod]
        public void TestValidarMotivoHistorial_MotivoVacio()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() =>
                ContratoLaboralRules.ValidarMotivoHistorial(""));

            Assert.AreEqual("Debe ingresar un motivo para la modificación o suspensión.", ex.Message);
        }

        [TestMethod]
        public void TestValidarEdicionPorEstado_EstadoInactivo()
        {
            var ex = Assert.ThrowsException<InvalidOperationException>(() =>
                ContratoLaboralRules.ValidarEdicionPorEstado("I"));

            Assert.AreEqual("Solo se pueden editar contratos vigentes.", ex.Message);
        }

        [TestMethod]
        public void TestValidarReactivacion_CambioNoPermitido()
        {
            var ex = Assert.ThrowsException<InvalidOperationException>(() =>
                ContratoLaboralRules.ValidarReactivacion("A", "A"));

            Assert.AreEqual("Cambio de estado no permitido.", ex.Message);
        }

        [TestMethod]
        public void TestContratoProximoAVencer_ContratoConMenosDe15Dias()
        {
            var contrato = new ContratoLaboral
            {
                ContratoFechaFin = DateTime.Today.AddDays(10)
            };

            bool resultado = ContratoLaboralRules.ContratoProximoAVencer(contrato);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void TestContratoProximoAVencer_ContratoConMasDe15Dias()
        {
            var contrato = new ContratoLaboral
            {
                ContratoFechaFin = DateTime.Today.AddDays(30)
            };

            bool resultado = ContratoLaboralRules.ContratoProximoAVencer(contrato);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void TestValidarSalarioMinimo_SalarioValido()
        {
            decimal salario = 1500m;
            decimal minimo = 1030m;

            try
            {
                ContratoLaboralRules.ValidarSalarioMinimo(salario, minimo);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No se esperaba excepción, pero se lanzó: {ex.Message}");
            }
        }

        [TestMethod]
        public void TestValidarFechas_FechaFinMayorQueInicio()
        {
            var contrato = new ContratoLaboral
            {
                ContratoFechaInicio = DateTime.Today,
                ContratoFechaFin = DateTime.Today.AddDays(10)
            };

            try
            {
                ContratoLaboralRules.ValidarFechas(contrato);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No se esperaba excepción, pero se lanzó: {ex.Message}");
            }
        }

        [TestMethod]
        public void TestValidarFechaInicio_FechaInicioCorrecta()
        {
            var contrato = new ContratoLaboral
            {
                ContratoFechaInicio = DateTime.Today.AddDays(1)
            };

            try
            {
                ContratoLaboralRules.ValidarFechaInicio(contrato);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No se esperaba excepción, pero se lanzó: {ex.Message}");
            }
        }

        [TestMethod]
        public void TestValidarContratoDuplicado_NoExisteContratoVigente()
        {
            try
            {
                ContratoLaboralRules.ValidarContratoDuplicado(false);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No se esperaba excepción, pero se lanzó: {ex.Message}");
            }
        }

        [TestMethod]
        public void TestValidarMotivoHistorial_MotivoValido()
        {
            try
            {
                ContratoLaboralRules.ValidarMotivoHistorial("Cambio de salario por desempeño.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"No se esperaba excepción, pero se lanzó: {ex.Message}");
            }
        }

        [TestMethod]
        public void TestValidarEdicionPorEstado_EstadoActivo()
        {
            try
            {
                ContratoLaboralRules.ValidarEdicionPorEstado("A");
            }
            catch (Exception ex)
            {
                Assert.Fail($"No se esperaba excepción, pero se lanzó: {ex.Message}");
            }
        }

        [TestMethod]
        public void TestValidarReactivacion_CambioPermitido()
        {
            try
            {
                ContratoLaboralRules.ValidarReactivacion("S", "A");
            }
            catch (Exception ex)
            {
                Assert.Fail($"No se esperaba excepción, pero se lanzó: {ex.Message}");
            }
        }
    }
}
