using Forum.Presentation.Web.Common.Api;

namespace Forum.Presentation.Web.Common.DependencyInjection;

public static class PresentationWebLayerServices
{
    public static IServiceCollection AddPresentationWebLayerServices(this IServiceCollection services)
    {
        services.AddHttpClient<IApiHttpClient, ApiHttpClient>();
        services.AddHttpContextAccessor();
        return services;
    }
}
