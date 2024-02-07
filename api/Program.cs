using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Encodings.Web;
using api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServicesExtension(builder);
var app = builder.Build();
app.ConfigureApplication();
app.Run();