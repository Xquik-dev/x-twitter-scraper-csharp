using System;
using XTwitterScraper.Models.ApiKeys;

namespace XTwitterScraper.Tests.Models.ApiKeys;

public class ApiKeyRevokeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ApiKeyRevokeParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ApiKeyRevokeParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/api-keys/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ApiKeyRevokeParams { ID = "id" };

        ApiKeyRevokeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
