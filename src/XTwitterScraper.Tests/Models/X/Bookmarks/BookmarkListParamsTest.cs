using System;
using XTwitterScraper.Models.X.Bookmarks;

namespace XTwitterScraper.Tests.Models.X.Bookmarks;

public class BookmarkListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BookmarkListParams { Cursor = "folders_value", FolderID = "folderId" };

        string expectedCursor = "folders_value";
        string expectedFolderID = "folderId";

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedFolderID, parameters.FolderID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BookmarkListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.FolderID);
        Assert.False(parameters.RawQueryData.ContainsKey("folderId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BookmarkListParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            FolderID = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.FolderID);
        Assert.False(parameters.RawQueryData.ContainsKey("folderId"));
    }

    [Fact]
    public void Url_Works()
    {
        BookmarkListParams parameters = new() { Cursor = "folders_value", FolderID = "folderId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://xquik.com/api/v1/x/bookmarks?cursor=folders_value&folderId=folderId"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BookmarkListParams { Cursor = "folders_value", FolderID = "folderId" };

        BookmarkListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
