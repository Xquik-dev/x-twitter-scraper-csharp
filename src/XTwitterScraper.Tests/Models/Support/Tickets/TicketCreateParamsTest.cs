using System;
using XTwitterScraper.Models.Support.Tickets;

namespace XTwitterScraper.Tests.Models.Support.Tickets;

public class TicketCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TicketCreateParams { Body = "body", Subject = "subject" };

        string expectedBody = "body";
        string expectedSubject = "subject";

        Assert.Equal(expectedBody, parameters.Body);
        Assert.Equal(expectedSubject, parameters.Subject);
    }

    [Fact]
    public void Url_Works()
    {
        TicketCreateParams parameters = new() { Body = "body", Subject = "subject" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/support/tickets"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TicketCreateParams { Body = "body", Subject = "subject" };

        TicketCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
