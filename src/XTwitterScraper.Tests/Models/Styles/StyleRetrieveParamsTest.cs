using System;
using XTwitterScraper.Models.Styles;

namespace XTwitterScraper.Tests.Models.Styles;

public class StyleRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new StyleRetrieveParams { Username = "username" };

        string expectedUsername = "username";

        Assert.Equal(expectedUsername, parameters.Username);
    }

    [Fact]
    public void Url_Works()
    {
        StyleRetrieveParams parameters = new() { Username = "username" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/styles/username"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new StyleRetrieveParams { Username = "username" };

        StyleRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
