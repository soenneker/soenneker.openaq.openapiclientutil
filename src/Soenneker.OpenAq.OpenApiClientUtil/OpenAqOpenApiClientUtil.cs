using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.OpenAq.HttpClients.Abstract;
using Soenneker.OpenAq.OpenApiClientUtil.Abstract;
using Soenneker.OpenAq.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.OpenAq.OpenApiClientUtil;

///<inheritdoc cref="IOpenAqOpenApiClientUtil"/>
public sealed class OpenAqOpenApiClientUtil : IOpenAqOpenApiClientUtil
{
    private readonly AsyncSingleton<OpenAqOpenApiClient> _client;

    public OpenAqOpenApiClientUtil(IOpenAqOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<OpenAqOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("OpenAq:ApiKey");
            string authHeaderValueTemplate = configuration["OpenAq:AuthHeaderValueTemplate"] ?? "{token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

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
