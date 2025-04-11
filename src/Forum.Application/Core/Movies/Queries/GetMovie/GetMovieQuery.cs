using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using Forum.Application.Common.Contracts.Responses;
using Mediator;

namespace Forum.Application.Core.Movies.Queries.GetMovie;

public record GetMovieQuery(
    Guid Id
) : IRequest<ErrorOr<MovieResponse>>;

