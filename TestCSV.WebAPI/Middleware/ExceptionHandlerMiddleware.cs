using MailKit;
using System.Net;

namespace TestCSV.WebAPI.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (MessageNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);
                await HandleMessageNotFoundException(context, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await HandleException(context, ex.Message);
            }
        }

        private async Task HandleMessageNotFoundException(HttpContext context, string errorMessage)
        {
            var response = new
            {
                code = HttpStatusCode.NotFound,
                message = errorMessage
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)response.code;

            await context.Response.WriteAsJsonAsync(response);
        }

        private async Task HandleException(HttpContext context, string errorMessage)
        {
            var response = new
            {
                code = HttpStatusCode.InternalServerError,
                message = errorMessage
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)response.code;

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
