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
            AttachmentUrl = "https://x.com/elonmusk/status/1234567890",
            CommunityID = "1500000000000000000",
            IsNoteTweet = false,
            Media = ["https://example.com/image.jpg"],
            MediaIds = ["1234567890123456789"],
            ReplyToTweetID = "1234567890",
            Text = "Just launched our new feature!",
        };

        string expectedAccount = "@elonmusk";
        string expectedAttachmentUrl = "https://x.com/elonmusk/status/1234567890";
        string expectedCommunityID = "1500000000000000000";
        bool expectedIsNoteTweet = false;
        List<string> expectedMedia = ["https://example.com/image.jpg"];
        List<string> expectedMediaIds = ["1234567890123456789"];
        string expectedReplyToTweetID = "1234567890";
        string expectedText = "Just launched our new feature!";

        Assert.Equal(expectedAccount, parameters.Account);
        Assert.Equal(expectedAttachmentUrl, parameters.AttachmentUrl);
        Assert.Equal(expectedCommunityID, parameters.CommunityID);
        Assert.Equal(expectedIsNoteTweet, parameters.IsNoteTweet);
        Assert.NotNull(parameters.Media);
        Assert.Equal(expectedMedia.Count, parameters.Media.Count);
        for (int i = 0; i < expectedMedia.Count; i++)
        {
            Assert.Equal(expectedMedia[i], parameters.Media[i]);
        }
        Assert.NotNull(parameters.MediaIds);
        Assert.Equal(expectedMediaIds.Count, parameters.MediaIds.Count);
        for (int i = 0; i < expectedMediaIds.Count; i++)
        {
            Assert.Equal(expectedMediaIds[i], parameters.MediaIds[i]);
        }
        Assert.Equal(expectedReplyToTweetID, parameters.ReplyToTweetID);
        Assert.Equal(expectedText, parameters.Text);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TweetCreateParams { Account = "@elonmusk" };

        Assert.Null(parameters.AttachmentUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("attachment_url"));
        Assert.Null(parameters.CommunityID);
        Assert.False(parameters.RawBodyData.ContainsKey("community_id"));
        Assert.Null(parameters.IsNoteTweet);
        Assert.False(parameters.RawBodyData.ContainsKey("is_note_tweet"));
        Assert.Null(parameters.Media);
        Assert.False(parameters.RawBodyData.ContainsKey("media"));
        Assert.Null(parameters.MediaIds);
        Assert.False(parameters.RawBodyData.ContainsKey("media_ids"));
        Assert.Null(parameters.ReplyToTweetID);
        Assert.False(parameters.RawBodyData.ContainsKey("reply_to_tweet_id"));
        Assert.Null(parameters.Text);
        Assert.False(parameters.RawBodyData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TweetCreateParams
        {
            Account = "@elonmusk",

            // Null should be interpreted as omitted for these properties
            AttachmentUrl = null,
            CommunityID = null,
            IsNoteTweet = null,
            Media = null,
            MediaIds = null,
            ReplyToTweetID = null,
            Text = null,
        };

        Assert.Null(parameters.AttachmentUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("attachment_url"));
        Assert.Null(parameters.CommunityID);
        Assert.False(parameters.RawBodyData.ContainsKey("community_id"));
        Assert.Null(parameters.IsNoteTweet);
        Assert.False(parameters.RawBodyData.ContainsKey("is_note_tweet"));
        Assert.Null(parameters.Media);
        Assert.False(parameters.RawBodyData.ContainsKey("media"));
        Assert.Null(parameters.MediaIds);
        Assert.False(parameters.RawBodyData.ContainsKey("media_ids"));
        Assert.Null(parameters.ReplyToTweetID);
        Assert.False(parameters.RawBodyData.ContainsKey("reply_to_tweet_id"));
        Assert.Null(parameters.Text);
        Assert.False(parameters.RawBodyData.ContainsKey("text"));
    }

    [Fact]
    public void Url_Works()
    {
        TweetCreateParams parameters = new() { Account = "@elonmusk" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/x/tweets"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TweetCreateParams
        {
            Account = "@elonmusk",
            AttachmentUrl = "https://x.com/elonmusk/status/1234567890",
            CommunityID = "1500000000000000000",
            IsNoteTweet = false,
            Media = ["https://example.com/image.jpg"],
            MediaIds = ["1234567890123456789"],
            ReplyToTweetID = "1234567890",
            Text = "Just launched our new feature!",
        };

        TweetCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
