using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.OpenAq.HttpClients.Registrars;
using Soenneker.OpenAq.OpenApiClientUtil.Abstract;

namespace Soenneker.OpenAq.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class OpenAqOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="OpenAqOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddOpenAqOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddOpenAqOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IOpenAqOpenApiClientUtil, OpenAqOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="OpenAqOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddOpenAqOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddOpenAqOpenApiHttpClientAsSingleton()
                .TryAddScoped<IOpenAqOpenApiClientUtil, OpenAqOpenApiClientUtil>();

        return services;
    }
}
