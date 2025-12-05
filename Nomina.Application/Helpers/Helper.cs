using System;
using System.Collections.Generic;

namespace Nomina.Application.Helpers
{
    public class Helper
    {
        private static readonly Dictionary<int, string> _meses = new()
        {
            {1, "Enero"},
            {2, "Febrero"},
            {3, "Marzo"},
            {4, "Abril"},
            {5, "Mayo"},
            {6, "Junio"},
            {7, "Julio"},
            {8, "Agosto"},
            {9, "Septiembre"},
            {10, "Octubre"},
            {11, "Noviembre"},
            {12, "Diciembre"}
        };

        private static readonly Dictionary<string, string> _estados = new(StringComparer.OrdinalIgnoreCase)
        {
            {"A", "ACTIVO"},
            {"P", "PROCESADO"}
        };

        private static readonly Dictionary<string, string> _descripcionesEstados = new(StringComparer.OrdinalIgnoreCase)
        {
            {"A", "Activo"},
            {"I", "Inactivo"},
            {"S", "Suspendido"}
        };

        public static string ObtenerNombreMes(int mes)
        {
            return _meses.TryGetValue(mes, out var nombre)
                ? nombre
                : "Mes inválido";
        }

        public static string ObtenerNombreEstado(string estado)
        {
            return _estados.TryGetValue(estado, out var nombre)
                ? nombre
                : "INACTIVO";
        }

        public static string ObtenerDescripcionEstado(string? estado)
        {
            return _descripcionesEstados.TryGetValue(estado ?? string.Empty, out var descripcion)
                ? descripcion
                : "Finalizado";
        }
    }
}