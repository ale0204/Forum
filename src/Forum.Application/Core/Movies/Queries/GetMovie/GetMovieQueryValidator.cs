using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Forum.Application.Core.Movies.Queries.GetMovie;

public class GetMovieQueryValidator : AbstractValidator<GetMovieQuery>
{
    public GetMovieQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id cannot be empty!")
            .Must(id => id != Guid.Empty).WithMessage("Id cannot be empty!");
    }
}
