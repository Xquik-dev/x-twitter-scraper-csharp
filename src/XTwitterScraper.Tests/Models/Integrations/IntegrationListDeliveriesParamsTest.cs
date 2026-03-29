using System;
using XTwitterScraper.Models.Integrations;

namespace XTwitterScraper.Tests.Models.Integrations;

public class IntegrationListDeliveriesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntegrationListDeliveriesParams { ID = "id", Limit = 1 };

        string expectedID = "id";
        long expectedLimit = 1;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IntegrationListDeliveriesParams { ID = "id" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new IntegrationListDeliveriesParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        IntegrationListDeliveriesParams parameters = new() { ID = "id", Limit = 1 };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/integrations/id/deliveries?limit=1"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IntegrationListDeliveriesParams { ID = "id", Limit = 1 };

        IntegrationListDeliveriesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
