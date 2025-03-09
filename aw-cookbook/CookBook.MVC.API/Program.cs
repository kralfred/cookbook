
using System.Globalization;
using CookBook.BL;
using CookBook.BL.Facades;
using CookBook.BL.Facades.Interfaces;
using CookBook.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;

namespace CookBook.MVC.API;

public class Program
{


    public static void Main(string[] args)
    {
        

        var builder = WebApplication.CreateBuilder(args);
        builder.Logging.ClearProviders().AddConsole();


        var apiBaseUrl = builder.Configuration.GetValue<string>("ApiBaseUrl");
        builder.Services.AddControllers()
       .AddJsonOptions(options =>
        {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;          //For blazor API intergration
        });
        builder.Services.AddHttpClient();
        builder.Services.AddHttpClient();
        builder.Services.AddScoped(serviceProvider =>
        {
            var httpClient = serviceProvider.GetService<IHttpClientFactory>().CreateClient();
            httpClient.BaseAddress = new Uri(apiBaseUrl);
            return httpClient;
        });

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options =>
             {
                options.Authority = "https://localhost:5001";
                options.TokenValidationParameters.ValidateAudience = false;
             });
        builder.Services.AddAuthorization(
        config =>
        {
            config.AddPolicy("recipeadminpolicy", policyBuilder => policyBuilder.RequireRole("admin"));
            config.AddPolicy("ingredientswritepolicy", policyBuilder => policyBuilder.RequireAssertion(
        context => context.User.IsInRole("cook")
        || context.User.IsInRole("admin")));
        }
      );

        

        builder.Services.AddOpenApi();
        builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddBusinessLayer();
        builder.Services.AddDataAccessLayer();
        builder.Services.AddLogging();
        builder.Logging.AddConsole();



         var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        var logger = app.Services.GetService<ILogger>();
      
        

        Thread.CurrentThread.CurrentCulture = new CultureInfo("cs");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("cs");

        app.UseRequestLocalization();

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}
