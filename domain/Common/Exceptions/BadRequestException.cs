using System.Net;

namespace domain.Common.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message) : base(message, code: (int)HttpStatusCode.BadRequest, errorCode: null) { }
        public BadRequestException(string message, string errorCode) : base(message, code: (int)HttpStatusCode.BadRequest, errorCode: errorCode) { }

    }
}
