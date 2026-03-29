using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Support.Tickets;

[JsonConverter(typeof(JsonModelConverter<TicketCreateResponse, TicketCreateResponseFromRaw>))]
public sealed record class TicketCreateResponse : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PublicID;
    }

    public TicketCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TicketCreateResponse(TicketCreateResponse ticketCreateResponse)
        : base(ticketCreateResponse) { }
#pragma warning restore CS8618

    public TicketCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TicketCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TicketCreateResponseFromRaw.FromRawUnchecked"/>
    public static TicketCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TicketCreateResponseFromRaw : IFromRawJson<TicketCreateResponse>
{
    /// <inheritdoc/>
    public TicketCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TicketCreateResponse.FromRawUnchecked(rawData);
}
