using Microsoft.AspNetCore.Http;
using Serilog;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace MessagingApi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                Log.Error(ex, "Unhandled exception");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var errorResponse = new { error = "An unexpected error occured." };
                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            }
        }
    }
}
