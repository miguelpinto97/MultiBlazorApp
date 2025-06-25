using System.Net;

namespace MultiBlazorApp.Common.Exceptions
{
    public class InternalServerException : CustomException
    {
        public InternalServerException(string message)
            : base(message, null, HttpStatusCode.InternalServerError) { }
    }
}
