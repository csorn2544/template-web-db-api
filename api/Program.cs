using api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServicesExtension(builder);
var app = builder.Build();
app.ConfigureApplication();
app.Run();