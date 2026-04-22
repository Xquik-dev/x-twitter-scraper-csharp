using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.X.Accounts;

/// <summary>
/// Linked X account summary with username and connection status.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<XAccount, XAccountFromRaw>))]
public sealed record class XAccount : JsonModel
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

    /// <summary>
    /// Derived login/cookie health. `healthy` = cookies valid. `needsReauth` = user
    /// must submit fresh credentials. `locked` = X locked the account; unlock on
    /// x.com first. `suspended` = X banned the account. `recovering` = past cooldown,
    /// will auto-retry on next use. `temporaryIssue` = transient backend problem;
    /// retry shortly.
    /// </summary>
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

    public XAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XAccount(XAccount xAccount)
        : base(xAccount) { }
#pragma warning restore CS8618

    public XAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XAccountFromRaw.FromRawUnchecked"/>
    public static XAccount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XAccountFromRaw : IFromRawJson<XAccount>
{
    /// <inheritdoc/>
    public XAccount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        XAccount.FromRawUnchecked(rawData);
}

/// <summary>
/// Derived login/cookie health. `healthy` = cookies valid. `needsReauth` = user
/// must submit fresh credentials. `locked` = X locked the account; unlock on x.com
/// first. `suspended` = X banned the account. `recovering` = past cooldown, will
/// auto-retry on next use. `temporaryIssue` = transient backend problem; retry shortly.
/// </summary>
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
