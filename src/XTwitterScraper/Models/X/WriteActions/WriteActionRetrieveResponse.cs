using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.X.WriteActions;

[JsonConverter(
    typeof(JsonModelConverter<WriteActionRetrieveResponse, WriteActionRetrieveResponseFromRaw>)
)]
public sealed record class WriteActionRetrieveResponse : JsonModel
{
    public required string Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("action");
        }
        init { this._rawData.Set("action", value); }
    }

    public required bool Charged
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("charged");
        }
        init { this._rawData.Set("charged", value); }
    }

    public required string ChargedCredits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("chargedCredits");
        }
        init { this._rawData.Set("chargedCredits", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required WriteActionRetrieveResponseMedia Media
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<WriteActionRetrieveResponseMedia>("media");
        }
        init { this._rawData.Set("media", value); }
    }

    public JsonElement Retryable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("retryable");
        }
        init { this._rawData.Set("retryable", value); }
    }

    public required bool SendDispatched
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("sendDispatched");
        }
        init { this._rawData.Set("sendDispatched", value); }
    }

    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required string WriteActionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("writeActionId");
        }
        init { this._rawData.Set("writeActionId", value); }
    }

    public long? ConfirmationAttempts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("confirmationAttempts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confirmationAttempts", value);
        }
    }

    public System::DateTimeOffset? ConfirmationCheckedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("confirmationCheckedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confirmationCheckedAt", value);
        }
    }

    public string? ConfirmationSource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("confirmationSource");
        }
        init { this._rawData.Set("confirmationSource", value); }
    }

    public System::DateTimeOffset? ConfirmedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("confirmedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confirmedAt", value);
        }
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

    public string? MessageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("messageId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("messageId", value);
        }
    }

    public System::DateTimeOffset? SendDispatchedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("sendDispatchedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sendDispatchedAt", value);
        }
    }

    public string? TargetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("targetId");
        }
        init { this._rawData.Set("targetId", value); }
    }

    public string? TweetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tweetId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tweetId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Action;
        _ = this.Charged;
        _ = this.ChargedCredits;
        _ = this.CreatedAt;
        this.Media.Validate();
        if (!JsonElement.DeepEquals(this.Retryable, JsonSerializer.SerializeToElement(false)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        _ = this.SendDispatched;
        this.Status.Validate();
        _ = this.WriteActionID;
        _ = this.ConfirmationAttempts;
        _ = this.ConfirmationCheckedAt;
        _ = this.ConfirmationSource;
        _ = this.ConfirmedAt;
        _ = this.Message;
        _ = this.MessageID;
        _ = this.SendDispatchedAt;
        _ = this.TargetID;
        _ = this.TweetID;
    }

    public WriteActionRetrieveResponse()
    {
        this.Retryable = JsonSerializer.SerializeToElement(false);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WriteActionRetrieveResponse(WriteActionRetrieveResponse writeActionRetrieveResponse)
        : base(writeActionRetrieveResponse) { }
#pragma warning restore CS8618

    public WriteActionRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Retryable = JsonSerializer.SerializeToElement(false);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WriteActionRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WriteActionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static WriteActionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WriteActionRetrieveResponseFromRaw : IFromRawJson<WriteActionRetrieveResponse>
{
    /// <inheritdoc/>
    public WriteActionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WriteActionRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        WriteActionRetrieveResponseMedia,
        WriteActionRetrieveResponseMediaFromRaw
    >)
)]
public sealed record class WriteActionRetrieveResponseMedia : JsonModel
{
    public required long Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    public required string Credits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credits");
        }
        init { this._rawData.Set("credits", value); }
    }

    public required ApiEnum<string, Kind> Kind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Kind>>("kind");
        }
        init { this._rawData.Set("kind", value); }
    }

    public required string TotalBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("totalBytes");
        }
        init { this._rawData.Set("totalBytes", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        _ = this.Credits;
        this.Kind.Validate();
        _ = this.TotalBytes;
    }

    public WriteActionRetrieveResponseMedia() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WriteActionRetrieveResponseMedia(
        WriteActionRetrieveResponseMedia writeActionRetrieveResponseMedia
    )
        : base(writeActionRetrieveResponseMedia) { }
#pragma warning restore CS8618

    public WriteActionRetrieveResponseMedia(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WriteActionRetrieveResponseMedia(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WriteActionRetrieveResponseMediaFromRaw.FromRawUnchecked"/>
    public static WriteActionRetrieveResponseMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WriteActionRetrieveResponseMediaFromRaw : IFromRawJson<WriteActionRetrieveResponseMedia>
{
    /// <inheritdoc/>
    public WriteActionRetrieveResponseMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WriteActionRetrieveResponseMedia.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(KindConverter))]
public enum Kind
{
    None,
    Image,
    Video,
}

sealed class KindConverter : JsonConverter<Kind>
{
    public override Kind Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => Kind.None,
            "image" => Kind.Image,
            "video" => Kind.Video,
            _ => (Kind)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Kind value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Kind.None => "none",
                Kind.Image => "image",
                Kind.Video => "video",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Success,
    Failed,
    PendingConfirmation,
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
            "success" => Status.Success,
            "failed" => Status.Failed,
            "pending_confirmation" => Status.PendingConfirmation,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Success => "success",
                Status.Failed => "failed",
                Status.PendingConfirmation => "pending_confirmation",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
