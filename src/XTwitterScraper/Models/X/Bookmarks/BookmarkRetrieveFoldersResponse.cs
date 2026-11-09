// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

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

    /// <summary>
    /// Always false for the current bookmark folder route
    /// </summary>
    public required bool HasNextPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_next_page");
        }
        init { this._rawData.Set("has_next_page", value); }
    }

    /// <summary>
    /// Always empty for the current bookmark folder route
    /// </summary>
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

    /// <summary>
    /// Public folder cover image metadata.
    /// </summary>
    public FolderMedia? Media
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FolderMedia>("media");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("media", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        this.Media?.Validate();
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

[JsonConverter(typeof(JsonModelConverter<FolderMediaPaletteRgb, FolderMediaPaletteRgbFromRaw>))]
public sealed record class FolderMediaPaletteRgb : JsonModel
{
    public double? Blue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("blue");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("blue", value);
        }
    }

    public double? Green
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("green");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("green", value);
        }
    }

    public double? Red
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("red");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("red", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Blue;
        _ = this.Green;
        _ = this.Red;
    }

    public FolderMediaPaletteRgb() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderMediaPaletteRgb(FolderMediaPaletteRgb folderMediaPaletteRgb)
        : base(folderMediaPaletteRgb) { }
#pragma warning restore CS8618

    public FolderMediaPaletteRgb(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderMediaPaletteRgb(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderMediaPaletteRgbFromRaw.FromRawUnchecked"/>
    public static FolderMediaPaletteRgb FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FolderMediaPaletteRgbFromRaw : IFromRawJson<FolderMediaPaletteRgb>
{
    /// <inheritdoc/>
    public FolderMediaPaletteRgb FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FolderMediaPaletteRgb.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FolderMediaPalette, FolderMediaPaletteFromRaw>))]
public sealed record class FolderMediaPalette : JsonModel
{
    public double? Percentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("percentage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("percentage", value);
        }
    }

    public FolderMediaPaletteRgb? Rgb
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FolderMediaPaletteRgb>("rgb");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rgb", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Percentage;
        this.Rgb?.Validate();
    }

    public FolderMediaPalette() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderMediaPalette(FolderMediaPalette folderMediaPalette)
        : base(folderMediaPalette) { }
#pragma warning restore CS8618

    public FolderMediaPalette(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderMediaPalette(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderMediaPaletteFromRaw.FromRawUnchecked"/>
    public static FolderMediaPalette FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FolderMediaPaletteFromRaw : IFromRawJson<FolderMediaPalette>
{
    /// <inheritdoc/>
    public FolderMediaPalette FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FolderMediaPalette.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FolderMedia, FolderMediaFromRaw>))]
public sealed record class FolderMedia : JsonModel
{
    /// <summary>
    /// Media object ID.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Media ID.
    /// </summary>
    public string? MediaID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mediaId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mediaId", value);
        }
    }

    /// <summary>
    /// Stable media key.
    /// </summary>
    public string? MediaKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mediaKey");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mediaKey", value);
        }
    }

    /// <summary>
    /// Original image height.
    /// </summary>
    public long? OriginalImageHeight
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("originalImageHeight");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("originalImageHeight", value);
        }
    }

    /// <summary>
    /// Original image URL.
    /// </summary>
    public string? OriginalImageUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("originalImageUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("originalImageUrl", value);
        }
    }

    /// <summary>
    /// Original image width.
    /// </summary>
    public long? OriginalImageWidth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("originalImageWidth");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("originalImageWidth", value);
        }
    }

    /// <summary>
    /// Dominant image colors and their proportions.
    /// </summary>
    public IReadOnlyList<FolderMediaPalette>? Palette
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FolderMediaPalette>>("palette");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<FolderMediaPalette>?>(
                "palette",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Media object type.
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.MediaID;
        _ = this.MediaKey;
        _ = this.OriginalImageHeight;
        _ = this.OriginalImageUrl;
        _ = this.OriginalImageWidth;
        foreach (var item in this.Palette ?? [])
        {
            item.Validate();
        }
        _ = this.Type;
    }

    public FolderMedia() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderMedia(FolderMedia folderMedia)
        : base(folderMedia) { }
#pragma warning restore CS8618

    public FolderMedia(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderMedia(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderMediaFromRaw.FromRawUnchecked"/>
    public static FolderMedia FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FolderMediaFromRaw : IFromRawJson<FolderMedia>
{
    /// <inheritdoc/>
    public FolderMedia FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FolderMedia.FromRawUnchecked(rawData);
}
