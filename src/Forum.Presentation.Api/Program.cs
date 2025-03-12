using System;
using System.Linq;
using System.Text.Json.Serialization;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.Presentation.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddFastEndpoints(endpointDiscoveryOptions => endpointDiscoveryOptions.Assemblies = [typeof(Program).Assembly]);

            builder.Services.AddOpenApi();

            builder.Services.SwaggerDocument(documentOptions =>
            {
                documentOptions.EnableJWTBearerAuth = true;
                documentOptions.SerializerSettings = jsonSerializerOptions =>
                {
                    jsonSerializerOptions.PropertyNamingPolicy = null;
                    jsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                };
                documentOptions.MaxEndpointVersion = 1;
                documentOptions.MinEndpointVersion = 1;
                documentOptions.DocumentSettings = aspNetCoreOpenApiDocumentGeneratorSettings =>
                {
                    aspNetCoreOpenApiDocumentGeneratorSettings.DocumentName = "v1";
                    aspNetCoreOpenApiDocumentGeneratorSettings.Title = "Forum API v1";
                    aspNetCoreOpenApiDocumentGeneratorSettings.Version = "v1";
                };
                documentOptions.RemoveEmptyRequestSchema = true;
                documentOptions.ShortSchemaName = true;
            });
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
