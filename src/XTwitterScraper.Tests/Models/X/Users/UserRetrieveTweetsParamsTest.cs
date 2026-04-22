using System;
using XTwitterScraper.Models.X.Users;

namespace XTwitterScraper.Tests.Models.X.Users;

public class UserRetrieveTweetsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserRetrieveTweetsParams
        {
            ID = "id",
            Cursor = "cursor",
            IncludeParentTweet = true,
            IncludeReplies = true,
        };

        string expectedID = "id";
        string expectedCursor = "cursor";
        bool expectedIncludeParentTweet = true;
        bool expectedIncludeReplies = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedIncludeParentTweet, parameters.IncludeParentTweet);
        Assert.Equal(expectedIncludeReplies, parameters.IncludeReplies);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserRetrieveTweetsParams { ID = "id" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.IncludeParentTweet);
        Assert.False(parameters.RawQueryData.ContainsKey("includeParentTweet"));
        Assert.Null(parameters.IncludeReplies);
        Assert.False(parameters.RawQueryData.ContainsKey("includeReplies"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserRetrieveTweetsParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            IncludeParentTweet = null,
            IncludeReplies = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.IncludeParentTweet);
        Assert.False(parameters.RawQueryData.ContainsKey("includeParentTweet"));
        Assert.Null(parameters.IncludeReplies);
        Assert.False(parameters.RawQueryData.ContainsKey("includeReplies"));
    }

    [Fact]
    public void Url_Works()
    {
        UserRetrieveTweetsParams parameters = new()
        {
            ID = "id",
            Cursor = "cursor",
            IncludeParentTweet = true,
            IncludeReplies = true,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://xquik.com/api/v1/x/users/id/tweets?cursor=cursor&includeParentTweet=true&includeReplies=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserRetrieveTweetsParams
        {
            ID = "id",
            Cursor = "cursor",
            IncludeParentTweet = true,
            IncludeReplies = true,
        };

        UserRetrieveTweetsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
