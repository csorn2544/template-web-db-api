using System.Net;

namespace WebAPI.Common.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message) : base(message, code: (int)HttpStatusCode.NotFound, errorCode: null) { }
        public NotFoundException(string message, string errorCode) : base(message, code: (int)HttpStatusCode.NotFound, errorCode: errorCode) { }
        public NotFoundException(string title, string message, string errorCode) : base(title, message, code: (int)HttpStatusCode.NotFound, errorCode) { }

    }
}
