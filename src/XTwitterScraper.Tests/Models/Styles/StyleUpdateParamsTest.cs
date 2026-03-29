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
            Username = "username",
            Label = "label",
            Tweets = [new("text")],
        };

        string expectedUsername = "username";
        string expectedLabel = "label";
        List<Tweet> expectedTweets = [new("text")];

        Assert.Equal(expectedUsername, parameters.Username);
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
            Username = "username",
            Label = "label",
            Tweets = [new("text")],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/styles/username"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new StyleUpdateParams
        {
            Username = "username",
            Label = "label",
            Tweets = [new("text")],
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
        var model = new Tweet { Text = "text" };

        string expectedText = "text";

        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Tweet { Text = "text" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tweet>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Tweet { Text = "text" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tweet>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedText = "text";

        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Tweet { Text = "text" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Tweet { Text = "text" };

        Tweet copied = new(model);

        Assert.Equal(model, copied);
    }
}
