using Nomina.Domain.Entities;
using System;
using Nomina.API.Exceptions;

namespace Nomina.Domain.Rules
{
    public static class ContratoLaboralRules
    {
        private static void Requerido(string valor, string mensaje)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new BusinessException(mensaje);
        }

        private static void Requerido(DateTime? valor, string mensaje)
        {
            if (!valor.HasValue)
                throw new BusinessException(mensaje);
        }

        private static void Validar(bool condicion, string mensaje)
        {
            if (condicion)
                throw new BusinessException(mensaje);
        }

        private static bool EstaEntre(double valor, double min, double max)
        {
            return valor >= min && valor <= max;
        }

        public static void ValidarCamposObligatorios(ContratoLaboral contrato)
        {
            Requerido(contrato.EmpleadoCodigo, "El empleado es obligatorio.");
            Requerido(contrato.TipoContratoCodigo, "El tipo de contrato es obligatorio.");
            Requerido(contrato.ModalidadCodigo, "La modalidad de pago es obligatoria.");
            Requerido(contrato.JornadaCodigo, "La jornada laboral es obligatoria.");
            Requerido(contrato.UsuarioCodigo, "El usuario responsable es obligatorio.");
            Requerido(contrato.ContratoFechaInicio, "La fecha de inicio es obligatoria.");
            Requerido(contrato.ContratoFechaFin, "La fecha de fin es obligatoria.");
        }

        public static bool ContratoProximoAVencer(ContratoLaboral contrato)
        {
            if (!contrato.ContratoFechaFin.HasValue) 
                return false;

            var dias = (contrato.ContratoFechaFin.Value - DateTime.Today).TotalDays;

            return EstaEntre(dias, 0, 15);
        }

        public static void ValidarContratoDuplicado(bool existeContratoVigente)
        {
            Validar(existeContratoVigente, "El empleado ya posee un contrato vigente.");
        }

        public static void ValidarMotivoHistorial(string motivo)
        {
            Requerido(motivo, "Debe ingresar un motivo para la modificación o suspensión.");
        }

        public static void ValidarFechaInicio(ContratoLaboral contrato)
        {
            if (contrato.ContratoFechaInicio.HasValue)
                Validar(
                    contrato.ContratoFechaInicio.Value.Date < DateTime.Today,
                    "La fecha de inicio del contrato no puede ser anterior a la fecha actual."
                );

            if (contrato.ContratoFechaFin.HasValue)
                Validar(
                    contrato.ContratoFechaFin.Value < DateTime.Today,
                    "No se puede modificar un contrato ya finalizado."
                );
        }

        public static void ValidarEdicionPorEstado(string estado)
        {
            Validar(estado?.Trim() != "A", "Solo se pueden editar contratos vigentes.");
        }

        public static void ValidarReactivacion(string? estadoActual, string? nuevoEstado)
        {
            estadoActual = estadoActual?.Trim();
            nuevoEstado = nuevoEstado?.Trim();

            bool permitido =
                (estadoActual == "S" && nuevoEstado == "A") ||
                (estadoActual == "A" && nuevoEstado == "S");

            Validar(!permitido, "Cambio de estado no permitido.");
        }

        public static void ValidarSalarioMinimo(decimal salario, decimal salarioMinimoLegal)
        {
            Validar(salario < salarioMinimoLegal,
                $"El salario no puede ser inferior al salario mínimo legal vigente ({salarioMinimoLegal:C}).");
        }

        public static void ValidarFechas(ContratoLaboral contrato)
        {
            if (contrato.ContratoFechaInicio.HasValue && contrato.ContratoFechaFin.HasValue)
            {
                Validar(contrato.ContratoFechaFin <= contrato.ContratoFechaInicio,
                    "La fecha de fin debe ser mayor que la fecha de inicio.");
            }
        }

        private const int Minimo = 3;

        public static void ValidarPlazoMinimoContrato(ContratoLaboral contrato)
        {
            if (!contrato.ContratoFechaInicio.HasValue || !contrato.ContratoFechaFin.HasValue)
                return;

            var inicio = contrato.ContratoFechaInicio.Value.Date;
            var fin = contrato.ContratoFechaFin.Value.Date;
            var fechaMinimaFin = inicio.AddMonths(Minimo);

            Validar(fin < fechaMinimaFin,
                $"El contrato debe tener un plazo mínimo de {Minimo} meses. " +
                $"La fecha de fin mínima requerida es {fechaMinimaFin:dd/MM/yyyy}.");
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
