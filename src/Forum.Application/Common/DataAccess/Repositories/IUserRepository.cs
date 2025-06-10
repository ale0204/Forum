using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using Forum.Application.Common.DataAccess.Entities;
using Forum.Application.Common.DataAccess.Repositories.Common.Actions;
using Forum.Application.Common.DataAccess.Repositories.Common.Base;

namespace Forum.Application.Common.DataAccess.Repositories;

public interface IUserRepository : IRepository<UserEntity>,
    IInsertRepositoryAction<UserEntity>,
    IGetByIdRepositoryAction<UserEntity>,
    IUpdateRepositoryAction<UserEntity>
{
    Task<ErrorOr<UserEntity?>> GetByUsernameAsync(string username, CancellationToken cancellationToken);
}
