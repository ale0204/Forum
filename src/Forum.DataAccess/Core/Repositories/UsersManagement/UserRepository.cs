using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using Forum.Application.Common.DataAccess.Entities;
using Forum.Application.Common.DataAccess.Repositories;
using Forum.DataAccess.Core.UoW;
using Microsoft.EntityFrameworkCore;
using Forum.Domain.Common.Errors;
namespace Forum.DataAccess.Core.Repositories.UsersManagement;

internal class UserRepository : IUserRepository
{
    private readonly ForumDbContext _context;

    public UserRepository(ForumDbContext context)
    {
        _context = context;
    }

    public async Task<ErrorOr<UserEntity?>> GetByIdAsync(Guid id, CancellationToken token)
    {
        UserEntity? user = await _context.Users.SingleOrDefaultAsync(user => user.Id == id, token);
        if (user is null)
            return Errors.Users.UserDoesNotExist;
        return user;
    }

    public async Task<ErrorOr<Created>> InsertAsync(UserEntity entity, CancellationToken token)
    {
        bool userExists = await _context.Users.AnyAsync(user => user.Id == entity.Id, token);
        if (userExists)
            return Errors.Users.UserAlreadyExists;
        _context.Users.Add(entity);
        return Result.Created;
    }

    public async Task<ErrorOr<Updated>> UpdateAsync(UserEntity entity, CancellationToken token)
    {
        UserEntity? user = await _context.Users.SingleOrDefaultAsync(user => user.Id == entity.Id, token);
        if (user is null)
            return Errors.Users.UserDoesNotExist;
        _context.Entry(user).CurrentValues.SetValues(entity);
        return Result.Updated;
    }

    public async Task<ErrorOr<UserEntity?>> GetByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        return await _context.Users
            .FirstOrDefaultAsync(user => user.Username == username, cancellationToken)
            .ConfigureAwait(false);
    }
}
