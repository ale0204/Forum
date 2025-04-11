using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.Common.DataAccess.Entities.Common;

namespace Forum.Application.Common.DataAccess.Repositories.Common.Base;

public interface IRepository<TEntity> where TEntity : IStorageEntity
{
}
