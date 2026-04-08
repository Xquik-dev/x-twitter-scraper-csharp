using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X;

[JsonConverter(typeof(JsonModelConverter<XGetTrendsResponse, XGetTrendsResponseFromRaw>))]
public sealed record class XGetTrendsResponse : JsonModel
{
    public required long Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    public required IReadOnlyList<Trend> Trends
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Trend>>("trends");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Trend>>(
                "trends",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required long Woeid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("woeid");
        }
        init { this._rawData.Set("woeid", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        foreach (var item in this.Trends)
        {
            item.Validate();
        }
        _ = this.Woeid;
    }

    public XGetTrendsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XGetTrendsResponse(XGetTrendsResponse xGetTrendsResponse)
        : base(xGetTrendsResponse) { }
#pragma warning restore CS8618

    public XGetTrendsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XGetTrendsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XGetTrendsResponseFromRaw.FromRawUnchecked"/>
    public static XGetTrendsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XGetTrendsResponseFromRaw : IFromRawJson<XGetTrendsResponse>
{
    /// <inheritdoc/>
    public XGetTrendsResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        XGetTrendsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Trend, TrendFromRaw>))]
public sealed record class Trend : JsonModel
{
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
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

    public string? Query
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("query");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("query", value);
        }
    }

    public long? Rank
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("rank");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rank", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Description;
        _ = this.Query;
        _ = this.Rank;
    }

    public Trend() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Trend(Trend trend)
        : base(trend) { }
#pragma warning restore CS8618

    public Trend(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Trend(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrendFromRaw.FromRawUnchecked"/>
    public static Trend FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Trend(string name)
        : this()
    {
        this.Name = name;
    }
}

class TrendFromRaw : IFromRawJson<Trend>
{
    /// <inheritdoc/>
    public Trend FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Trend.FromRawUnchecked(rawData);
}
