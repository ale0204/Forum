using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.Common.DataAccess.Entities;
using Forum.Application.Core.Movies.Commands.UpdateMovie;

namespace Forum.Application.Common.Mappings.Movies;

public static class UpdateMovieCommandMapping
{
    public static MovieEntity ToRepositoryEntity(this UpdateMovieCommand updateMovieCommand)
    {
        return new MovieEntity()
        {
            Id = updateMovieCommand.Id,
            Title = updateMovieCommand.Title,
            Description = updateMovieCommand.Description,
            Score = updateMovieCommand.Score,
            LaunchDate = updateMovieCommand.LaunchDate,
            PosterUrl = updateMovieCommand.PosterUrl,
            Duration = updateMovieCommand.Duration
        };
    }
}
