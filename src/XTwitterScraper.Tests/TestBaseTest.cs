using System;

namespace XTwitterScraper.Tests;

public class TestBaseTest
{
    [Fact]
    public void UrisEqual_IgnoresQueryOrder()
    {
        var first = new Uri("https://xquik.com/api/v1/x/trends?count=1&woeid=0");
        var second = new Uri("https://xquik.com/api/v1/x/trends?woeid=0&count=1");

        Assert.True(TestBase.UrisEqual(first, second));
    }

    [Fact]
    public void UrisEqual_DetectsDifferentQueryValues()
    {
        var first = new Uri("https://xquik.com/api/v1/x/trends?count=1");
        var second = new Uri("https://xquik.com/api/v1/x/trends?count=2");

        Assert.False(TestBase.UrisEqual(first, second));
    }
}
