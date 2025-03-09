using CookBook.BL;
using CookBook.BL.Facades;
using CookBook.BL.Facades.Interfaces;
using CookBook.DAL;

namespace Controllerless;


public class Program
{
    
    public static void Main(string[] args)
    {

        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<Program>()
            .Build();


        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");


        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddBusinessLayer();
        builder.Services.AddDataAccessLayer();
        ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        builder.Services.AddSingleton(loggerFactory.CreateLogger("Program"));
        var app = builder.Build();


        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.MapGet("/", () => "Hello, welcome to my API!");
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        app.MapGet("/weatherforecast", (HttpContext httpContext) =>
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                })
                .ToArray();
            return forecast;
        })
        .WithName("GetWeatherForecast");
        app.MapGet("/neco", (IIngredientFacade facade) => facade.Get()).WithOpenApi();

        app.Run();
    }
}

