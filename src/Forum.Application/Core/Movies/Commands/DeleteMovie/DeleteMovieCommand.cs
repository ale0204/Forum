using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using Mediator;

namespace Forum.Application.Core.Movies.Commands.DeleteMovie;

public record DeleteMovieCommand(
    Guid Id
) : IRequest<ErrorOr<Deleted>>;