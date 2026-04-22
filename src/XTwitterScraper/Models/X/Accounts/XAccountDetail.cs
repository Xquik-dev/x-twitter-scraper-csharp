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
/// Full X account details including proxy, cookies, and update timestamp.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<XAccountDetail, XAccountDetailFromRaw>))]
public sealed record class XAccountDetail : JsonModel
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

    public required ApiEnum<string, XAccountDetailHealth> Health
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, XAccountDetailHealth>>("health");
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

    public System::DateTimeOffset? CookiesObtainedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("cookiesObtainedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cookiesObtainedAt", value);
        }
    }

    public string? ProxyCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("proxyCountry");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("proxyCountry", value);
        }
    }

    public System::DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
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
        _ = this.CookiesObtainedAt;
        _ = this.ProxyCountry;
        _ = this.UpdatedAt;
    }

    public XAccountDetail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XAccountDetail(XAccountDetail xAccountDetail)
        : base(xAccountDetail) { }
#pragma warning restore CS8618

    public XAccountDetail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XAccountDetail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XAccountDetailFromRaw.FromRawUnchecked"/>
    public static XAccountDetail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XAccountDetailFromRaw : IFromRawJson<XAccountDetail>
{
    /// <inheritdoc/>
    public XAccountDetail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        XAccountDetail.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(XAccountDetailHealthConverter))]
public enum XAccountDetailHealth
{
    Healthy,
    Locked,
    NeedsReauth,
    Recovering,
    Suspended,
    TemporaryIssue,
}

sealed class XAccountDetailHealthConverter : JsonConverter<XAccountDetailHealth>
{
    public override XAccountDetailHealth Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "healthy" => XAccountDetailHealth.Healthy,
            "locked" => XAccountDetailHealth.Locked,
            "needsReauth" => XAccountDetailHealth.NeedsReauth,
            "recovering" => XAccountDetailHealth.Recovering,
            "suspended" => XAccountDetailHealth.Suspended,
            "temporaryIssue" => XAccountDetailHealth.TemporaryIssue,
            _ => (XAccountDetailHealth)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        XAccountDetailHealth value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                XAccountDetailHealth.Healthy => "healthy",
                XAccountDetailHealth.Locked => "locked",
                XAccountDetailHealth.NeedsReauth => "needsReauth",
                XAccountDetailHealth.Recovering => "recovering",
                XAccountDetailHealth.Suspended => "suspended",
                XAccountDetailHealth.TemporaryIssue => "temporaryIssue",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
