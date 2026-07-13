using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.Credits;

[JsonConverter(
    typeof(JsonModelConverter<
        CreditRetrieveTopupStatusResponse,
        CreditRetrieveTopupStatusResponseFromRaw
    >)
)]
public sealed record class CreditRetrieveTopupStatusResponse : JsonModel
{
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Dollar amount requested for the top-up.
    /// </summary>
    public long? AmountDollars
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("amount_dollars");
        }
        init { this._rawData.Set("amount_dollars", value); }
    }

    /// <summary>
    /// Bigint string credit amount granted or pending.
    /// </summary>
    public string? Credits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("credits");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("credits", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
        _ = this.AmountDollars;
        _ = this.Credits;
    }

    public CreditRetrieveTopupStatusResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditRetrieveTopupStatusResponse(
        CreditRetrieveTopupStatusResponse creditRetrieveTopupStatusResponse
    )
        : base(creditRetrieveTopupStatusResponse) { }
#pragma warning restore CS8618

    public CreditRetrieveTopupStatusResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditRetrieveTopupStatusResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditRetrieveTopupStatusResponseFromRaw.FromRawUnchecked"/>
    public static CreditRetrieveTopupStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CreditRetrieveTopupStatusResponse(ApiEnum<string, Status> status)
        : this()
    {
        this.Status = status;
    }
}

class CreditRetrieveTopupStatusResponseFromRaw : IFromRawJson<CreditRetrieveTopupStatusResponse>
{
    /// <inheritdoc/>
    public CreditRetrieveTopupStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditRetrieveTopupStatusResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Paid,
    Processing,
    Failed,
    Expired,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "paid" => Status.Paid,
            "processing" => Status.Processing,
            "failed" => Status.Failed,
            "expired" => Status.Expired,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Paid => "paid",
                Status.Processing => "processing",
                Status.Failed => "failed",
                Status.Expired => "expired",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
