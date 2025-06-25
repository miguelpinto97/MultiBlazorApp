using System.Net;

namespace MultiBlazorApp.Common.Exceptions
{
    public class CustomException : Exception
    {
        public Dictionary<string, string[]>? Errors { get; }
        public string? Title { get; }
        public HttpStatusCode StatusCode { get; }

        public CustomException(string title, Dictionary<string, string[]>? errors = default, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
            : base(title)
        {
            Title = title;
            Errors = errors;
            StatusCode = statusCode;
        }
    }
}
