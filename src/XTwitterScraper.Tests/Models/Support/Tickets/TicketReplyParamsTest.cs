using System;
using XTwitterScraper.Models.Support.Tickets;

namespace XTwitterScraper.Tests.Models.Support.Tickets;

public class TicketReplyParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TicketReplyParams { ID = "id", Body = "Thank you for the update." };

        string expectedID = "id";
        string expectedBody = "Thank you for the update.";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedBody, parameters.Body);
    }

    [Fact]
    public void Url_Works()
    {
        TicketReplyParams parameters = new() { ID = "id", Body = "Thank you for the update." };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/support/tickets/id/messages"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TicketReplyParams { ID = "id", Body = "Thank you for the update." };

        TicketReplyParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
