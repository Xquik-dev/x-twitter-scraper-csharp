using System.Threading.Tasks;
using XTwitterScraper.Models.Support.Tickets;

namespace XTwitterScraper.Tests.Services.Support;

public class TicketServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var ticket = await this.client.Support.Tickets.Create(
            new() { Body = "body", Subject = "subject" },
            TestContext.Current.CancellationToken
        );
        ticket.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var ticket = await this.client.Support.Tickets.Retrieve(
            "id",
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
            new() { Status = Status.Open },
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
            new() { Body = "body" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
