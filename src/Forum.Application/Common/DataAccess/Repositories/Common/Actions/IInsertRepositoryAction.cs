using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using Forum.Application.Common.DataAccess.Entities.Common;

namespace Forum.Application.Common.DataAccess.Repositories.Common.Actions;

public interface IInsertRepositoryAction<TEntity> where TEntity : IStorageEntity
{
    Task<ErrorOr<Created>> InsertAsync(TEntity entity, CancellationToken token);
}
