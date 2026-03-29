using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.Subscribe;

[JsonConverter(typeof(JsonModelConverter<SubscribeCreateResponse, SubscribeCreateResponseFromRaw>))]
public sealed record class SubscribeCreateResponse : JsonModel
{
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>("status");
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
        _ = this.Url;
        _ = this.Message;
        this.Status?.Validate();
    }

    public SubscribeCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscribeCreateResponse(SubscribeCreateResponse subscribeCreateResponse)
        : base(subscribeCreateResponse) { }
#pragma warning restore CS8618

    public SubscribeCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscribeCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscribeCreateResponseFromRaw.FromRawUnchecked"/>
    public static SubscribeCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscribeCreateResponse(string url)
        : this()
    {
        this.Url = url;
    }
}

class SubscribeCreateResponseFromRaw : IFromRawJson<SubscribeCreateResponse>
{
    /// <inheritdoc/>
    public SubscribeCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscribeCreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    CheckoutCreated,
    AlreadySubscribed,
    PaymentIssue,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "checkout_created" => Status.CheckoutCreated,
            "already_subscribed" => Status.AlreadySubscribed,
            "payment_issue" => Status.PaymentIssue,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.CheckoutCreated => "checkout_created",
                Status.AlreadySubscribed => "already_subscribed",
                Status.PaymentIssue => "payment_issue",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
