using System;
using XTwitterScraper.Models.Credits;

namespace XTwitterScraper.Tests.Models.Credits;

public class CreditTopupBalanceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CreditTopupBalanceParams { Dollars = 10, Locale = "en" };

        long expectedDollars = 10;
        string expectedLocale = "en";

        Assert.Equal(expectedDollars, parameters.Dollars);
        Assert.Equal(expectedLocale, parameters.Locale);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CreditTopupBalanceParams { Dollars = 10 };

        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawBodyData.ContainsKey("locale"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CreditTopupBalanceParams
        {
            Dollars = 10,

            // Null should be interpreted as omitted for these properties
            Locale = null,
        };

        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawBodyData.ContainsKey("locale"));
    }

    [Fact]
    public void Url_Works()
    {
        CreditTopupBalanceParams parameters = new() { Dollars = 10 };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/credits/topup"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CreditTopupBalanceParams { Dollars = 10, Locale = "en" };

        CreditTopupBalanceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
