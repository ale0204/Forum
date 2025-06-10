using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.Common.Contracts.Requests;
using Forum.Application.Core.UsersManagement.Commands.RegisterUser;

namespace Forum.Application.Common.Mappings.Authentication;

public static class RegistrationRequestMapping
{
    public static RegisterUserCommand ToCommand(this RegistrationRequest request)
    {
        return new RegisterUserCommand(
            request.Username,
            request.Password,
            request.PasswordConfirm
        );
    }
}
