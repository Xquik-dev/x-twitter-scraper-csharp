// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(XAccountConnectionLinkObjectConverter))]
public enum XAccountConnectionLinkObject
{
    XAccountConnectionLink,
}

sealed class XAccountConnectionLinkObjectConverter : JsonConverter<XAccountConnectionLinkObject>
{
    public override XAccountConnectionLinkObject Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "x_account_connection_link" => XAccountConnectionLinkObject.XAccountConnectionLink,
            _ => (XAccountConnectionLinkObject)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        XAccountConnectionLinkObject value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                XAccountConnectionLinkObject.XAccountConnectionLink => "x_account_connection_link",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(XAccountConnectionLinkPurposeConverter))]
public enum XAccountConnectionLinkPurpose
{
    Connect,
    Reconnect,
}

sealed class XAccountConnectionLinkPurposeConverter : JsonConverter<XAccountConnectionLinkPurpose>
{
    public override XAccountConnectionLinkPurpose Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "connect" => XAccountConnectionLinkPurpose.Connect,
            "reconnect" => XAccountConnectionLinkPurpose.Reconnect,
            _ => (XAccountConnectionLinkPurpose)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        XAccountConnectionLinkPurpose value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                XAccountConnectionLinkPurpose.Connect => "connect",
                XAccountConnectionLinkPurpose.Reconnect => "reconnect",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(XAccountConnectionLinkStatusConverter))]
public enum XAccountConnectionLinkStatus
{
    Pending,
    Connecting,
    RequiresEmailCode,
    Connected,
    Failed,
    Expired,
    Revoked,
}

sealed class XAccountConnectionLinkStatusConverter : JsonConverter<XAccountConnectionLinkStatus>
{
    public override XAccountConnectionLinkStatus Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => XAccountConnectionLinkStatus.Pending,
            "connecting" => XAccountConnectionLinkStatus.Connecting,
            "requires_email_code" => XAccountConnectionLinkStatus.RequiresEmailCode,
            "connected" => XAccountConnectionLinkStatus.Connected,
            "failed" => XAccountConnectionLinkStatus.Failed,
            "expired" => XAccountConnectionLinkStatus.Expired,
            "revoked" => XAccountConnectionLinkStatus.Revoked,
            _ => (XAccountConnectionLinkStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        XAccountConnectionLinkStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                XAccountConnectionLinkStatus.Pending => "pending",
                XAccountConnectionLinkStatus.Connecting => "connecting",
                XAccountConnectionLinkStatus.RequiresEmailCode => "requires_email_code",
                XAccountConnectionLinkStatus.Connected => "connected",
                XAccountConnectionLinkStatus.Failed => "failed",
                XAccountConnectionLinkStatus.Expired => "expired",
                XAccountConnectionLinkStatus.Revoked => "revoked",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<XAccountConnectionLink, XAccountConnectionLinkFromRaw>))]
public sealed record class XAccountConnectionLink : JsonModel
{
    public required ApiEnum<string, XAccountConnectionLinkObject> Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, XAccountConnectionLinkObject>>(
                "object"
            );
        }
        init { this._rawData.Set("object", value); }
    }

    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required ApiEnum<string, XAccountConnectionLinkPurpose> Purpose
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, XAccountConnectionLinkPurpose>>(
                "purpose"
            );
        }
        init { this._rawData.Set("purpose", value); }
    }

    /// <summary>
    /// `failed` means 5 logins were refused, so make a new link.
    /// </summary>
    public required ApiEnum<string, XAccountConnectionLinkStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, XAccountConnectionLinkStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required string? Reference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference");
        }
        init { this._rawData.Set("reference", value); }
    }

    public required string? ReturnUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("returnUrl");
        }
        init { this._rawData.Set("returnUrl", value); }
    }

    public required string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("accountId");
        }
        init { this._rawData.Set("accountId", value); }
    }

    public required string? XUserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("xUserId");
        }
        init { this._rawData.Set("xUserId", value); }
    }

    public required string? XUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("xUsername");
        }
        init { this._rawData.Set("xUsername", value); }
    }

    public required string? Health
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("health");
        }
        init { this._rawData.Set("health", value); }
    }

    /// <summary>
    /// Why the last login didn't finish.
    /// </summary>
    public required string? Failure
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("failure");
        }
        init { this._rawData.Set("failure", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("expiresAt");
        }
        init { this._rawData.Set("expiresAt", value); }
    }

    public required DateTimeOffset? CompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("completedAt");
        }
        init { this._rawData.Set("completedAt", value); }
    }

    /// <summary>
    /// Present only in the response that creates the link.
    /// </summary>
    public string? UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Object.Validate();
        _ = this.ID;
        this.Purpose.Validate();
        this.Status.Validate();
        _ = this.Reference;
        _ = this.ReturnUrl;
        _ = this.AccountID;
        _ = this.XUserID;
        _ = this.XUsername;
        _ = this.Health;
        _ = this.Failure;
        _ = this.CreatedAt;
        _ = this.ExpiresAt;
        _ = this.CompletedAt;
        _ = this.UrlValue;
    }

    public XAccountConnectionLink() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XAccountConnectionLink(XAccountConnectionLink xAccountConnectionLink)
        : base(xAccountConnectionLink) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XAccountConnectionLink(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XAccountConnectionLink(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XAccountConnectionLinkFromRaw.FromRawUnchecked"/>
    public static XAccountConnectionLink FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XAccountConnectionLinkFromRaw : IFromRawJson<XAccountConnectionLink>
{
    /// <inheritdoc/>
    public XAccountConnectionLink FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => XAccountConnectionLink.FromRawUnchecked(rawData);
}
