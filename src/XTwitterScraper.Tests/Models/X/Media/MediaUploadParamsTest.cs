using System;
using System.Net.Http;
using XTwitterScraper.Models.X.Media;

namespace XTwitterScraper.Tests.Models.X.Media;

public class MediaUploadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MediaUploadParams
        {
            Account = "@elonmusk",
            UrlValue = "https://example.com/image.png",
            IdempotencyKey = "Idempotency-Key",
        };

        string expectedAccount = "@elonmusk";
        string expectedUrlValue = "https://example.com/image.png";
        string expectedIdempotencyKey = "Idempotency-Key";

        Assert.Equal(expectedAccount, parameters.Account);
        Assert.Equal(expectedUrlValue, parameters.UrlValue);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void Url_Works()
    {
        MediaUploadParams parameters = new()
        {
            Account = "@elonmusk",
            UrlValue = "https://example.com/image.png",
            IdempotencyKey = "Idempotency-Key",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/x/media"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        MediaUploadParams parameters = new()
        {
            Account = "@elonmusk",
            UrlValue = "https://example.com/image.png",
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
        var parameters = new MediaUploadParams
        {
            Account = "@elonmusk",
            UrlValue = "https://example.com/image.png",
            IdempotencyKey = "Idempotency-Key",
        };

        MediaUploadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
