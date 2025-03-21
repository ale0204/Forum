using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Forum.Application.Common.Behaviours;
using Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.Application.Common.DependencyInjection;

public static class ApplicationLayerServices
{
    public static IServiceCollection AddApplicationLayerServices(this IServiceCollection services)
    {
        services.AddMediator(options =>
        {
            options.ServiceLifetime = ServiceLifetime.Scoped;
        });
        services.AddValidatorsFromAssembly(typeof(ApplicationLayerServices).Assembly);

        // register the validation behavior
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}
