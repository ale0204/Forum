using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Forum.Application.Core.UsersManagement.Commands.RegisterUser;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterUserCommandValidator"/> class.
    /// </summary>

    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Username).NotEmpty().WithMessage("Username cannot be empty!")
            .Length(3, 255).WithMessage("Username must be between 3 and 255 characters!")
            .Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]*[a-zA-Z0-9]$") // only allow letters, numbers, dots, underscores and hyphens, and must start and end with letter or number
            .WithMessage("Invalid username!");

        RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty!")
            .Matches("^(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$").WithMessage("Password must contain one lowercase and one uppercase character, one number and one symbol, and must be at least 8 characters long!");

        RuleFor(x => x.PasswordConfirm).NotEmpty().WithMessage("Password confirmation cannot be empty!");

        RuleFor(x => x.Password).Equal(x => x.PasswordConfirm).WithMessage("Password and password confirmation do not match!");
    }

}

