using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Text.Json.Serialization;
using MessagingApi.Middlewares;
using MessagingApi.Services;
//using Microsoft.Extensions.Logging.Configuration;

var builder = WebApplication.CreateBuilder(args);

//Setup Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

//Add services
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

//Add swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IMessageService, MessageService>();

var app = builder.Build();

//Custom middleware pipeline
app.UseMiddleware<RequestLoggingMiddleware>();

app.UseMiddleware<ExceptionHandlingMiddleware>();


//Built-in middleware pipeline

//app.UseHttpsRedirection();

app.UseRouting();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.Run();

