using System;
using XTwitterScraper.Models.Support.Tickets;

namespace XTwitterScraper.Tests.Models.Support.Tickets;

public class TicketRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TicketRetrieveParams { ID = "messages_value" };

        string expectedID = "messages_value";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        TicketRetrieveParams parameters = new() { ID = "messages_value" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://xquik.com/api/v1/support/tickets/messages_value"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TicketRetrieveParams { ID = "messages_value" };

        TicketRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
