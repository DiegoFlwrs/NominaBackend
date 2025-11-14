using Xunit;
using Moq;
using Nomina.Application.Services;
using Nomina.Domain.Interfaces;
using Nomina.Domain.ReadModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
 
namespace Nomina.Domain.Tests
{
    public class ReporteNominaServiceTests
    {
        private readonly Mock<IReporteNominaRepository> _mockRepo;
        private readonly ReporteNominaService _service;

        public ReporteNominaServiceTests()
        {
            _mockRepo = new Mock<IReporteNominaRepository>();
            _service = new ReporteNominaService(_mockRepo.Object);

            _mockRepo.Setup(r => r.ObtenerReporteNominaAsync(
                It.IsAny<DateTime>(), It.IsAny<DateTime>(),
                It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>()))
                .ReturnsAsync(new List<ReporteNominaView>());
        }

        [Fact]
        public async Task TestFechaInicioPosteriorAFechaFin()
        {
            var fechaInicioInvalida = new DateTime(2025, 10, 1);
            var fechaFinInvalida = new DateTime(2025, 9, 30);

            await Assert.ThrowsAsync<ArgumentException>(() =>
                _service.GenerarReporteAsync(
                    fechaInicioInvalida, fechaFinInvalida, null, null, null));
        }

        [Fact]
        public async Task TestFechasCorrectas()
        {
            var fechaIniciovalida = new DateTime(2025, 10, 1);
            var fechaFinvalida = new DateTime(2025, 10, 31);

            var exception = await Record.ExceptionAsync(() =>
                _service.GenerarReporteAsync(
                    fechaIniciovalida, fechaFinvalida, null, null, null));

            Assert.Null(exception);
        }

        [Fact]
        public async Task GenerarReportePdfAsync_SinDatos_DebeLanzarInvalidOperationException()
        {

            var fechaInicio = new DateTime(2025, 1, 1);
            var fechaFin = new DateTime(2025, 1, 31);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.GenerarReportePdfAsync(
                    fechaInicio, fechaFin, null, null, null));
        }
    }
}