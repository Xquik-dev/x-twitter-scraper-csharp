using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.Support.Tickets;

[JsonConverter(typeof(JsonModelConverter<TicketUpdateResponse, TicketUpdateResponseFromRaw>))]
public sealed record class TicketUpdateResponse : JsonModel
{
    public required string PublicID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("publicId");
        }
        init { this._rawData.Set("publicId", value); }
    }

    public required ApiEnum<string, TicketUpdateResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TicketUpdateResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PublicID;
        this.Status.Validate();
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

[JsonConverter(typeof(TicketUpdateResponseStatusConverter))]
public enum TicketUpdateResponseStatus
{
    Open,
    Resolved,
    Closed,
}

sealed class TicketUpdateResponseStatusConverter : JsonConverter<TicketUpdateResponseStatus>
{
    public override TicketUpdateResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "open" => TicketUpdateResponseStatus.Open,
            "resolved" => TicketUpdateResponseStatus.Resolved,
            "closed" => TicketUpdateResponseStatus.Closed,
            _ => (TicketUpdateResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TicketUpdateResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TicketUpdateResponseStatus.Open => "open",
                TicketUpdateResponseStatus.Resolved => "resolved",
                TicketUpdateResponseStatus.Closed => "closed",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
