using FluentValidation;
using Serilog.Events;
using Serilog;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace application
{
    public static class ServiceApplication
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                // .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Error)
                .WriteTo.File($"Logs/{DateTime.Now:yyyy}/{DateTime.Now:MM}/{DateTime.Now:yyyy-MM-dd}.log")
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateBootstrapLogger();

            return services;
        }
    }
}
