using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.Text.Json;
using infra.Persistence;
using api;
using api.Middleware;
using application;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddDbContext<_dbContext>(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    opt.UseNpgsql(connectionString);
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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(x => x.AllowAnyMethod()
                  .AllowAnyHeader()
                  .SetIsOriginAllowed(origin => true)
                  .AllowCredentials());

app.MapControllers();

app.Run();