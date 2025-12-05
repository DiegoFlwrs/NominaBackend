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
            if (!IsSuccessResponse(context.Result))
                return;

            var objectResult = (ObjectResult)context.Result!;

            if (objectResult.Value is ApiResponse<object>)
                return;

            var (data, totalRows) = ExtractDataAndTotalRows(objectResult.Value);

            var response = BuildResponse(
                statusCode: objectResult.StatusCode ?? 200,
                message: data is string messageStr ? messageStr : "Operación exitosa",
                data: data,
                totalRows: totalRows
            );

            context.Result = new ContentResult
            {
                StatusCode = objectResult.StatusCode,
                ContentType = "application/json",
                Content = JsonSerializer.Serialize(response)
            };
        }

        private static bool IsSuccessResponse(object? result)
        {
            return result is ObjectResult obj &&
                   obj.StatusCode is >= 200 and < 300;
        }

        private static (object? Data, int TotalRows) ExtractDataAndTotalRows(object? value)
        {
            if (value is null or string)
                return (value, 0);

            var type = value.GetType();

            var totalProp = type.GetProperty("totalRows",
                System.Reflection.BindingFlags.IgnoreCase |
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Instance);

            int totalRows = totalProp?.GetValue(value) as int? ?? 0;

            var dataProp = type.GetProperty("data",
                System.Reflection.BindingFlags.IgnoreCase |
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Instance);

            var data = dataProp?.GetValue(value) ?? value;

            return (data, totalRows);
        }

        private static Dictionary<string, object?> BuildResponse(
            int statusCode,
            string message,
            object? data,
            int totalRows)
        {
            var response = new Dictionary<string, object?>
            {
                ["statusCode"] = statusCode,
                ["success"] = true,
                ["message"] = message
            };

            if (data is not null and not string)
            {
                response["data"] = data;
                response["TotalRows"] = totalRows;
            }

            return response;
        }
    }
}
