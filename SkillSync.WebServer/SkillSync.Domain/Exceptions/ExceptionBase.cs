using System.Net;

namespace SkillSync.Domain.Exceptions
{
    public class ExceptionBase : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public string Message { get; }

        public ExceptionBase(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }
    }
}