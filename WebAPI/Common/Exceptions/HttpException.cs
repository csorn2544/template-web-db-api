using WebAPI.Constants;

namespace WebAPI.Common.Exceptions
{
    public class HttpException : BaseException
    {
        public HttpException(string message) : base(message, code: 400, errorCode: ErrorCodeConstant.HttpError) { }
        public HttpException(string message, int code) : base(message, code, errorCode: ErrorCodeConstant.HttpError) { }
    }
}
