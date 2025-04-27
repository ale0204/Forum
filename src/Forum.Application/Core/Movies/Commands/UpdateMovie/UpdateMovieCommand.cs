using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using Forum.Application.Common.Contracts.Responses;
using Mediator;

namespace Forum.Application.Core.Movies.Commands.UpdateMovie;

public record UpdateMovieCommand(
    Guid Id,
    string Title,
    string? Description,
    int? Duration,
    float? Score,
    string? PosterUrl,
    DateOnly? LaunchDate
) : IRequest<ErrorOr<MovieResponse>>;
