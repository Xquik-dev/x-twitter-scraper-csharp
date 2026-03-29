using System;
using XTwitterScraper.Models.ApiKeys;

namespace XTwitterScraper.Tests.Models.ApiKeys;

public class ApiKeyCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ApiKeyCreateParams { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ApiKeyCreateParams { };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ApiKeyCreateParams
        {
            // Null should be interpreted as omitted for these properties
            Name = null,
        };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        ApiKeyCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/api-keys"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ApiKeyCreateParams { Name = "name" };

        ApiKeyCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
