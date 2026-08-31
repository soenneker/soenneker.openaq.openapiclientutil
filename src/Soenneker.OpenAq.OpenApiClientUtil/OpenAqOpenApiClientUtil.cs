using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.OpenAq.HttpClients.Abstract;
using Soenneker.OpenAq.OpenApiClient;
using Soenneker.OpenAq.OpenApiClientUtil.Abstract;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.OpenAq.OpenApiClientUtil;

public sealed class OpenAqOpenApiClientUtil : IOpenAqOpenApiClientUtil
{
    private readonly AsyncSingleton<OpenAqOpenApiClient> _client;

    public OpenAqOpenApiClientUtil(IOpenAqOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<OpenAqOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            if (httpClient.BaseAddress is not null)
                requestAdapter.BaseUrl = httpClient.BaseAddress.ToString().TrimEnd('/');

            return new OpenAqOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<OpenAqOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
