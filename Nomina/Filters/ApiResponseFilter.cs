using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Nomina.Application.DTOs;
using System.Text.Json;

namespace Nomina.API.Filters
{
    public class ApiResponseFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult &&
                objectResult.StatusCode >= 200 && objectResult.StatusCode < 300)
            {
                // Evitar procesar respuestas ya formateadas
                if (objectResult.Value is ApiResponse<object>)
                    return;

                object? data = objectResult.Value;
                int totalRows = 0;

                // Determinar el mensaje base
                string message = data is string strMessage
                    ? strMessage
                    : "Operación exitosa";

                // Si el objeto tiene propiedades tipo "data" y "totalRows"
                if (data is not null && data.GetType() != typeof(string))
                {
                    var tipo = data.GetType();
                    var totalRowsProp = tipo.GetProperty("totalRows", System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                    if (totalRowsProp != null)
                    {
                        totalRows = (int)(totalRowsProp.GetValue(data) ?? 0);
                        var dataProp = tipo.GetProperty("data", System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                        if (dataProp != null)
                        {
                            data = dataProp.GetValue(data);
                        }
                    }
                }

                // Construir la respuesta base
                var responseDict = new Dictionary<string, object?>
                {
                    ["statusCode"] = objectResult.StatusCode ?? 200,
                    ["success"] = true,
                    ["message"] = message
                };

                // Agregar data solo si no es texto
                if (data is not null && data.GetType() != typeof(string))
                {
                    responseDict["data"] = data;
                    responseDict["TotalRows"] = totalRows;
                }

                // Devolver el resultado final formateado
                context.Result = new ContentResult
                {
                    StatusCode = objectResult.StatusCode,
                    ContentType = "application/json",
                    Content = JsonSerializer.Serialize(responseDict)
                };
            }
        }
    }
}
