using MediatR;
using Serilog;
using System.Diagnostics;

namespace WebAPI.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse>(ILogger<TRequest> logger) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly ILogger<TRequest> _logger = logger;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                var requestName = typeof(TRequest).Name;
                Log.Information("Start handling {Type} ", requestName);
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogError(ex, "CleanArchitecture Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);
                Log.Error(ex, "CleanArchitecture Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);
                throw;
            }
            finally
            {
                stopwatch.Stop();
                var requestName = typeof(TRequest).Name;
                Log.Information("Completed handling {Type} - {Elapsed}", requestName, stopwatch.Elapsed);
            }
        }
    }
 }
