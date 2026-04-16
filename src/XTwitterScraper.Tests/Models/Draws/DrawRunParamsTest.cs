using System;
using System.Collections.Generic;
using XTwitterScraper.Models.Draws;

namespace XTwitterScraper.Tests.Models.Draws;

public class DrawRunParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DrawRunParams
        {
            TweetUrl = "https://x.com/elonmusk/status/1234567890",
            BackupCount = 2,
            FilterAccountAgeDays = 30,
            FilterLanguage = "en",
            FilterMinFollowers = 50,
            MustFollowUsername = "elonmusk",
            MustRetweet = true,
            RequiredHashtags = ["#giveaway"],
            RequiredKeywords = ["entered"],
            RequiredMentions = ["@elonmusk"],
            UniqueAuthorsOnly = true,
            WinnerCount = 3,
        };

        string expectedTweetUrl = "https://x.com/elonmusk/status/1234567890";
        long expectedBackupCount = 2;
        long expectedFilterAccountAgeDays = 30;
        string expectedFilterLanguage = "en";
        long expectedFilterMinFollowers = 50;
        string expectedMustFollowUsername = "elonmusk";
        bool expectedMustRetweet = true;
        List<string> expectedRequiredHashtags = ["#giveaway"];
        List<string> expectedRequiredKeywords = ["entered"];
        List<string> expectedRequiredMentions = ["@elonmusk"];
        bool expectedUniqueAuthorsOnly = true;
        long expectedWinnerCount = 3;

        Assert.Equal(expectedTweetUrl, parameters.TweetUrl);
        Assert.Equal(expectedBackupCount, parameters.BackupCount);
        Assert.Equal(expectedFilterAccountAgeDays, parameters.FilterAccountAgeDays);
        Assert.Equal(expectedFilterLanguage, parameters.FilterLanguage);
        Assert.Equal(expectedFilterMinFollowers, parameters.FilterMinFollowers);
        Assert.Equal(expectedMustFollowUsername, parameters.MustFollowUsername);
        Assert.Equal(expectedMustRetweet, parameters.MustRetweet);
        Assert.NotNull(parameters.RequiredHashtags);
        Assert.Equal(expectedRequiredHashtags.Count, parameters.RequiredHashtags.Count);
        for (int i = 0; i < expectedRequiredHashtags.Count; i++)
        {
            Assert.Equal(expectedRequiredHashtags[i], parameters.RequiredHashtags[i]);
        }
        Assert.NotNull(parameters.RequiredKeywords);
        Assert.Equal(expectedRequiredKeywords.Count, parameters.RequiredKeywords.Count);
        for (int i = 0; i < expectedRequiredKeywords.Count; i++)
        {
            Assert.Equal(expectedRequiredKeywords[i], parameters.RequiredKeywords[i]);
        }
        Assert.NotNull(parameters.RequiredMentions);
        Assert.Equal(expectedRequiredMentions.Count, parameters.RequiredMentions.Count);
        for (int i = 0; i < expectedRequiredMentions.Count; i++)
        {
            Assert.Equal(expectedRequiredMentions[i], parameters.RequiredMentions[i]);
        }
        Assert.Equal(expectedUniqueAuthorsOnly, parameters.UniqueAuthorsOnly);
        Assert.Equal(expectedWinnerCount, parameters.WinnerCount);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DrawRunParams
        {
            TweetUrl = "https://x.com/elonmusk/status/1234567890",
        };

        Assert.Null(parameters.BackupCount);
        Assert.False(parameters.RawBodyData.ContainsKey("backupCount"));
        Assert.Null(parameters.FilterAccountAgeDays);
        Assert.False(parameters.RawBodyData.ContainsKey("filterAccountAgeDays"));
        Assert.Null(parameters.FilterLanguage);
        Assert.False(parameters.RawBodyData.ContainsKey("filterLanguage"));
        Assert.Null(parameters.FilterMinFollowers);
        Assert.False(parameters.RawBodyData.ContainsKey("filterMinFollowers"));
        Assert.Null(parameters.MustFollowUsername);
        Assert.False(parameters.RawBodyData.ContainsKey("mustFollowUsername"));
        Assert.Null(parameters.MustRetweet);
        Assert.False(parameters.RawBodyData.ContainsKey("mustRetweet"));
        Assert.Null(parameters.RequiredHashtags);
        Assert.False(parameters.RawBodyData.ContainsKey("requiredHashtags"));
        Assert.Null(parameters.RequiredKeywords);
        Assert.False(parameters.RawBodyData.ContainsKey("requiredKeywords"));
        Assert.Null(parameters.RequiredMentions);
        Assert.False(parameters.RawBodyData.ContainsKey("requiredMentions"));
        Assert.Null(parameters.UniqueAuthorsOnly);
        Assert.False(parameters.RawBodyData.ContainsKey("uniqueAuthorsOnly"));
        Assert.Null(parameters.WinnerCount);
        Assert.False(parameters.RawBodyData.ContainsKey("winnerCount"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DrawRunParams
        {
            TweetUrl = "https://x.com/elonmusk/status/1234567890",

            // Null should be interpreted as omitted for these properties
            BackupCount = null,
            FilterAccountAgeDays = null,
            FilterLanguage = null,
            FilterMinFollowers = null,
            MustFollowUsername = null,
            MustRetweet = null,
            RequiredHashtags = null,
            RequiredKeywords = null,
            RequiredMentions = null,
            UniqueAuthorsOnly = null,
            WinnerCount = null,
        };

        Assert.Null(parameters.BackupCount);
        Assert.False(parameters.RawBodyData.ContainsKey("backupCount"));
        Assert.Null(parameters.FilterAccountAgeDays);
        Assert.False(parameters.RawBodyData.ContainsKey("filterAccountAgeDays"));
        Assert.Null(parameters.FilterLanguage);
        Assert.False(parameters.RawBodyData.ContainsKey("filterLanguage"));
        Assert.Null(parameters.FilterMinFollowers);
        Assert.False(parameters.RawBodyData.ContainsKey("filterMinFollowers"));
        Assert.Null(parameters.MustFollowUsername);
        Assert.False(parameters.RawBodyData.ContainsKey("mustFollowUsername"));
        Assert.Null(parameters.MustRetweet);
        Assert.False(parameters.RawBodyData.ContainsKey("mustRetweet"));
        Assert.Null(parameters.RequiredHashtags);
        Assert.False(parameters.RawBodyData.ContainsKey("requiredHashtags"));
        Assert.Null(parameters.RequiredKeywords);
        Assert.False(parameters.RawBodyData.ContainsKey("requiredKeywords"));
        Assert.Null(parameters.RequiredMentions);
        Assert.False(parameters.RawBodyData.ContainsKey("requiredMentions"));
        Assert.Null(parameters.UniqueAuthorsOnly);
        Assert.False(parameters.RawBodyData.ContainsKey("uniqueAuthorsOnly"));
        Assert.Null(parameters.WinnerCount);
        Assert.False(parameters.RawBodyData.ContainsKey("winnerCount"));
    }

    [Fact]
    public void Url_Works()
    {
        DrawRunParams parameters = new() { TweetUrl = "https://x.com/elonmusk/status/1234567890" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/draws"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DrawRunParams
        {
            TweetUrl = "https://x.com/elonmusk/status/1234567890",
            BackupCount = 2,
            FilterAccountAgeDays = 30,
            FilterLanguage = "en",
            FilterMinFollowers = 50,
            MustFollowUsername = "elonmusk",
            MustRetweet = true,
            RequiredHashtags = ["#giveaway"],
            RequiredKeywords = ["entered"],
            RequiredMentions = ["@elonmusk"],
            UniqueAuthorsOnly = true,
            WinnerCount = 3,
        };

        DrawRunParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
