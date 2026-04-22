using Soenneker.OpenAq.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.OpenAq.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class OpenAqOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IOpenAqOpenApiClientUtil _openapiclientutil;

    public OpenAqOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IOpenAqOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
