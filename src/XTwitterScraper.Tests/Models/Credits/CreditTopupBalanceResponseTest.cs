using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Credits;

namespace XTwitterScraper.Tests.Models.Credits;

public class CreditTopupBalanceResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditTopupBalanceResponse
        {
            RedirectUrl = "https://xquik.com/api/v1/credits/topup/redirect?session_id=cs_test_123",
            Url = "https://xquik.com/api/v1/credits/topup/redirect?session_id=cs_test_123",
        };

        string expectedRedirectUrl =
            "https://xquik.com/api/v1/credits/topup/redirect?session_id=cs_test_123";
        string expectedUrl =
            "https://xquik.com/api/v1/credits/topup/redirect?session_id=cs_test_123";

        Assert.Equal(expectedRedirectUrl, model.RedirectUrl);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditTopupBalanceResponse
        {
            RedirectUrl = "https://xquik.com/api/v1/credits/topup/redirect?session_id=cs_test_123",
            Url = "https://xquik.com/api/v1/credits/topup/redirect?session_id=cs_test_123",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditTopupBalanceResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditTopupBalanceResponse
        {
            RedirectUrl = "https://xquik.com/api/v1/credits/topup/redirect?session_id=cs_test_123",
            Url = "https://xquik.com/api/v1/credits/topup/redirect?session_id=cs_test_123",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditTopupBalanceResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRedirectUrl =
            "https://xquik.com/api/v1/credits/topup/redirect?session_id=cs_test_123";
        string expectedUrl =
            "https://xquik.com/api/v1/credits/topup/redirect?session_id=cs_test_123";

        Assert.Equal(expectedRedirectUrl, deserialized.RedirectUrl);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditTopupBalanceResponse
        {
            RedirectUrl = "https://xquik.com/api/v1/credits/topup/redirect?session_id=cs_test_123",
            Url = "https://xquik.com/api/v1/credits/topup/redirect?session_id=cs_test_123",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditTopupBalanceResponse
        {
            RedirectUrl = "https://xquik.com/api/v1/credits/topup/redirect?session_id=cs_test_123",
            Url = "https://xquik.com/api/v1/credits/topup/redirect?session_id=cs_test_123",
        };

        CreditTopupBalanceResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
