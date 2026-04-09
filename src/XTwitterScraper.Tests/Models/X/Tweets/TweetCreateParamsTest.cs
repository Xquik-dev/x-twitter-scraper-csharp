using System;
using System.Collections.Generic;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Tests.Models.X.Tweets;

public class TweetCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TweetCreateParams
        {
            Account = "@elonmusk",
            Text = "Just launched our new feature!",
            AttachmentUrl = "https://x.com/elonmusk/status/1234567890",
            CommunityID = "1500000000000000000",
            IsNoteTweet = false,
            MediaIds = ["1234567890123456789"],
            ReplyToTweetID = "1234567890",
        };

        string expectedAccount = "@elonmusk";
        string expectedText = "Just launched our new feature!";
        string expectedAttachmentUrl = "https://x.com/elonmusk/status/1234567890";
        string expectedCommunityID = "1500000000000000000";
        bool expectedIsNoteTweet = false;
        List<string> expectedMediaIds = ["1234567890123456789"];
        string expectedReplyToTweetID = "1234567890";

        Assert.Equal(expectedAccount, parameters.Account);
        Assert.Equal(expectedText, parameters.Text);
        Assert.Equal(expectedAttachmentUrl, parameters.AttachmentUrl);
        Assert.Equal(expectedCommunityID, parameters.CommunityID);
        Assert.Equal(expectedIsNoteTweet, parameters.IsNoteTweet);
        Assert.NotNull(parameters.MediaIds);
        Assert.Equal(expectedMediaIds.Count, parameters.MediaIds.Count);
        for (int i = 0; i < expectedMediaIds.Count; i++)
        {
            Assert.Equal(expectedMediaIds[i], parameters.MediaIds[i]);
        }
        Assert.Equal(expectedReplyToTweetID, parameters.ReplyToTweetID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TweetCreateParams
        {
            Account = "@elonmusk",
            Text = "Just launched our new feature!",
        };

        Assert.Null(parameters.AttachmentUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("attachment_url"));
        Assert.Null(parameters.CommunityID);
        Assert.False(parameters.RawBodyData.ContainsKey("community_id"));
        Assert.Null(parameters.IsNoteTweet);
        Assert.False(parameters.RawBodyData.ContainsKey("is_note_tweet"));
        Assert.Null(parameters.MediaIds);
        Assert.False(parameters.RawBodyData.ContainsKey("media_ids"));
        Assert.Null(parameters.ReplyToTweetID);
        Assert.False(parameters.RawBodyData.ContainsKey("reply_to_tweet_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TweetCreateParams
        {
            Account = "@elonmusk",
            Text = "Just launched our new feature!",

            // Null should be interpreted as omitted for these properties
            AttachmentUrl = null,
            CommunityID = null,
            IsNoteTweet = null,
            MediaIds = null,
            ReplyToTweetID = null,
        };

        Assert.Null(parameters.AttachmentUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("attachment_url"));
        Assert.Null(parameters.CommunityID);
        Assert.False(parameters.RawBodyData.ContainsKey("community_id"));
        Assert.Null(parameters.IsNoteTweet);
        Assert.False(parameters.RawBodyData.ContainsKey("is_note_tweet"));
        Assert.Null(parameters.MediaIds);
        Assert.False(parameters.RawBodyData.ContainsKey("media_ids"));
        Assert.Null(parameters.ReplyToTweetID);
        Assert.False(parameters.RawBodyData.ContainsKey("reply_to_tweet_id"));
    }

    [Fact]
    public void Url_Works()
    {
        TweetCreateParams parameters = new()
        {
            Account = "@elonmusk",
            Text = "Just launched our new feature!",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/tweets"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TweetCreateParams
        {
            Account = "@elonmusk",
            Text = "Just launched our new feature!",
            AttachmentUrl = "https://x.com/elonmusk/status/1234567890",
            CommunityID = "1500000000000000000",
            IsNoteTweet = false,
            MediaIds = ["1234567890123456789"],
            ReplyToTweetID = "1234567890",
        };

        TweetCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
