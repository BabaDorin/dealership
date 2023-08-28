using Newtonsoft.Json;

namespace DealershipManager.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private static async Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = 500; // INTERNAL SERVER ERROR
            context.Response.ContentType = "application/json";

            var error = new
            {
                Message = "An error occurred while processing your request.",
                ExceptionMessage = ex.Message,
            };

            // Serializare: Din obiect in Json
            /*
            {
                "message": "An error occurred while processing your request.",
                "exceptionMessage": "Attepted to devide by 0"
            }
             */

            var jsonResponse = JsonConvert.SerializeObject(error);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
