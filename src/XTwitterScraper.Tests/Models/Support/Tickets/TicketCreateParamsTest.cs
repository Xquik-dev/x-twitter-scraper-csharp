using System;
using XTwitterScraper.Models.Support.Tickets;

namespace XTwitterScraper.Tests.Models.Support.Tickets;

public class TicketCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TicketCreateParams
        {
            Body = "I am unable to connect my X account. Please help.",
            Subject = "Cannot connect X account",
        };

        string expectedBody = "I am unable to connect my X account. Please help.";
        string expectedSubject = "Cannot connect X account";

        Assert.Equal(expectedBody, parameters.Body);
        Assert.Equal(expectedSubject, parameters.Subject);
    }

    [Fact]
    public void Url_Works()
    {
        TicketCreateParams parameters = new()
        {
            Body = "I am unable to connect my X account. Please help.",
            Subject = "Cannot connect X account",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/support/tickets"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TicketCreateParams
        {
            Body = "I am unable to connect my X account. Please help.",
            Subject = "Cannot connect X account",
        };

        TicketCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
