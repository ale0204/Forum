using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.DataAccess.Core.Repositories.Common.Factory;

public class RepositoryFactory : IRepositoryFactory
{
    private readonly IServiceProvider _serviceProvider;

    public RepositoryFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public TRepository CreateRepository<TRepository>() where TRepository : notnull
    {
        return _serviceProvider.GetRequiredService<TRepository>() ?? throw new ArgumentException();
    }

}
