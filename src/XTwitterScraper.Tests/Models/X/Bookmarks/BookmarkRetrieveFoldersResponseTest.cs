using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Bookmarks;

namespace XTwitterScraper.Tests.Models.X.Bookmarks;

public class BookmarkRetrieveFoldersResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BookmarkRetrieveFoldersResponse
        {
            Folders = [new() { ID = "id", Name = "name" }],
            HasNextPage = true,
            NextCursor = "next_cursor",
        };

        List<Folder> expectedFolders = [new() { ID = "id", Name = "name" }];
        bool expectedHasNextPage = true;
        string expectedNextCursor = "next_cursor";

        Assert.Equal(expectedFolders.Count, model.Folders.Count);
        for (int i = 0; i < expectedFolders.Count; i++)
        {
            Assert.Equal(expectedFolders[i], model.Folders[i]);
        }
        Assert.Equal(expectedHasNextPage, model.HasNextPage);
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BookmarkRetrieveFoldersResponse
        {
            Folders = [new() { ID = "id", Name = "name" }],
            HasNextPage = true,
            NextCursor = "next_cursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BookmarkRetrieveFoldersResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BookmarkRetrieveFoldersResponse
        {
            Folders = [new() { ID = "id", Name = "name" }],
            HasNextPage = true,
            NextCursor = "next_cursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BookmarkRetrieveFoldersResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Folder> expectedFolders = [new() { ID = "id", Name = "name" }];
        bool expectedHasNextPage = true;
        string expectedNextCursor = "next_cursor";

        Assert.Equal(expectedFolders.Count, deserialized.Folders.Count);
        for (int i = 0; i < expectedFolders.Count; i++)
        {
            Assert.Equal(expectedFolders[i], deserialized.Folders[i]);
        }
        Assert.Equal(expectedHasNextPage, deserialized.HasNextPage);
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BookmarkRetrieveFoldersResponse
        {
            Folders = [new() { ID = "id", Name = "name" }],
            HasNextPage = true,
            NextCursor = "next_cursor",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BookmarkRetrieveFoldersResponse
        {
            Folders = [new() { ID = "id", Name = "name" }],
            HasNextPage = true,
            NextCursor = "next_cursor",
        };

        BookmarkRetrieveFoldersResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FolderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Folder { ID = "id", Name = "name" };

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Folder { ID = "id", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Folder>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Folder { ID = "id", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Folder>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Folder { ID = "id", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Folder { ID = "id", Name = "name" };

        Folder copied = new(model);

        Assert.Equal(model, copied);
    }
}
