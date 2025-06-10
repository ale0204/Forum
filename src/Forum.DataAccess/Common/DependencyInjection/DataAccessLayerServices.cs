using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.Common.DataAccess.Repositories;
using Forum.Application.Common.DataAccess.UoW;
using Forum.DataAccess.Core.Repositories.Common.Factory;
using Forum.DataAccess.Core.Repositories.Movies;
using Forum.DataAccess.Core.Repositories.UsersManagement;
using Forum.DataAccess.Core.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;

namespace Forum.DataAccess.Common.DependencyInjection;

public static class DataAccessLayerServices
{
    public static void AddDataAccessLayerServices(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddDbContext<ForumDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyDataBase")));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRepositoryFactory, RepositoryFactory>();
    }
}
