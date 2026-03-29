using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Bot.PlatformLinks;

[JsonConverter(
    typeof(JsonModelConverter<PlatformLinkDeleteResponse, PlatformLinkDeleteResponseFromRaw>)
)]
public sealed record class PlatformLinkDeleteResponse : JsonModel
{
    public bool? Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("success");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Success;
    }

    public PlatformLinkDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlatformLinkDeleteResponse(PlatformLinkDeleteResponse platformLinkDeleteResponse)
        : base(platformLinkDeleteResponse) { }
#pragma warning restore CS8618

    public PlatformLinkDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlatformLinkDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlatformLinkDeleteResponseFromRaw.FromRawUnchecked"/>
    public static PlatformLinkDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlatformLinkDeleteResponseFromRaw : IFromRawJson<PlatformLinkDeleteResponse>
{
    /// <inheritdoc/>
    public PlatformLinkDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlatformLinkDeleteResponse.FromRawUnchecked(rawData);
}
