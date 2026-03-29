using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Bot.PlatformLinks;

[JsonConverter(
    typeof(JsonModelConverter<PlatformLinkLookupResponse, PlatformLinkLookupResponseFromRaw>)
)]
public sealed record class PlatformLinkLookupResponse : JsonModel
{
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("userId");
        }
        init { this._rawData.Set("userId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UserID;
    }

    public PlatformLinkLookupResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlatformLinkLookupResponse(PlatformLinkLookupResponse platformLinkLookupResponse)
        : base(platformLinkLookupResponse) { }
#pragma warning restore CS8618

    public PlatformLinkLookupResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlatformLinkLookupResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlatformLinkLookupResponseFromRaw.FromRawUnchecked"/>
    public static PlatformLinkLookupResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PlatformLinkLookupResponse(string userID)
        : this()
    {
        this.UserID = userID;
    }
}

class PlatformLinkLookupResponseFromRaw : IFromRawJson<PlatformLinkLookupResponse>
{
    /// <inheritdoc/>
    public PlatformLinkLookupResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlatformLinkLookupResponse.FromRawUnchecked(rawData);
}
