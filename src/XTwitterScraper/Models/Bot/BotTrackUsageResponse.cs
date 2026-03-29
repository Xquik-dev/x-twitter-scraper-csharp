using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Bot;

[JsonConverter(typeof(JsonModelConverter<BotTrackUsageResponse, BotTrackUsageResponseFromRaw>))]
public sealed record class BotTrackUsageResponse : JsonModel
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

    public BotTrackUsageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BotTrackUsageResponse(BotTrackUsageResponse botTrackUsageResponse)
        : base(botTrackUsageResponse) { }
#pragma warning restore CS8618

    public BotTrackUsageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BotTrackUsageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BotTrackUsageResponseFromRaw.FromRawUnchecked"/>
    public static BotTrackUsageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BotTrackUsageResponseFromRaw : IFromRawJson<BotTrackUsageResponse>
{
    /// <inheritdoc/>
    public BotTrackUsageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BotTrackUsageResponse.FromRawUnchecked(rawData);
}
