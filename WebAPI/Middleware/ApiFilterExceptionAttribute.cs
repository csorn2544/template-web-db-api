using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebAPI.Common;
using WebAPI.Common.Exceptions;
using WebAPI.Common.DTOs;
using WebAPI.Constants;

namespace WebAPI.Middleware
{
    public class ApiFilterExceptionAttribute : IAsyncExceptionFilter
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ApiFilterExceptionAttribute()
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>()
            {
                { typeof(BaseException), HandleBaseException },
                { typeof(BadRequestException), HandleBaseException },
                { typeof(ValidationException), HandleValidationException },
                { typeof(NotFoundException), HandleNotFoundException },
                { typeof(HttpException), HandleBaseException },
                { typeof(UnauthorizedAccessException), HandleUnauthorizedAccessException },
                { typeof(ForbiddenAccessException), HandleForbiddenAccessException },
                { typeof(NoContentException), HandleNoContentException }
            };
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            await HandleException(context);
            _ = context.HttpContext.Response;
        }

        private async Task HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                string status = StatusCodes.Status400BadRequest.ToString();
                if (type == typeof(ValidationException))
                {
                    status = StatusCodes.Status422UnprocessableEntity.ToString();
                }
                else if (type == typeof(UnauthorizedAccessException))
                {
                    status = StatusCodes.Status401Unauthorized.ToString();
                }
                else if (type == typeof(ForbiddenAccessException))
                {
                    status = StatusCodes.Status403Forbidden.ToString();
                }
                else if (type == typeof(NoContentException))
                {
                    status = StatusCodes.Status204NoContent.ToString();
                }
                else
                {
                    if (context.Exception is BaseException exception)
                    {
                        status = exception.Code is null ? StatusCodes.Status400BadRequest.ToString() : exception.Code.ToString();
                    }
                }
                _exceptionHandlers[type].Invoke(context);
                await Task.FromResult<object>(null);
            }
            else
            {
                if (!context.ModelState.IsValid)
                {
                    HandleInvalidModelStateException(context);

                    return;
                }
                HandleNonHandleException(context);
            }
        }

        private static void HandleInvalidModelStateException(ExceptionContext context)
        {
            var exception = context.Exception;
            var details = new ExceptionMessage
            {
                Message = exception.Message
            };

            context.Result = new BadRequestObjectResult(details);
            context.ExceptionHandled = true;
        }

        private static void HandleNonHandleException(ExceptionContext context)
        {
            var detail = new ExceptionMessage()
            {
                Message = string.IsNullOrEmpty(context.Exception.Message) ? ErrorMessageConstant.UnexpectedMessage : context.Exception.Message,
                ErrorCode = ErrorCodeConstant.Default
            };

            ObjectResult objectResult = new(detail)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            context.Result = objectResult;
            context.ExceptionHandled = false;
            Log.Error(context.Exception.ToString());
        }

        private void HandleBaseException(ExceptionContext context)
        {
            var exception = (BaseException)context.Exception;
            var detail = new ExceptionMessage()
            {
                Message = string.IsNullOrEmpty(exception.Message) ? ErrorMessageConstant.UnexpectedMessage : exception.Message,
                ErrorCode = string.IsNullOrEmpty(exception.ErrorCode) ? ErrorCodeConstant.Default : exception.ErrorCode
            };
            ObjectResult objectResult = new(detail)
            {
                StatusCode = exception.Code == null ? StatusCodes.Status400BadRequest : exception.Code
            };
            context.Result = objectResult;
            context.ExceptionHandled = true;
        }

        private void HandleValidationException(ExceptionContext context)
        {
            var exception = context.Exception;

            var details = new ExceptionMessage
            {
                Message = exception.Message
            };
            if (exception is ValidationException ex && ex.Errors.Count > 0)
            {
                List<string> errors = [];
                foreach (string[] e in ex.Errors.Values.ToList()) errors.Add(string.Join(", ", e));
                details.Message = string.Join(", ", errors);
            }
            context.Result = new UnprocessableEntityObjectResult(details);
            context.ExceptionHandled = true;
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            var exception = (NotFoundException)context.Exception;
            var detail = new ExceptionMessage()
            {
                Message = string.IsNullOrEmpty(exception.Message) ? ErrorMessageConstant.UnexpectedMessage : exception.Message,
                ErrorCode = string.IsNullOrEmpty(exception.ErrorCode) ? ErrorCodeConstant.Default : exception.ErrorCode
            };
            context.Result = new NotFoundObjectResult(detail);
            context.ExceptionHandled = true;
        }

        private void HandleUnauthorizedAccessException(ExceptionContext context)
        {
            var details = new ExceptionMessage
            {
                Message = "Unauthorized",
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };

            context.ExceptionHandled = true;
        }
        private void HandleForbiddenAccessException(ExceptionContext context)
        {
            var details = new ExceptionMessage
            {
                Message = "Forbidden"
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status403Forbidden
            };

            context.ExceptionHandled = true;
        }

        private void HandleNoContentException(ExceptionContext context)
        {
            context.Result = new NoContentResult();
            context.ExceptionHandled = true;
        }

    }
}
