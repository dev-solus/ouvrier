using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Services
{
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;

        public ErrorHandler(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpResponse response = context.Response;

            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            
            await response.WriteAsync(JsonConvert.SerializeObject(new
            {
                Message = exception.Message, // or custom one
                Description = exception.InnerException?.Message,
                StackTrace = exception.StackTrace
                .Split("\n")
                .Where(e => e.Contains(":line"))
                .Select(e =>
                {
                    var i = e.LastIndexOf("\\") + 1;

                    return i > 0 ? e.Substring(i) : e;
                })
                .ToList()
                ,
            }));
        }
    }
}