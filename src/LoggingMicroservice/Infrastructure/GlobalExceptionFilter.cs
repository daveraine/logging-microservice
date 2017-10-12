namespace LoggingMicroservice.Infrastructure
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;

    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger logger;

        public GlobalExceptionFilter(ILoggerFactory logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            this.logger = logger.CreateLogger("Global Exception Filter");
        }

        public void OnException(ExceptionContext context)
        {
            var response = new ErrorResponse(context.Exception);

            context.Result = new ObjectResult(response)
            {
                StatusCode = 500,
                DeclaredType = typeof(ErrorResponse)
            };

            logger.LogError("GlobalExceptionFilter", context.Exception);
        }
    }
}
