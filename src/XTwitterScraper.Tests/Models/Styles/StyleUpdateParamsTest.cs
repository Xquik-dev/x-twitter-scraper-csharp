using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Styles;

namespace XTwitterScraper.Tests.Models.Styles;

public class StyleUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new StyleUpdateParams
        {
            ID = "id",
            Label = "Professional Voice",
            Tweets = [new("Excited to share our latest research findings.")],
        };

        string expectedID = "id";
        string expectedLabel = "Professional Voice";
        List<Tweet> expectedTweets = [new("Excited to share our latest research findings.")];

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedLabel, parameters.Label);
        Assert.Equal(expectedTweets.Count, parameters.Tweets.Count);
        for (int i = 0; i < expectedTweets.Count; i++)
        {
            Assert.Equal(expectedTweets[i], parameters.Tweets[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        StyleUpdateParams parameters = new()
        {
            ID = "id",
            Label = "Professional Voice",
            Tweets = [new("Excited to share our latest research findings.")],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/styles/id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new StyleUpdateParams
        {
            ID = "id",
            Label = "Professional Voice",
            Tweets = [new("Excited to share our latest research findings.")],
        };

        StyleUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TweetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tweet { Text = "Excited to share our latest research findings." };

        string expectedText = "Excited to share our latest research findings.";

        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Tweet { Text = "Excited to share our latest research findings." };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tweet>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Tweet { Text = "Excited to share our latest research findings." };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tweet>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedText = "Excited to share our latest research findings.";

        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Tweet { Text = "Excited to share our latest research findings." };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Tweet { Text = "Excited to share our latest research findings." };

        Tweet copied = new(model);

        Assert.Equal(model, copied);
    }
}
