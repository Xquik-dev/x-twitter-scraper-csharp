using System;
using XTwitterScraper.Models.Styles;

namespace XTwitterScraper.Tests.Models.Styles;

public class StyleAnalyzeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new StyleAnalyzeParams { Username = "elonmusk" };

        string expectedUsername = "elonmusk";

        Assert.Equal(expectedUsername, parameters.Username);
    }

    [Fact]
    public void Url_Works()
    {
        StyleAnalyzeParams parameters = new() { Username = "elonmusk" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/styles"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new StyleAnalyzeParams { Username = "elonmusk" };

        StyleAnalyzeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
