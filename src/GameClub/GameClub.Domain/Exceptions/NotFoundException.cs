using System.Net;

namespace GameClub.Domain.Exceptions;

public class NotFoundException : Exception
{
    public HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.NotFound;

    public string Message { get; set; } = string.Empty;
}
