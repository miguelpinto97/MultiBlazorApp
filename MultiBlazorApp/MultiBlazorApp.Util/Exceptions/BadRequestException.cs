using System.Net;

namespace MultiBlazorApp.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public IDictionary<string, string[]>? Errors { get; }
        public string? Title { get; }
        public HttpStatusCode StatusCode { get; }

        public BadRequestException(IDictionary<string, string[]>? errors, string title = "No se ha cumplido con una o varias validaciones")
            : base(title)
        {
            Title = title;
            Errors = errors;
            StatusCode = HttpStatusCode.BadRequest;
        }
    }
}
