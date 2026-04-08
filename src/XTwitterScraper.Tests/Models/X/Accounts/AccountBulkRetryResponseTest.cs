using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Accounts;

namespace XTwitterScraper.Tests.Models.X.Accounts;

public class AccountBulkRetryResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountBulkRetryResponse { Cleared = 3 };

        long expectedCleared = 3;

        Assert.Equal(expectedCleared, model.Cleared);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountBulkRetryResponse { Cleared = 3 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountBulkRetryResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountBulkRetryResponse { Cleared = 3 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountBulkRetryResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCleared = 3;

        Assert.Equal(expectedCleared, deserialized.Cleared);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountBulkRetryResponse { Cleared = 3 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountBulkRetryResponse { Cleared = 3 };

        AccountBulkRetryResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
