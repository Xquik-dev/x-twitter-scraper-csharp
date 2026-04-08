using System.Threading.Tasks;
using XTwitterScraper.Models.Support.Tickets;

namespace XTwitterScraper.Tests.Services.Support;

public class TicketServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
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
        ticket.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var ticket = await this.client.Support.Tickets.Retrieve(
            "messages_value",
            new(),
            TestContext.Current.CancellationToken
        );
        ticket.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var ticket = await this.client.Support.Tickets.Update(
            "id",
            new() { Status = Status.Resolved },
            TestContext.Current.CancellationToken
        );
        ticket.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var tickets = await this.client.Support.Tickets.List(
            new(),
            TestContext.Current.CancellationToken
        );
        tickets.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Reply_Works()
    {
        var response = await this.client.Support.Tickets.Reply(
            "id",
            new() { Body = "Thank you for the update." },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
