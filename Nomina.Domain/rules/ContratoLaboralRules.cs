using Nomina.Domain.Entities;
using System;

namespace Nomina.Domain.Rules
{
    public static class ContratoLaboralRules
    {
        public static void ValidarCamposObligatorios(ContratoLaboral contrato)
        {
            if (string.IsNullOrWhiteSpace(contrato.EmpleadoCodigo))
                throw new ArgumentException("El empleado es obligatorio.");

            if (string.IsNullOrWhiteSpace(contrato.TipoContratoCodigo))
                throw new ArgumentException("El tipo de contrato es obligatorio.");

            if (string.IsNullOrWhiteSpace(contrato.ModalidadCodigo))
                throw new ArgumentException("La modalidad de pago es obligatoria.");

            if (string.IsNullOrWhiteSpace(contrato.JornadaCodigo))
                throw new ArgumentException("La jornada laboral es obligatoria.");

            if (string.IsNullOrWhiteSpace(contrato.UsuarioCodigo))
                throw new ArgumentException("El usuario responsable es obligatorio.");

            if (!contrato.ContratoFechaInicio.HasValue)
                throw new ArgumentException("La fecha de inicio es obligatoria.");

            if (!contrato.ContratoFechaFin.HasValue)
                throw new ArgumentException("La fecha de fin es obligatoria.");
        }

        public static bool ContratoProximoAVencer(ContratoLaboral contrato)
        {
            if (!contrato.ContratoFechaFin.HasValue) return false;
            var diasRestantes = (contrato.ContratoFechaFin.Value - DateTime.Today).TotalDays;
            return diasRestantes <= 15 && diasRestantes >= 0;
        }

        public static void ValidarContratoDuplicado(bool existeContratoVigente)
        {
            if (existeContratoVigente)
                throw new InvalidOperationException("El empleado ya posee un contrato vigente.");
        }
        public static void ValidarMotivoHistorial(string motivo)
        {
            if (string.IsNullOrWhiteSpace(motivo))
                throw new ArgumentException("Debe ingresar un motivo para la modificación o suspensión.");
        }
        public static void ValidarFechaInicio(ContratoLaboral contrato)
        {
            if (contrato.ContratoFechaInicio.HasValue && contrato.ContratoFechaInicio.Value < DateTime.Today)
                throw new ArgumentException("La fecha de inicio no puede ser anterior a la fecha actual.");
        }
        public static void ValidarEdicionPorEstado(string estado)
        {
            if (estado != "A") 
                throw new InvalidOperationException("Solo se pueden editar contratos vigentes.");
        }

        public static void ValidarReactivacion(string estadoActual, string motivo)
        {
            if (estadoActual != "S")
                throw new InvalidOperationException("Solo los contratos suspendidos pueden reactivarse.");

            if (string.IsNullOrWhiteSpace(motivo))
                throw new ArgumentException("Debe indicar un motivo de reactivación.");
        }

        public static void ValidarSalarioMinimo(decimal salario, decimal salarioMinimoLegal)
        {
            if (salario < salarioMinimoLegal)
                throw new ArgumentException($"El salario no puede ser inferior al salario mínimo legal vigente ({salarioMinimoLegal:C}).");
        }

        public static void ValidarFechas(ContratoLaboral contrato)
        {
            if (contrato.ContratoFechaInicio.HasValue && contrato.ContratoFechaFin.HasValue)
            {
                if (contrato.ContratoFechaFin <= contrato.ContratoFechaInicio)
                    throw new ArgumentException("La fecha de fin debe ser mayor que la fecha de inicio.");
            }
        }

        public static void ValidarCoherenciaGeneral(ContratoLaboral contrato)
        {
            ValidarCamposObligatorios(contrato);
            ValidarFechaInicio(contrato);
            ValidarFechas(contrato);
            ValidarSalarioMinimo(contrato.ContratoSalario, 1025m); 
        }
    }
}
