using System.Net;

namespace MultiBlazorApp.Common.Exceptions
{
    public class AuthorizationException : Exception
    {
        public string? Title { get; }
        public HttpStatusCode StatusCode { get; }

        public AuthorizationException(string title, HttpStatusCode statusCode = HttpStatusCode.Unauthorized)
            : base(title)
        {
            Title = title;
            StatusCode = statusCode;
        }
    }
}
