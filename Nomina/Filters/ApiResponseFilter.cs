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
                if (objectResult.Value is ApiResponse<object>)
                    return;

                string message = "Operación exitosa";
                object data = objectResult.Value;
                int TotalRows = 0;

                if (data is not null)
                {
                    var tipo = data.GetType();
                    var totalRowsProp = tipo.GetProperty("totalRows", System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                    if (totalRowsProp != null)
                    {
                        TotalRows = (int)(totalRowsProp.GetValue(data) ?? 0);
                        var dataProp = tipo.GetProperty("data", System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                        if (dataProp != null)
                        {
                            data = dataProp.GetValue(data);
                        }
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
                { 
                    responseDict["data"] = data;
                    responseDict["TotalRows"] = TotalRows;
                }

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
