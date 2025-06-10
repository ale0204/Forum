using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.Common.DataAccess.Entities;
using Forum.Application.Core.UsersManagement.Commands.RegisterUser;

namespace Forum.Application.Common.Mappings.Authentication;

public static class AddMovieCommandMapping
{
    public static UserEntity ToRepositoryEntity(this RegisterUserCommand registerUserCommand)
    {
        return new UserEntity()
        {
            Id = Guid.NewGuid(),
            Username = registerUserCommand.Username!,
            Password = registerUserCommand.Password!,
        };
    }
}

