using Soenneker.OpenAq.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.OpenAq.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IOpenAqOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<OpenAqOpenApiClient> Get(CancellationToken cancellationToken = default);
}
