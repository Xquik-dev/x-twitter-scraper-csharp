using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Support.Tickets;

[JsonConverter(typeof(JsonModelConverter<TicketUpdateResponse, TicketUpdateResponseFromRaw>))]
public sealed record class TicketUpdateResponse : JsonModel
{
    public string? PublicID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("publicId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("publicId", value);
        }
    }

    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PublicID;
        _ = this.Status;
    }

    public TicketUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TicketUpdateResponse(TicketUpdateResponse ticketUpdateResponse)
        : base(ticketUpdateResponse) { }
#pragma warning restore CS8618

    public TicketUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TicketUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TicketUpdateResponseFromRaw.FromRawUnchecked"/>
    public static TicketUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TicketUpdateResponseFromRaw : IFromRawJson<TicketUpdateResponse>
{
    /// <inheritdoc/>
    public TicketUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TicketUpdateResponse.FromRawUnchecked(rawData);
}
