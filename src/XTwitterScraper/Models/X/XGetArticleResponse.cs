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

namespace XTwitterScraper.Models.X;

[JsonConverter(typeof(JsonModelConverter<XGetArticleResponse, XGetArticleResponseFromRaw>))]
public sealed record class XGetArticleResponse : JsonModel
{
    public required Article Article
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Article>("article");
        }
        init { this._rawData.Set("article", value); }
    }

    /// <summary>
    /// X Article author profile fields returned when available.
    /// </summary>
    public Author? Author
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Author>("author");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("author", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Article.Validate();
        this.Author?.Validate();
    }

    public XGetArticleResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XGetArticleResponse(XGetArticleResponse xGetArticleResponse)
        : base(xGetArticleResponse) { }
#pragma warning restore CS8618

    public XGetArticleResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XGetArticleResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XGetArticleResponseFromRaw.FromRawUnchecked"/>
    public static XGetArticleResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public XGetArticleResponse(Article article)
        : this()
    {
        this.Article = article;
    }
}

class XGetArticleResponseFromRaw : IFromRawJson<XGetArticleResponse>
{
    /// <inheritdoc/>
    public XGetArticleResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        XGetArticleResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Article, ArticleFromRaw>))]
public sealed record class Article : JsonModel
{
    /// <summary>
    /// Plain text joined from all article blocks
    /// </summary>
    public string? BodyText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bodyText");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bodyText", value);
        }
    }

    public IReadOnlyList<Content>? Contents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Content>>("contents");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Content>?>(
                "contents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? CoverImageUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("coverImageUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("coverImageUrl", value);
        }
    }

    public string? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public long? LikeCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("likeCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("likeCount", value);
        }
    }

    public string? PreviewText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("previewText");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("previewText", value);
        }
    }

    public long? QuoteCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("quoteCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("quoteCount", value);
        }
    }

    public long? ReplyCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("replyCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("replyCount", value);
        }
    }

    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("title", value);
        }
    }

    public long? ViewCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("viewCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("viewCount", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BodyText;
        foreach (var item in this.Contents ?? [])
        {
            item.Validate();
        }
        _ = this.CoverImageUrl;
        _ = this.CreatedAt;
        _ = this.LikeCount;
        _ = this.PreviewText;
        _ = this.QuoteCount;
        _ = this.ReplyCount;
        _ = this.Title;
        _ = this.ViewCount;
    }

    public Article() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Article(Article article)
        : base(article) { }
#pragma warning restore CS8618

    public Article(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Article(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ArticleFromRaw.FromRawUnchecked"/>
    public static Article FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ArticleFromRaw : IFromRawJson<Article>
{
    /// <inheritdoc/>
    public Article FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Article.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Content, ContentFromRaw>))]
public sealed record class Content : JsonModel
{
    public long? Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("height");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("height", value);
        }
    }

    /// <summary>
    /// Inline text formatting ranges
    /// </summary>
    public IReadOnlyList<InlineStyleRange>? InlineStyleRanges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<InlineStyleRange>>(
                "inlineStyleRanges"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<InlineStyleRange>?>(
                "inlineStyleRanges",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Preview image URL for media blocks
    /// </summary>
    public string? PreviewUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("previewUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("previewUrl", value);
        }
    }

    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <summary>
    /// Block type: paragraph, header-one, header-two, header-three, header-four,
    /// header-five, header-six, unordered-list-item, ordered-list-item, blockquote,
    /// code-block, media, divider
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

    /// <summary>
    /// Media URL for media blocks
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    public long? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("width");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("width", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Height;
        foreach (var item in this.InlineStyleRanges ?? [])
        {
            item.Validate();
        }
        _ = this.PreviewUrl;
        _ = this.Text;
        _ = this.Type;
        _ = this.Url;
        _ = this.Width;
    }

    public Content() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Content(Content content)
        : base(content) { }
#pragma warning restore CS8618

    public Content(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Content(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContentFromRaw.FromRawUnchecked"/>
    public static Content FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContentFromRaw : IFromRawJson<Content>
{
    /// <inheritdoc/>
    public Content FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Content.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<InlineStyleRange, InlineStyleRangeFromRaw>))]
public sealed record class InlineStyleRange : JsonModel
{
    public long? Length
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("length");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("length", value);
        }
    }

    public long? Offset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("offset");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("offset", value);
        }
    }

    public string? Style
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("style");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("style", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Length;
        _ = this.Offset;
        _ = this.Style;
    }

    public InlineStyleRange() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InlineStyleRange(InlineStyleRange inlineStyleRange)
        : base(inlineStyleRange) { }
#pragma warning restore CS8618

    public InlineStyleRange(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InlineStyleRange(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InlineStyleRangeFromRaw.FromRawUnchecked"/>
    public static InlineStyleRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InlineStyleRangeFromRaw : IFromRawJson<InlineStyleRange>
{
    /// <inheritdoc/>
    public InlineStyleRange FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InlineStyleRange.FromRawUnchecked(rawData);
}

/// <summary>
/// X Article author profile fields returned when available.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Author, AuthorFromRaw>))]
public sealed record class Author : JsonModel
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

    public required string Username
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("username");
        }
        init { this._rawData.Set("username", value); }
    }

    public bool? CanDm
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("canDm");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("canDm", value);
        }
    }

    public string? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public long? FavouritesCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("favouritesCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("favouritesCount", value);
        }
    }

    public long? FollowersCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("followersCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("followersCount", value);
        }
    }

    public long? FollowingCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("followingCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("followingCount", value);
        }
    }

    public bool? IsBlueVerified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isBlueVerified");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isBlueVerified", value);
        }
    }

    public bool? IsTranslator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isTranslator");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isTranslator", value);
        }
    }

    public bool? IsVerified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isVerified");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isVerified", value);
        }
    }

    public string? Location
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("location");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("location", value);
        }
    }

    public long? MediaCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("mediaCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mediaCount", value);
        }
    }

    public string? ProfileBannerUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profileBannerUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profileBannerUrl", value);
        }
    }

    public string? ProfilePicture
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profilePicture");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profilePicture", value);
        }
    }

    public bool? Protected
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("protected");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("protected", value);
        }
    }

    public long? StatusesCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("statusesCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("statusesCount", value);
        }
    }

    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.Username;
        _ = this.CanDm;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.FavouritesCount;
        _ = this.FollowersCount;
        _ = this.FollowingCount;
        _ = this.IsBlueVerified;
        _ = this.IsTranslator;
        _ = this.IsVerified;
        _ = this.Location;
        _ = this.MediaCount;
        _ = this.ProfileBannerUrl;
        _ = this.ProfilePicture;
        _ = this.Protected;
        _ = this.StatusesCount;
        _ = this.Url;
    }

    public Author() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Author(Author author)
        : base(author) { }
#pragma warning restore CS8618

    public Author(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Author(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AuthorFromRaw.FromRawUnchecked"/>
    public static Author FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AuthorFromRaw : IFromRawJson<Author>
{
    /// <inheritdoc/>
    public Author FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Author.FromRawUnchecked(rawData);
}
