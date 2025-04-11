using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.Common.DataAccess.Repositories.Common.Base;

namespace Forum.DataAccess.Core.Repositories.Common.Factory;

public interface IRepositoryFactory
{
    TRepository CreateRepository<TRepository>() where TRepository : notnull;
}
