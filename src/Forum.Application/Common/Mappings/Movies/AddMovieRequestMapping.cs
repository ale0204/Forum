using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.Common.Contracts.Requests;
using Forum.Application.Core.Movies.Commands.AddMovie;

namespace Forum.Application.Common.Mappings.Movies;

public static class AddMovieRequestMapping
{
    public static AddMovieCommand ToCommand(this AddMovieRequest request)
    {
        return new AddMovieCommand(
            request.Title,
            request.Duration,
            request.Score,
            request.PosterUrl,
            request.LaunchDate
        );
    }
}
