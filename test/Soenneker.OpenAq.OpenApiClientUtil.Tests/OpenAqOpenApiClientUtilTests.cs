using Soenneker.OpenAq.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.OpenAq.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class OpenAqOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IOpenAqOpenApiClientUtil _openapiclientutil;

    public OpenAqOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IOpenAqOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
