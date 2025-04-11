using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Forum.Application.Common.DataAccess.UoW;
using Forum.DataAccess.Core.Repositories.Common.Factory;

namespace Forum.DataAccess.Core.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly IRepositoryFactory _repositoryFactory;
    private readonly ForumDbContext _forumDbContext;

    public UnitOfWork(IRepositoryFactory repositoryFactory, ForumDbContext forumDbContext)
    {
        _repositoryFactory = repositoryFactory;
        _forumDbContext = forumDbContext;
    }
    public TRepository GetRepository<TRepository>() where TRepository : notnull
    {
        return _repositoryFactory.CreateRepository<TRepository>();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _forumDbContext.SaveChangesAsync(cancellationToken);
    }
}
