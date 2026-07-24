// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net.Http;
using XTwitterScraper.Models.Support.Tickets;

namespace XTwitterScraper.Tests.Models.Support.Tickets;

public class TicketReplyParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TicketReplyParams
        {
            ID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            Body = "Thank you for the update.",
            IdempotencyKey = "Idempotency-Key",
        };

        string expectedID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6";
        string expectedBody = "Thank you for the update.";
        string expectedIdempotencyKey = "Idempotency-Key";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedBody, parameters.Body);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TicketReplyParams
        {
            ID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            Body = "Thank you for the update.",
        };

        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TicketReplyParams
        {
            ID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            Body = "Thank you for the update.",

            // Null should be interpreted as omitted for these properties
            IdempotencyKey = null,
        };

        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
    }

    [Fact]
    public void Url_Works()
    {
        TicketReplyParams parameters = new()
        {
            ID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            Body = "Thank you for the update.",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://xquik.com/api/v1/support/tickets/tkt_a1b2c3d4e5f6a1b2c3d4e5f6/messages"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TicketReplyParams parameters = new()
        {
            ID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            Body = "Thank you for the update.",
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
        var parameters = new TicketReplyParams
        {
            ID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            Body = "Thank you for the update.",
            IdempotencyKey = "Idempotency-Key",
        };

        TicketReplyParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
