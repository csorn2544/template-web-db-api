using System.Net;

namespace domain.Common.Exceptions
{
    public class NoContentException(string message) : BaseException(message, (int)HttpStatusCode.NoContent, errorCode: null)
    {
    }
}
