using api.Middleware;
using application;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using infra.Persistence;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.Extensions.Options;

namespace api.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServicesExtension(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Configuration.AddJsonFile("appsettings.json");

            builder.Services.AddDbContext<_dbContext>(opt =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                opt.UseNpgsql(connectionString, b => b.MigrationsAssembly("api"));
            });

            builder.Services.AddCors();
            builder.Services.AddControllers();
            builder.Services.AddTransient<ApiFilterExceptionAttribute>();
            #region AutofacModule
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
              .ConfigureContainer<ContainerBuilder>(e =>
              {
                  e.RegisterAssemblyModules(typeof(AutofacModule).Assembly);
              });
            #endregion
            #region global

            builder.Services.AddApplicationLayer();
            builder.Logging.ClearProviders().AddConsole();
            builder.Host.UseSerilog();
            #endregion
            #region Model         
            builder.Services.AddOptions<JsonSerializerOptions>()
               .Configure(options =>
               {
                   options.PropertyNameCaseInsensitive = false;
                   options.NumberHandling = JsonNumberHandling.AllowReadingFromString;
                   options.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
                   options.Converters.Add(new JsonStringEnumConverter());
               });

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            #endregion
            builder.Services.AddSwaggerGen();
            return services;
        }
    }
}
