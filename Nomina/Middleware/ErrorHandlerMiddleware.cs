using Nomina.API.Exceptions;
using Nomina.Domain.DTOs;
using System.Net;
using System.Text.Json;

namespace Nomina.API.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                HttpStatusCode statusCode = ex switch
                {
                    NotFoundException => HttpStatusCode.NotFound,
                    BusinessException => HttpStatusCode.BadRequest,
                    DatabaseException => HttpStatusCode.ServiceUnavailable,
                    _ => HttpStatusCode.InternalServerError
                };

                var result = JsonSerializer.Serialize(new
                {
                    StatusCode = (int)statusCode,
                    Success = false,
                    Message = ex.Message
                });

                response.StatusCode = (int)statusCode;
                await response.WriteAsync(result);
            }
        }
    }
}
