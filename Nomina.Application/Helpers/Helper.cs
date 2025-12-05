using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Application.Helpers
{
    public class Helper
    {
        public static string ObtenerNombreMes(int mes)
        {
            return mes switch
            {
                1 => "Enero",
                2 => "Febrero",
                3 => "Marzo",
                4 => "Abril",
                5 => "Mayo",
                6 => "Junio",
                7 => "Julio",
                8 => "Agosto",
                9 => "Septiembre",
                10 => "Octubre",
                11 => "Noviembre",
                12 => "Diciembre",
                _ => "Mes inválido"
            };
        }

        public static string ObtenerNombreEstado(String estado)
        {
            return estado switch
            {
                "A" => "ACTIVO",
                "P" => "PROCESADO",
                _ => "INACTIVO"
            };
        }

        public static string ObtenerDescripcionEstado(string? estado) =>
        estado switch
        {
            "A" => "Activo",
            "I" => "Inactivo",
            "S" => "Suspendido",
            _ => "Finalizado"
        };

    }
}
