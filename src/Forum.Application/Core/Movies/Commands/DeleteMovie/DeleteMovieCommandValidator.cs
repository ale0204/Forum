using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Forum.Application.Core.Movies.Commands.DeleteMovie;

public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
{
    public DeleteMovieCommandValidator() 
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id cannot be empty!")
            .Must(id => id != Guid.Empty).WithMessage("Id cannot be empty!");
    }
}
