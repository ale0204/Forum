using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Bogus;
using Forum.Application.Core.Movies.Commands.AddMovie;

namespace Forum.UnitTests;

public class AddMovieCommandFixture
{
    private readonly Fixture _fixture;
    private readonly Faker _faker;
    public AddMovieCommandFixture()
    {
        _fixture = new Fixture();
        _faker = new Faker();
    }

    public AddMovieCommand Create(
        string? title = null,
        string? description = null,
        int? duration = null,
        float? score = null,
        string? posterUrl = null,
        DateOnly? launchDate = null,
        bool useTitle = true,
        bool useDescription = true,
        bool useDuration = true,
        bool useScore = true,
        bool usePosterUrl = true,
        bool useLaunchDate = true
        )
    {
        return new Faker<AddMovieCommand>()
            .CustomInstantiator(f => new AddMovieCommand(
                Title: useTitle ? (title ?? f.Name.FullName()) : null,
                Description: useDescription ? (description ?? f.Company.CompanyName()) : null,
                Duration: useDuration ? (duration ?? f.Random.Int(90, 210)) : null,
                Score: useScore ? (score ?? f.Random.Float(1, 5)) : null,
                PosterUrl: usePosterUrl ? (posterUrl ?? f.Internet.Url()) : null,
                LaunchDate: useLaunchDate ? (launchDate ?? f.Date.BetweenDateOnly(new DateOnly(1950, 1, 1), new DateOnly(2025, 5, 1))) : null
            ))
            .Generate();
    }
    
    public List<AddMovieCommand> CreateMany(int count = 3)
    {
        return Enumerable.Range(0, count)
            .Select(_ => Create())
            .ToList();
    }
}
