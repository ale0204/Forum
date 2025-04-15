using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Forum.Application.Common.DataAccess.Entities.Common;

namespace Forum.Application.Common.DataAccess.Repositories.Common.Actions;

public interface IGetAllRepositoryAction<TEntity> where TEntity : IStorageEntity
{
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
}
