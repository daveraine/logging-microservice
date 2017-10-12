namespace LoggingMicroservice.Infrastructure
{
    using System;

    /// <summary>
    /// An error response
    /// </summary>
    public class ErrorResponse
    {
        public ErrorResponse(Exception ex)
        {
            Message = ex.Message;
            StackTrace = ex.StackTrace;
        }

        public string Message { get; private set; }

        public string StackTrace { get; private set; }
    }
}