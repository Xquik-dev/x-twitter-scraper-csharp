using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Bookmarks;

[JsonConverter(
    typeof(JsonModelConverter<
        BookmarkRetrieveFoldersResponse,
        BookmarkRetrieveFoldersResponseFromRaw
    >)
)]
public sealed record class BookmarkRetrieveFoldersResponse : JsonModel
{
    public required IReadOnlyList<Folder> Folders
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Folder>>("folders");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Folder>>(
                "folders",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required bool HasNextPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_next_page");
        }
        init { this._rawData.Set("has_next_page", value); }
    }

    public required string NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("next_cursor");
        }
        init { this._rawData.Set("next_cursor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Folders)
        {
            item.Validate();
        }
        _ = this.HasNextPage;
        _ = this.NextCursor;
    }

    public BookmarkRetrieveFoldersResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BookmarkRetrieveFoldersResponse(
        BookmarkRetrieveFoldersResponse bookmarkRetrieveFoldersResponse
    )
        : base(bookmarkRetrieveFoldersResponse) { }
#pragma warning restore CS8618

    public BookmarkRetrieveFoldersResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BookmarkRetrieveFoldersResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BookmarkRetrieveFoldersResponseFromRaw.FromRawUnchecked"/>
    public static BookmarkRetrieveFoldersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BookmarkRetrieveFoldersResponseFromRaw : IFromRawJson<BookmarkRetrieveFoldersResponse>
{
    /// <inheritdoc/>
    public BookmarkRetrieveFoldersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BookmarkRetrieveFoldersResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Folder, FolderFromRaw>))]
public sealed record class Folder : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public Folder() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Folder(Folder folder)
        : base(folder) { }
#pragma warning restore CS8618

    public Folder(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Folder(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderFromRaw.FromRawUnchecked"/>
    public static Folder FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FolderFromRaw : IFromRawJson<Folder>
{
    /// <inheritdoc/>
    public Folder FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Folder.FromRawUnchecked(rawData);
}
