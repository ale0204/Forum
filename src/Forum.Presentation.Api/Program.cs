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
using Forum.DataAccess.Common.DependencyInjection;
using Forum.DataAccess.Core.UoW;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Scalar.AspNetCore;



namespace Forum.Presentation.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddPresentationApiLayerServices(builder.Configuration);
            builder.Services.AddApplicationLayerServices();
            //builder.Services.AddAuthentication();
            builder.Services.AddDataAccessLayerServices(builder.Configuration);

            var app = builder.Build();
            // Run any migration from the DataBase structure to be up to date.

            // Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            using (IServiceScope scope = app.Services.CreateScope())
            {
                IServiceProvider serviceProvider = scope.ServiceProvider;
                try
                {
                    ForumDbContext context = serviceProvider.GetRequiredService<ForumDbContext>();
                    await context.Database.MigrateAsync();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Failed to run DataBase migrations: " + ex.Message);
                }
            }
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

            app.MapOpenApi();
            app.UseOpenApi(settings => settings.Path = "/openapi/{documentName}.json");
            app.MapScalarApiReference(options =>
            {
                options.WithTitle("Forum API")
                    .WithTheme(ScalarTheme.BluePlanet)
                    .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
                    .WithDotNetFlag(true);
            });
            app.Run();
        }
    }
}
