using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.Common.Contracts.Requests;
using Forum.Application.Core.Movies.Commands.UpdateMovie;

namespace Forum.Application.Common.Mappings.Movies;

public static class UpdateMovieRequestMapping
{
    public static UpdateMovieCommand ToCommand(this UpdateMovieRequest request)
    {
        return new UpdateMovieCommand(
            request.Id,
            request.Title,
            request.Description,
            request.Duration,
            request.Score,
            request.PosterUrl,
            request.LaunchDate
        );
    }
}
