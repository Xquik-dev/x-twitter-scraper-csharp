using System;
using XTwitterScraper.Models.X.Followers;

namespace XTwitterScraper.Tests.Models.X.Followers;

public class FollowerRetrieveCheckParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FollowerRetrieveCheckParams { Source = "source", Target = "target" };

        string expectedSource = "source";
        string expectedTarget = "target";

        Assert.Equal(expectedSource, parameters.Source);
        Assert.Equal(expectedTarget, parameters.Target);
    }

    [Fact]
    public void Url_Works()
    {
        FollowerRetrieveCheckParams parameters = new() { Source = "source", Target = "target" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri("https://xquik.com/api/v1/x/followers/check?source=source&target=target"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FollowerRetrieveCheckParams { Source = "source", Target = "target" };

        FollowerRetrieveCheckParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
