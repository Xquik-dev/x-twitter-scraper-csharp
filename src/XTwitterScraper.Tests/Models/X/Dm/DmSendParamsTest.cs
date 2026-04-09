using System;
using System.Collections.Generic;
using XTwitterScraper.Models.X.Dm;

namespace XTwitterScraper.Tests.Models.X.Dm;

public class DmSendParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DmSendParams
        {
            UserID = "userId",
            Account = "@elonmusk",
            Text = "Example text content",
            MediaIds = ["1234567890123456789"],
            ReplyToMessageID = "1234567890123456789",
        };

        string expectedUserID = "userId";
        string expectedAccount = "@elonmusk";
        string expectedText = "Example text content";
        List<string> expectedMediaIds = ["1234567890123456789"];
        string expectedReplyToMessageID = "1234567890123456789";

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedAccount, parameters.Account);
        Assert.Equal(expectedText, parameters.Text);
        Assert.NotNull(parameters.MediaIds);
        Assert.Equal(expectedMediaIds.Count, parameters.MediaIds.Count);
        for (int i = 0; i < expectedMediaIds.Count; i++)
        {
            Assert.Equal(expectedMediaIds[i], parameters.MediaIds[i]);
        }
        Assert.Equal(expectedReplyToMessageID, parameters.ReplyToMessageID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DmSendParams
        {
            UserID = "userId",
            Account = "@elonmusk",
            Text = "Example text content",
        };

        Assert.Null(parameters.MediaIds);
        Assert.False(parameters.RawBodyData.ContainsKey("media_ids"));
        Assert.Null(parameters.ReplyToMessageID);
        Assert.False(parameters.RawBodyData.ContainsKey("reply_to_message_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DmSendParams
        {
            UserID = "userId",
            Account = "@elonmusk",
            Text = "Example text content",

            // Null should be interpreted as omitted for these properties
            MediaIds = null,
            ReplyToMessageID = null,
        };

        Assert.Null(parameters.MediaIds);
        Assert.False(parameters.RawBodyData.ContainsKey("media_ids"));
        Assert.Null(parameters.ReplyToMessageID);
        Assert.False(parameters.RawBodyData.ContainsKey("reply_to_message_id"));
    }

    [Fact]
    public void Url_Works()
    {
        DmSendParams parameters = new()
        {
            UserID = "userId",
            Account = "@elonmusk",
            Text = "Example text content",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/dm/userId"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DmSendParams
        {
            UserID = "userId",
            Account = "@elonmusk",
            Text = "Example text content",
            MediaIds = ["1234567890123456789"],
            ReplyToMessageID = "1234567890123456789",
        };

        DmSendParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
