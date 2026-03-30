using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Radar;

[JsonConverter(typeof(JsonModelConverter<RadarItem, RadarItemFromRaw>))]
public sealed record class RadarItem : JsonModel
{
    public required string Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    public required DateTimeOffset PublishedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("publishedAt");
        }
        init { this._rawData.Set("publishedAt", value); }
    }

    public required string Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("region");
        }
        init { this._rawData.Set("region", value); }
    }

    public required double Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("score");
        }
        init { this._rawData.Set("score", value); }
    }

    public required string Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    public required string Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
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

    public string? ImageUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("imageUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("imageUrl", value);
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
        _ = this.Category;
        _ = this.PublishedAt;
        _ = this.Region;
        _ = this.Score;
        _ = this.Source;
        _ = this.Title;
        _ = this.Description;
        _ = this.ImageUrl;
        _ = this.Url;
    }

    public RadarItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RadarItem(RadarItem radarItem)
        : base(radarItem) { }
#pragma warning restore CS8618

    public RadarItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RadarItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RadarItemFromRaw.FromRawUnchecked"/>
    public static RadarItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RadarItemFromRaw : IFromRawJson<RadarItem>
{
    /// <inheritdoc/>
    public RadarItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RadarItem.FromRawUnchecked(rawData);
}
