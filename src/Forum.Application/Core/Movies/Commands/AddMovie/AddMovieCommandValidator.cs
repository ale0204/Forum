using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Forum.Application.Core.Movies.Commands.AddMovie;

public class AddMovieCommandValidator : AbstractValidator<AddMovieCommand>
{
    public AddMovieCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title cannot be empty!");
        RuleFor(x => x.Duration)
            .GreaterThanOrEqualTo(1).WithMessage("Duration must be positive!");

    }
}
