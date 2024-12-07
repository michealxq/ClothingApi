using System.Net;

namespace P1API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger,
            RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpcontext)
        {
            try
            {
                await next(httpcontext);
            }
            catch (Exception ex)
            {
                var ErrorId = Guid.NewGuid();

                logger.LogError(ex, $"{ErrorId} :{ex.Message}");

                httpcontext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpcontext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = ErrorId,
                    ErrorMessage = "something went wrong , we are looking to resolve this"
                };

                await httpcontext.Response.WriteAsJsonAsync(error);


            }
        }
    }
}
