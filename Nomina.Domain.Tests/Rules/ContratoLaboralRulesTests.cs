using Nomina.Domain.Entities;
using Nomina.Domain.Rules;
using System;
using Xunit;

namespace Nomina.Domain.Tests.Rules
{
    public class ContratoLaboralRulesTests
    {
        [Fact]
        public void ValidarSalarioMinimo_SalarioInferior()
        {
            decimal salario = 900m;
            decimal minimo = 1025m;

            var ex = Assert.Throws<ArgumentException>(() =>
                ContratoLaboralRules.ValidarSalarioMinimo(salario, minimo));
            Assert.Contains("El salario no puede ser inferior al salario mínimo legal vigente", ex.Message);
        }

        [Fact]
        public void ValidarCamposObligatorios_CamposVacios()
        {
            var contrato = new ContratoLaboral();

            var ex = Assert.Throws<ArgumentException>(() =>
                ContratoLaboralRules.ValidarCamposObligatorios(contrato));
            Assert.Equal("El empleado es obligatorio.", ex.Message);
        }

        [Fact]
        public void ValidarFechas_FechaFinMenorQueInicio()
        {
            var contrato = new ContratoLaboral
            {
                ContratoFechaInicio = DateTime.Today.AddDays(5),
                ContratoFechaFin = DateTime.Today
            };

            var ex = Assert.Throws<ArgumentException>(() =>
                ContratoLaboralRules.ValidarFechas(contrato));
            Assert.Equal("La fecha de fin debe ser mayor que la fecha de inicio.", ex.Message);
        }

        [Fact]
        public void ValidarFechaInicio_FechaInicioPasada()
        {
            var contrato = new ContratoLaboral
            {
                ContratoFechaInicio = DateTime.Today.AddDays(-1)
            };

            var ex = Assert.Throws<ArgumentException>(() =>
                ContratoLaboralRules.ValidarFechaInicio(contrato));
            Assert.Equal("La fecha de inicio del contrato no puede ser anterior a la fecha actual.", ex.Message);
        }

        [Fact]
        public void ValidarContratoDuplicado_ExisteContratoVigente()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
                ContratoLaboralRules.ValidarContratoDuplicado(true));
            Assert.Equal("El empleado ya posee un contrato vigente.", ex.Message);
        }

        [Fact]
        public void ValidarMotivoHistorial_MotivoVacio()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                ContratoLaboralRules.ValidarMotivoHistorial(""));
            Assert.Equal("Debe ingresar un motivo para la modificación o suspensión.", ex.Message);
        }

        [Fact]
        public void ValidarEdicionPorEstado_EstadoInactivo()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
                ContratoLaboralRules.ValidarEdicionPorEstado("I"));
            Assert.Equal("Solo se pueden editar contratos vigentes.", ex.Message);
        }

        [Fact]
        public void ValidarReactivacion_CambioNoPermitido()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
                ContratoLaboralRules.ValidarReactivacion("A", "A"));
            Assert.Equal("Cambio de estado no permitido.", ex.Message);
        }

        [Fact]
        public void ContratoProximoAVencer_ContratoConMenosDe15Dias()
        {
            var contrato = new ContratoLaboral
            {
                ContratoFechaFin = DateTime.Today.AddDays(10)
            };
            var resultado = ContratoLaboralRules.ContratoProximoAVencer(contrato);
            Assert.True(resultado);
        }

        [Fact]
        public void ContratoProximoAVencer_ContratoConMasDe15Dias()
        {
            var contrato = new ContratoLaboral
            {
                ContratoFechaFin = DateTime.Today.AddDays(30)
            };
            var resultado = ContratoLaboralRules.ContratoProximoAVencer(contrato);
            Assert.False(resultado);
        }

        [Fact]
        public void ValidarSalarioMinimo_SalarioValido()
        {
            decimal salario = 1500m;
            decimal minimo = 1025m;
            var ex = Record.Exception(() =>
                ContratoLaboralRules.ValidarSalarioMinimo(salario, minimo));
            Assert.Null(ex);
        }

        [Fact]
        public void ValidarFechas_FechaFinMayorQueInicio()
        {
            var contrato = new ContratoLaboral
            {
                ContratoFechaInicio = DateTime.Today,
                ContratoFechaFin = DateTime.Today.AddDays(10)
            };
            var ex = Record.Exception(() =>
                ContratoLaboralRules.ValidarFechas(contrato));
            Assert.Null(ex);
        }

        [Fact]
        public void ValidarFechaInicio_FechaInicioCorrecta()
        {
            var contrato = new ContratoLaboral
            {
                ContratoFechaInicio = DateTime.Today.AddDays(1)
            };
            var ex = Record.Exception(() =>
                ContratoLaboralRules.ValidarFechaInicio(contrato));
            Assert.Null(ex);
        }

        [Fact]
        public void ValidarContratoDuplicado_NoExisteContratoVigente()
        {
            var ex = Record.Exception(() =>
                ContratoLaboralRules.ValidarContratoDuplicado(false));
            Assert.Null(ex);
        }

        [Fact]
        public void ValidarMotivoHistorial_MotivoValido()
        {
            var ex = Record.Exception(() =>
                ContratoLaboralRules.ValidarMotivoHistorial("Cambio de salario por desempeño."));
            Assert.Null(ex);
        }

        [Fact]
        public void ValidarEdicionPorEstado_EstadoActivo()
        {
            var ex = Record.Exception(() =>
                ContratoLaboralRules.ValidarEdicionPorEstado("A"));
            Assert.Null(ex);
        }

        [Fact]
        public void ValidarReactivacion_CambioPermitido()
        {
            var ex = Record.Exception(() =>
                ContratoLaboralRules.ValidarReactivacion("S", "A"));
            Assert.Null(ex);
        }
    }
}
