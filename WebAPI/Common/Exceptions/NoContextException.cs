using System.Net;

namespace WebAPI.Common.Exceptions
{
    public class NoContentException(string message) : BaseException(message, (int)HttpStatusCode.NoContent, errorCode: null)
    {
    }
}
