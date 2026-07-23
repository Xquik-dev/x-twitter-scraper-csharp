using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.X.AccountConnectionChallenges;

/// <summary>
/// Sanitized X account summary returned by connect and reauth.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AccountConnectionChallengeSubmitResponse,
        AccountConnectionChallengeSubmitResponseFromRaw
    >)
)]
public sealed record class AccountConnectionChallengeSubmitResponse : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
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

    public required ApiEnum<string, Health> Health
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Health>>("health");
        }
        init { this._rawData.Set("health", value); }
    }

    public required string Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required string XUserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("xUserId");
        }
        init { this._rawData.Set("xUserId", value); }
    }

    public required string XUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("xUsername");
        }
        init { this._rawData.Set("xUsername", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        this.Health.Validate();
        _ = this.Status;
        _ = this.XUserID;
        _ = this.XUsername;
    }

    public AccountConnectionChallengeSubmitResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountConnectionChallengeSubmitResponse(
        AccountConnectionChallengeSubmitResponse accountConnectionChallengeSubmitResponse
    )
        : base(accountConnectionChallengeSubmitResponse) { }
#pragma warning restore CS8618

    public AccountConnectionChallengeSubmitResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountConnectionChallengeSubmitResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountConnectionChallengeSubmitResponseFromRaw.FromRawUnchecked"/>
    public static AccountConnectionChallengeSubmitResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountConnectionChallengeSubmitResponseFromRaw
    : IFromRawJson<AccountConnectionChallengeSubmitResponse>
{
    /// <inheritdoc/>
    public AccountConnectionChallengeSubmitResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountConnectionChallengeSubmitResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(HealthConverter))]
public enum Health
{
    Healthy,
    Locked,
    NeedsReauth,
    Recovering,
    Suspended,
    TemporaryIssue,
}

sealed class HealthConverter : JsonConverter<Health>
{
    public override Health Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "healthy" => Health.Healthy,
            "locked" => Health.Locked,
            "needsReauth" => Health.NeedsReauth,
            "recovering" => Health.Recovering,
            "suspended" => Health.Suspended,
            "temporaryIssue" => Health.TemporaryIssue,
            _ => (Health)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Health value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Health.Healthy => "healthy",
                Health.Locked => "locked",
                Health.NeedsReauth => "needsReauth",
                Health.Recovering => "recovering",
                Health.Suspended => "suspended",
                Health.TemporaryIssue => "temporaryIssue",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
