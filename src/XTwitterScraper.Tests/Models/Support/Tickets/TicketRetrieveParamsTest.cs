using System;
using XTwitterScraper.Models.Support.Tickets;

namespace XTwitterScraper.Tests.Models.Support.Tickets;

public class TicketRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TicketRetrieveParams { ID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6" };

        string expectedID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        TicketRetrieveParams parameters = new() { ID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://xquik.com/api/v1/support/tickets/tkt_a1b2c3d4e5f6a1b2c3d4e5f6"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TicketRetrieveParams { ID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6" };

        TicketRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
