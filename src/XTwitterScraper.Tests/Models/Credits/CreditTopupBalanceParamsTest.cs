using System;
using XTwitterScraper.Models.Credits;

namespace XTwitterScraper.Tests.Models.Credits;

public class CreditTopupBalanceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CreditTopupBalanceParams { Amount = 10000 };

        long expectedAmount = 10000;

        Assert.Equal(expectedAmount, parameters.Amount);
    }

    [Fact]
    public void Url_Works()
    {
        CreditTopupBalanceParams parameters = new() { Amount = 10000 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/credits/topup"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CreditTopupBalanceParams { Amount = 10000 };

        CreditTopupBalanceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
