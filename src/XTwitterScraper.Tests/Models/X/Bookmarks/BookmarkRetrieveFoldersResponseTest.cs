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
            Folders = [new() { ID = "1234567890", Name = "Read Later" }],
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
        };

        List<Folder> expectedFolders = [new() { ID = "1234567890", Name = "Read Later" }];
        bool expectedHasNextPage = true;
        string expectedNextCursor = "DAACCgACGRElMJcAAA";

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
            Folders = [new() { ID = "1234567890", Name = "Read Later" }],
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
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
            Folders = [new() { ID = "1234567890", Name = "Read Later" }],
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BookmarkRetrieveFoldersResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Folder> expectedFolders = [new() { ID = "1234567890", Name = "Read Later" }];
        bool expectedHasNextPage = true;
        string expectedNextCursor = "DAACCgACGRElMJcAAA";

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
            Folders = [new() { ID = "1234567890", Name = "Read Later" }],
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BookmarkRetrieveFoldersResponse
        {
            Folders = [new() { ID = "1234567890", Name = "Read Later" }],
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
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
        var model = new Folder { ID = "1234567890", Name = "Read Later" };

        string expectedID = "1234567890";
        string expectedName = "Read Later";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Folder { ID = "1234567890", Name = "Read Later" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Folder>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Folder { ID = "1234567890", Name = "Read Later" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Folder>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "1234567890";
        string expectedName = "Read Later";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Folder { ID = "1234567890", Name = "Read Later" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Folder { ID = "1234567890", Name = "Read Later" };

        Folder copied = new(model);

        Assert.Equal(model, copied);
    }
}
