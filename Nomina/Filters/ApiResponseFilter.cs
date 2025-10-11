using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Nomina.Domain.DTOs;
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
                if (objectResult.Value is ApiResponse<object>)
                    return;

                string message = "Operación exitosa";
                object data = objectResult.Value;

                if (data is not null)
                {
                    var tipo = data.GetType();
                    var messageProp = tipo.GetProperty("message", System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

                    if (messageProp != null)
                    {
                        message = messageProp.GetValue(data)?.ToString() ?? message;

                        if (tipo.GetProperties().Length == 1)
                            data = null;
                    }
                }

                var apiResponse = new
                {
                    statusCode = objectResult.StatusCode ?? 200,
                    success = true,
                    message = message,
                };

                var responseDict = new Dictionary<string, object?>
                {
                    ["statusCode"] = objectResult.StatusCode ?? 200,
                    ["success"] = true,
                    ["message"] = message
                };

                if (data is not null)
                    responseDict["data"] = data;

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
