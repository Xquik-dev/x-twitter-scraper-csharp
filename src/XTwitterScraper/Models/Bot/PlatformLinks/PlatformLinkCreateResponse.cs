using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Bot.PlatformLinks;

[JsonConverter(
    typeof(JsonModelConverter<PlatformLinkCreateResponse, PlatformLinkCreateResponseFromRaw>)
)]
public sealed record class PlatformLinkCreateResponse : JsonModel
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

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required string Platform
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("platform");
        }
        init { this._rawData.Set("platform", value); }
    }

    public required string PlatformUserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("platformUserId");
        }
        init { this._rawData.Set("platformUserId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Platform;
        _ = this.PlatformUserID;
    }

    public PlatformLinkCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlatformLinkCreateResponse(PlatformLinkCreateResponse platformLinkCreateResponse)
        : base(platformLinkCreateResponse) { }
#pragma warning restore CS8618

    public PlatformLinkCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlatformLinkCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlatformLinkCreateResponseFromRaw.FromRawUnchecked"/>
    public static PlatformLinkCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlatformLinkCreateResponseFromRaw : IFromRawJson<PlatformLinkCreateResponse>
{
    /// <inheritdoc/>
    public PlatformLinkCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlatformLinkCreateResponse.FromRawUnchecked(rawData);
}
