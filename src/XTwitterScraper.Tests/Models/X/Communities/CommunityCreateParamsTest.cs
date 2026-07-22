using System;
using System.Net.Http;
using XTwitterScraper.Models.X.Communities;

namespace XTwitterScraper.Tests.Models.X.Communities;

public class CommunityCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CommunityCreateParams
        {
            Account = "@elonmusk",
            Name = "Example Name",
            IdempotencyKey = "Idempotency-Key",
            Description = "A community for Tesla enthusiasts",
        };

        string expectedAccount = "@elonmusk";
        string expectedName = "Example Name";
        string expectedIdempotencyKey = "Idempotency-Key";
        string expectedDescription = "A community for Tesla enthusiasts";

        Assert.Equal(expectedAccount, parameters.Account);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedDescription, parameters.Description);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CommunityCreateParams
        {
            Account = "@elonmusk",
            Name = "Example Name",
            IdempotencyKey = "Idempotency-Key",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CommunityCreateParams
        {
            Account = "@elonmusk",
            Name = "Example Name",
            IdempotencyKey = "Idempotency-Key",

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        CommunityCreateParams parameters = new()
        {
            Account = "@elonmusk",
            Name = "Example Name",
            IdempotencyKey = "Idempotency-Key",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/x/communities"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CommunityCreateParams parameters = new()
        {
            Account = "@elonmusk",
            Name = "Example Name",
            IdempotencyKey = "Idempotency-Key",
        };

        parameters.AddHeadersToRequest(
            requestMessage,
            new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" }
        );

        Assert.Equal(["Idempotency-Key"], requestMessage.Headers.GetValues("Idempotency-Key"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CommunityCreateParams
        {
            Account = "@elonmusk",
            Name = "Example Name",
            IdempotencyKey = "Idempotency-Key",
            Description = "A community for Tesla enthusiasts",
        };

        CommunityCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
