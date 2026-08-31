using Soenneker.OpenAq.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.OpenAq.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached OpenAQ API client backed by the configured HTTP provider.
/// </summary>
public interface IOpenAqOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached OpenAQ client, creating it on the first call.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The configured OpenAQ client.</returns>
    ValueTask<OpenAqOpenApiClient> Get(CancellationToken cancellationToken = default);
}
