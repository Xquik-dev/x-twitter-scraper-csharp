using System;
using System.Net.Http;
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
            IdempotencyKey = "Idempotency-Key",
        };

        string expectedBody = "I am unable to connect my X account. Please help.";
        string expectedSubject = "Cannot connect X account";
        string expectedIdempotencyKey = "Idempotency-Key";

        Assert.Equal(expectedBody, parameters.Body);
        Assert.Equal(expectedSubject, parameters.Subject);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TicketCreateParams
        {
            Body = "I am unable to connect my X account. Please help.",
            Subject = "Cannot connect X account",
        };

        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TicketCreateParams
        {
            Body = "I am unable to connect my X account. Please help.",
            Subject = "Cannot connect X account",

            // Null should be interpreted as omitted for these properties
            IdempotencyKey = null,
        };

        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void Url_Works()
    {
        TicketCreateParams parameters = new()
        {
            Body = "I am unable to connect my X account. Please help.",
            Subject = "Cannot connect X account",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/support/tickets"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TicketCreateParams parameters = new()
        {
            Body = "I am unable to connect my X account. Please help.",
            Subject = "Cannot connect X account",
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
        var parameters = new TicketCreateParams
        {
            Body = "I am unable to connect my X account. Please help.",
            Subject = "Cannot connect X account",
            IdempotencyKey = "Idempotency-Key",
        };

        TicketCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
