using System.Text.Json.Serialization;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.Presentation.Api.Common.DependencyInjection;

public static class PresentationApiLayerServices
{
    public static IServiceCollection AddPresentationApiLayerServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add services to the container.
        services.AddAuthorization();

        services.AddFastEndpoints(endpointDiscoveryOptions => endpointDiscoveryOptions.Assemblies = [typeof(Program).Assembly]);

        services.AddOpenApi();

        services.SwaggerDocument(documentOptions =>
        {
            documentOptions.EnableJWTBearerAuth = true;
            documentOptions.SerializerSettings = jsonSerializerOptions =>
            {
                jsonSerializerOptions.PropertyNamingPolicy = null;
                jsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            };
            documentOptions.MaxEndpointVersion = 1;
            documentOptions.MinEndpointVersion = 1;
            documentOptions.DocumentSettings = aspNetCoreOpenApiDocumentGeneratorSettings =>
            {
                aspNetCoreOpenApiDocumentGeneratorSettings.DocumentName = "v1";
                aspNetCoreOpenApiDocumentGeneratorSettings.Title = "Forum API v1";
                aspNetCoreOpenApiDocumentGeneratorSettings.Version = "v1";
            };
            documentOptions.RemoveEmptyRequestSchema = true;
            documentOptions.ShortSchemaNames = true;
        });
        return services;
    }
}
