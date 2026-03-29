using System;
using System.Collections.Generic;
using XTwitterScraper.Models.X.Dm;

namespace XTwitterScraper.Tests.Models.X.Dm;

public class DmUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DmUpdateParams
        {
            UserID = "userId",
            Account = "account",
            Text = "text",
            MediaIds = ["string"],
            ReplyToMessageID = "reply_to_message_id",
        };

        string expectedUserID = "userId";
        string expectedAccount = "account";
        string expectedText = "text";
        List<string> expectedMediaIds = ["string"];
        string expectedReplyToMessageID = "reply_to_message_id";

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
        var parameters = new DmUpdateParams
        {
            UserID = "userId",
            Account = "account",
            Text = "text",
        };

        Assert.Null(parameters.MediaIds);
        Assert.False(parameters.RawBodyData.ContainsKey("media_ids"));
        Assert.Null(parameters.ReplyToMessageID);
        Assert.False(parameters.RawBodyData.ContainsKey("reply_to_message_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DmUpdateParams
        {
            UserID = "userId",
            Account = "account",
            Text = "text",

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
        DmUpdateParams parameters = new()
        {
            UserID = "userId",
            Account = "account",
            Text = "text",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/dm/userId"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DmUpdateParams
        {
            UserID = "userId",
            Account = "account",
            Text = "text",
            MediaIds = ["string"],
            ReplyToMessageID = "reply_to_message_id",
        };

        DmUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
