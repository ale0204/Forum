using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.Common.DataAccess.Entities.Common;
using ErrorOr;
using System.Threading;

namespace Forum.Application.Common.DataAccess.Repositories.Common.Actions;

public interface IGetByIdRepositoryAction<TEntity> where TEntity : IStorageEntity
{
    Task<ErrorOr<TEntity?>> GetByIdAsync(Guid id, CancellationToken token);
}
