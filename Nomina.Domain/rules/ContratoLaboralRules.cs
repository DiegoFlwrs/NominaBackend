using Nomina.Domain.Entities;
using System;
using Nomina.API.Exceptions;

namespace Nomina.Domain.Rules
{
    public static class ContratoLaboralRules
    {
        public static void ValidarCamposObligatorios(ContratoLaboral contrato)
        {
            if (string.IsNullOrWhiteSpace(contrato.EmpleadoCodigo))
                throw new BusinessException("El empleado es obligatorio.");

            if (string.IsNullOrWhiteSpace(contrato.TipoContratoCodigo))
                throw new BusinessException("El tipo de contrato es obligatorio.");

            if (string.IsNullOrWhiteSpace(contrato.ModalidadCodigo))
                throw new BusinessException("La modalidad de pago es obligatoria.");

            if (string.IsNullOrWhiteSpace(contrato.JornadaCodigo))
                throw new BusinessException("La jornada laboral es obligatoria.");

            if (string.IsNullOrWhiteSpace(contrato.UsuarioCodigo))
                throw new BusinessException("El usuario responsable es obligatorio.");

            if (!contrato.ContratoFechaInicio.HasValue)
                throw new BusinessException("La fecha de inicio es obligatoria.");

            if (!contrato.ContratoFechaFin.HasValue)
                throw new BusinessException("La fecha de fin es obligatoria.");
        }

        public static bool ContratoProximoAVencer(ContratoLaboral contrato)
        {
            if (!contrato.ContratoFechaFin.HasValue) return false;
            var diasRestantes = (contrato.ContratoFechaFin.Value - DateTime.Today).TotalDays;
            return diasRestantes <= 15 && diasRestantes >= 0;
            throw new BusinessException("El contrato del empleado esta proximo a vencer (menos de 15 dias)");
        }

        public static void ValidarContratoDuplicado(bool existeContratoVigente)
        {
            if (existeContratoVigente)
                throw new BusinessException("El empleado ya posee un contrato vigente.");
        }
        public static void ValidarMotivoHistorial(string motivo)
        {
            if (string.IsNullOrWhiteSpace(motivo))
                throw new BusinessException("Debe ingresar un motivo para la modificación o suspensión.");
        }
        public static void ValidarFechaInicio(ContratoLaboral contrato)
        {
            if (contrato.ContratoFechaInicio.HasValue && contrato.ContratoFechaInicio.Value.Date < DateTime.Today)
                throw new BusinessException("La fecha de inicio del contrato no puede ser anterior a la fecha actual.");
            if (contrato.ContratoFechaFin.HasValue && contrato.ContratoFechaFin.Value < DateTime.Today)
                throw new BusinessException("No se puede modificar un contrato ya finalizado.");
        }
        public static void ValidarEdicionPorEstado(string estado)
        {
            if (estado == null || estado.Trim() != "A")
                throw new BusinessException("Solo se pueden editar contratos vigentes.");
        }

        public static void ValidarReactivacion(string? estadoActual, string? nuevoEstado)
        {
            estadoActual = estadoActual?.Trim();
            nuevoEstado = nuevoEstado?.Trim();
            if (estadoActual == "S" && nuevoEstado == "A")
                return;
            if (estadoActual == "A" && nuevoEstado == "S")
                return;
            throw new BusinessException("Cambio de estado no permitido.");
        }

        public static void ValidarSalarioMinimo(decimal salario, decimal salarioMinimoLegal)
        {
            if (salario < salarioMinimoLegal)
                throw new BusinessException($"El salario no puede ser inferior al salario mínimo legal vigente ({salarioMinimoLegal:C}).");
        }

        public static void ValidarFechas(ContratoLaboral contrato)
        {
            if (contrato.ContratoFechaInicio.HasValue &&
                contrato.ContratoFechaFin.HasValue &&
                contrato.ContratoFechaFin <= contrato.ContratoFechaInicio) 
            {
                throw new BusinessException("La fecha de fin debe ser mayor que la fecha de inicio.");
            }
        }

        private const int Minimo = 3;

        public static void ValidarPlazoMinimoContrato(ContratoLaboral contrato)
        {
            if (contrato.ContratoFechaInicio.HasValue && contrato.ContratoFechaFin.HasValue)
            {
                var fechaInicio = contrato.ContratoFechaInicio.Value.Date;
                var fechaFin = contrato.ContratoFechaFin.Value.Date;
                var fechaMinimaFin = fechaInicio.AddMonths(Minimo);
                if (fechaFin < fechaMinimaFin)
                {
                    throw new BusinessException(
                        $"El contrato debe tener un plazo mínimo de {Minimo} meses. " +
                        $"La fecha de fin mínima requerida es {fechaMinimaFin.ToShortDateString()}."
                    );
                }
            }
        }

        public static void ValidarCoherenciaGeneral(ContratoLaboral contrato)
        {
            ValidarCamposObligatorios(contrato);
            ValidarFechas(contrato);
            ValidarPlazoMinimoContrato(contrato);
            ValidarSalarioMinimo(contrato.ContratoSalario, 1130m);
        }
    }
}
