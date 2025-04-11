using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.Common.DataAccess.Entities;
using Forum.Application.Core.Movies.Commands.AddMovie;

namespace Forum.Application.Common.Mappings.Movies;

public static class AddMovieCommandMapping
{
    public static MovieEntity ToRepositoryEntity(this AddMovieCommand addMovieCommand)
    {
        return new MovieEntity()
        {
            Id = Guid.NewGuid(),
            Title = addMovieCommand.Title,
            Description = addMovieCommand.Description,
            Score = addMovieCommand.Score,
            LaunchDate = addMovieCommand.LaunchDate,
            PosterUrl = addMovieCommand.PosterUrl,
            Duration = addMovieCommand.Duration
        };
    }
}
