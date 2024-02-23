using IMS.API.Extensions;
using IMS.Application;
using IMS.Infrastructure;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .MinimumLevel.Information()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSerilog();

builder.Services.AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.RegisterEndpoints();

app.UseSerilogRequestLogging();

app.Run();
