using System;
using System.Linq;
using System.Text.Json.Serialization;
using FastEndpoints;
using FastEndpoints.Swagger;
using Forum.Presentation.Api.Common.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Forum.Application.Common.DependencyInjection;


namespace Forum.Presentation.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddPresentationApiLayerServices(builder.Configuration);
            builder.Services.AddApplicationLayerServices();
            //builder.Services.AddAuthentication();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection(); 

            //app.UseAuthentication();

            app.UseAuthorization();

            app.UseFastEndpoints(config =>
            {
                config.Endpoints.RoutePrefix = "api";
                config.Versioning.Prefix = "v";
                config.Versioning.DefaultVersion = 1;
                config.Versioning.PrependToRoute = true;
                config.Endpoints.ShortNames = true;
            });

            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            //app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            //{
            //    var forecast = Enumerable.Range(1, 5).Select(index =>
            //        new WeatherForecast
            //        {
            //            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //            TemperatureC = Random.Shared.Next(-20, 55),
            //            Summary = summaries[Random.Shared.Next(summaries.Length)]
            //        })
            //        .ToArray();
            //    return forecast;
            //});

            app.Run();
        }
    }
}
