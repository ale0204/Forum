using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Forum.Application.Core.Movies.Commands.UpdateMovie;

public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
{
    public UpdateMovieCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id cannot be empty!")
           .Must(id => id != Guid.Empty).WithMessage("Id cannot be empty!");
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title cannot be empty!");
        RuleFor(x => x.Duration)
            .GreaterThanOrEqualTo(1).WithMessage("Duration must be positive!");

    }
}