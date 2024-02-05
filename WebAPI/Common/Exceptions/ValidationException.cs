using FluentValidation.Results;
using System.Net;

namespace WebAPI.Common.Exceptions
{
    public class ValidationException : BaseException
    {
        public IDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>();
        public ValidationException(string message) : base(message, code: (int)HttpStatusCode.BadRequest, errorCode: null) { }
        public ValidationException() : base("One or more validation failures have occurred", code: (int)HttpStatusCode.BadRequest, errorCode: null)
        {
            Errors = new Dictionary<string, string[]>();
        }
        public ValidationException(IEnumerable<ValidationFailure> failures) : base(message: "One or more validation failures have occurred", code: (int)HttpStatusCode.BadRequest, errorCode: null)
        {
            Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                                       .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

    }
}
