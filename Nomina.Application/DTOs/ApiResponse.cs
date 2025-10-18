using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.DTOs
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }       
        public bool Success { get; set; }         
        public string Message { get; set; }       
        public T? Data { get; set; }             

        public ApiResponse(int statusCode, bool success, string message, T? data = default)
        {
            StatusCode = statusCode;
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
