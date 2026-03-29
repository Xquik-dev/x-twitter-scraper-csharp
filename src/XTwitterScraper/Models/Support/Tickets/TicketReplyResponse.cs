using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Support.Tickets;

[JsonConverter(typeof(JsonModelConverter<TicketReplyResponse, TicketReplyResponseFromRaw>))]
public sealed record class TicketReplyResponse : JsonModel
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

    public TicketReplyResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TicketReplyResponse(TicketReplyResponse ticketReplyResponse)
        : base(ticketReplyResponse) { }
#pragma warning restore CS8618

    public TicketReplyResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TicketReplyResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TicketReplyResponseFromRaw.FromRawUnchecked"/>
    public static TicketReplyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TicketReplyResponseFromRaw : IFromRawJson<TicketReplyResponse>
{
    /// <inheritdoc/>
    public TicketReplyResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TicketReplyResponse.FromRawUnchecked(rawData);
}
