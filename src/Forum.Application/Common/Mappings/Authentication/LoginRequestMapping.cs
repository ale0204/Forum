using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.Common.Contracts.Requests;
using Forum.Application.Core.UsersManagement.Queries.LoginUser;

namespace Forum.Application.Common.Mappings.Authentication;

public static class LoginRequestMapping
{
    public static LoginUserQuery ToCommand(this LoginRequest request)
    {
        return new LoginUserQuery(
            request.Username,
            request.Password
        );
    }
}

