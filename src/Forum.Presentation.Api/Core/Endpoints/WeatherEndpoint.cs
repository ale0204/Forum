using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;

namespace Forum.Presentation.Api.Core.Endpoints
{
    public class WeatherEndpoint : Endpoint<EmptyRequest, WeatherForecast[]>
    {
        public override void Configure()
        {
            AllowAnonymous();
            Verbs(Http.GET);
            Routes("/Weather");
            Version(1);
        }

        public override Task<WeatherForecast[]> ExecuteAsync(EmptyRequest req, CancellationToken ct)
        {
            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
            var forecast = Enumerable.Range(1, 5).Select(index =>
                   new WeatherForecast
                   {
                       Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                       TemperatureC = Random.Shared.Next(-20, 55),
                       Summary = summaries[Random.Shared.Next(summaries.Length)]
                   })
                   .ToArray();
            return Task.FromResult(forecast);
        }
    }
}
