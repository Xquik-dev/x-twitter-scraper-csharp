// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading.Tasks;
using XTwitterScraper.Models.Support.Tickets;

namespace XTwitterScraper.Tests.Services.Support;

public class TicketServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var ticket = await this.client.Support.Tickets.Create(
            new()
            {
                Body = "I am unable to connect my X account. Please help.",
                Subject = "Cannot connect X account",
            },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(ticket);
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var ticket = await this.client.Support.Tickets.Retrieve(
            "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(ticket);
    }

    [Fact]
    public async Task Update_Works()
    {
        var ticket = await this.client.Support.Tickets.Update(
            "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            new() { Status = Status.Resolved },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(ticket);
    }

    [Fact]
    public async Task List_Works()
    {
        var tickets = await this.client.Support.Tickets.List(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(tickets);
    }

    [Fact]
    public async Task Reply_Works()
    {
        var response = await this.client.Support.Tickets.Reply(
            "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            new() { Body = "Thank you for the update." },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }
}
