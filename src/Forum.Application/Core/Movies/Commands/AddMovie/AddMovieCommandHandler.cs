using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using Forum.Application.Common.Contracts.Responses;
using Mediator;

namespace Forum.Application.Core.Movies.Commands.AddMovie;

public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, ErrorOr<MovieResponse>>
{
    public async ValueTask<ErrorOr<MovieResponse>> Handle(AddMovieCommand request, CancellationToken cancellationToken)
    {
        return new MovieResponse(Guid.NewGuid(), request.Title, request.Duration, request.Score, request.PosterUrl, request.LaunchDate);
    }
}
