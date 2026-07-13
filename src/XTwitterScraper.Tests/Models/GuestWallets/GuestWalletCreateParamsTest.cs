using System;
using System.Net.Http;
using System.Text.Json;
using XTwitterScraper.Models.GuestWallets;

namespace XTwitterScraper.Tests.Models.GuestWallets;

public class GuestWalletCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GuestWalletCreateParams
        {
            AmountMinor = 1000,
            IdempotencyKey = "e1cb97D8-dDF3-4AaA-ad0a-49E4A0d1CfAa",
        };

        long expectedAmountMinor = 1000;
        JsonElement expectedCurrency = JsonSerializer.SerializeToElement("usd");
        string expectedIdempotencyKey = "e1cb97D8-dDF3-4AaA-ad0a-49E4A0d1CfAa";

        Assert.Equal(expectedAmountMinor, parameters.AmountMinor);
        Assert.True(JsonElement.DeepEquals(expectedCurrency, parameters.Currency));
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void Url_Works()
    {
        GuestWalletCreateParams parameters = new()
        {
            AmountMinor = 1000,
            Currency = JsonSerializer.SerializeToElement("usd"),
            IdempotencyKey = "e1cb97D8-dDF3-4AaA-ad0a-49E4A0d1CfAa",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/guest-wallets"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        GuestWalletCreateParams parameters = new()
        {
            AmountMinor = 1000,
            Currency = JsonSerializer.SerializeToElement("usd"),
            IdempotencyKey = "e1cb97D8-dDF3-4AaA-ad0a-49E4A0d1CfAa",
        };

        parameters.AddHeadersToRequest(
            requestMessage,
            new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" }
        );

        Assert.Equal(
            ["e1cb97D8-dDF3-4AaA-ad0a-49E4A0d1CfAa"],
            requestMessage.Headers.GetValues("Idempotency-Key")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GuestWalletCreateParams
        {
            AmountMinor = 1000,
            IdempotencyKey = "e1cb97D8-dDF3-4AaA-ad0a-49E4A0d1CfAa",
        };

        GuestWalletCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
