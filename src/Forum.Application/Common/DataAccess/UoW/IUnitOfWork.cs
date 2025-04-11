using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Common.DataAccess.UoW;

public interface IUnitOfWork
{
    TRepository GetRepository<TRepository>() where TRepository : notnull;
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
