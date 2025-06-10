using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Forum.Application.Core.UsersManagement.Queries.LoginUser;

public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LoginUserQueryValidator"/> class.
    /// </summary>

    public LoginUserQueryValidator()
    {
        RuleFor(x => x.Username).NotEmpty().WithMessage("Username cannot be empty!");

        RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty!")
            .Matches("^(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$").WithMessage("Password must contain one lowercase and one uppercase character, one number and one symbol, and must be at least 8 characters long!");
    }

}
