using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using Forum.Application.Common.Contracts.Responses;
using Mediator;

namespace Forum.Application.Core.Movies.Commands.AddMovie;

public record AddMovieCommand(
    string Title,
    int? Duration,
    float? Score,
    string? PosterUrl,
    DateOnly? LaunchDate
) : IRequest<ErrorOr<MovieResponse>>;
