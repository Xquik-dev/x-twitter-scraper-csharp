using System;
using XTwitterScraper.Models.Styles;

namespace XTwitterScraper.Tests.Models.Styles;

public class StyleCompareParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new StyleCompareParams
        {
            Username1 = "username1",
            Username2 = "username2",
        };

        string expectedUsername1 = "username1";
        string expectedUsername2 = "username2";

        Assert.Equal(expectedUsername1, parameters.Username1);
        Assert.Equal(expectedUsername2, parameters.Username2);
    }

    [Fact]
    public void Url_Works()
    {
        StyleCompareParams parameters = new() { Username1 = "username1", Username2 = "username2" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://xquik.com/api/v1/styles/compare?username1=username1&username2=username2"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new StyleCompareParams
        {
            Username1 = "username1",
            Username2 = "username2",
        };

        StyleCompareParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
