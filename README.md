[![](https://img.shields.io/nuget/v/soenneker.openaq.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.openaq.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.openaq.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.openaq.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.openaq.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.openaq.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.openaq.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.openaq.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.OpenAq.OpenApiClientUtil

Provides a configured OpenAQ API client and reuses it for the lifetime of the registered service.

## Installation

```bash
dotnet add package Soenneker.OpenAq.OpenApiClientUtil
```

## Configuration

```json
{
  "OpenAq": {
    "ApiKey": "your-api-key"
  }
}
```

## Usage

```csharp
using Soenneker.OpenAq.OpenApiClientUtil.Abstract;
using Soenneker.OpenAq.OpenApiClientUtil.Registrars;

services.AddOpenAqOpenApiClientUtilAsSingleton();

IOpenAqOpenApiClientUtil openAq = serviceProvider
    .GetRequiredService<IOpenAqOpenApiClientUtil>();

var client = await openAq.Get(cancellationToken);
var locations = await client.V3.Locations.GetAsync(request =>
{
    request.QueryParameters.Iso = "US";
    request.QueryParameters.Limit = 10;
}, cancellationToken);
```

Use `AddOpenAqOpenApiClientUtilAsScoped()` when each application scope should have its own generated client wrapper. The underlying authenticated HTTP provider remains shared and is disposed by the service container at shutdown.
