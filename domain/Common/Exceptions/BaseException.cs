namespace domain.Common.Exceptions
{
public class BaseException : Exception
    {
    public int StartTracingId { get; set; }
    public int? Code { get; set; }
    public string ErrorCode { get; set; } = null;
    public string Title { get; set; } = null;
    public string Url { get; set; } = null;
    public BaseException() { }
    public BaseException(Exception exception) : base(exception.Message, exception.InnerException) { }

    public BaseException(string message, string errorCode = null) : base(message)
    {
        ErrorCode = errorCode;
    }

    public BaseException(string title, string message, string errorCode = null) : base(message)
    {
        ErrorCode = errorCode;
        Title = title;
    }
    public BaseException(string message, int code, string errorCode = null) : base(message)
    {
        ErrorCode = errorCode;
        Code = code;
    }
    public BaseException(string message, int code, string url, string errorCode = null) : base(message)
    {
        ErrorCode = errorCode;
        Code = code;
        Url = url;
    }
    public BaseException(string title, string message, int code, string errorCode = null) : base(message)
    {
        ErrorCode = errorCode;
        Title = title;
        Code = code;
    }
    public BaseException(string title, string message, int code, string url, string errorCode = null) : base(message)
    {
        ErrorCode = errorCode;
        Title = title;
        Code = code;
        Url = url;
    }

    public BaseException(string message, Exception innerException) : base(message, innerException) { }

}
}
