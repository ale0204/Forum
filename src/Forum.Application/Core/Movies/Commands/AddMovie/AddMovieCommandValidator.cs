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
    {        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title cannot be empty!");
        
        RuleFor(x => x.Duration)
            .GreaterThan(0).When(x => x.Duration.HasValue)
            .WithMessage("Duration must be greater than 0 minutes!");
        
        RuleFor(x => x.Score)
            .InclusiveBetween(1f, 5f).When(x => x.Score.HasValue)
            .WithMessage("Score must be between 1 and 5!");
        
        RuleFor(x => x.LaunchDate)
            .Must(date => date == null || date.Value.Year >= 1900)
            .WithMessage("Launch year cannot be earlier than 1900!");
        
        RuleFor(x => x.LaunchDate)
            .Must(date => date == null || date.Value <= DateOnly.FromDateTime(DateTime.Now))
            .WithMessage("Launch date cannot be in the future!");
    }
}
