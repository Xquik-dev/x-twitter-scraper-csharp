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

namespace XTwitterScraper.Models.X.AccountConnectionLinks;

[JsonConverter(
    typeof(JsonModelConverter<
        AccountConnectionLinkCreateResponse,
        AccountConnectionLinkCreateResponseFromRaw
    >)
)]
public sealed record class AccountConnectionLinkCreateResponse : JsonModel
{
    public required ApiEnum<string, AccountConnectionLinkCreateResponseObject> Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AccountConnectionLinkCreateResponseObject>
            >("object");
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

    public required ApiEnum<string, AccountConnectionLinkCreateResponsePurpose> Purpose
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AccountConnectionLinkCreateResponsePurpose>
            >("purpose");
        }
        init { this._rawData.Set("purpose", value); }
    }

    /// <summary>
    /// `failed` means 5 logins were refused, so make a new link.
    /// </summary>
    public required ApiEnum<string, AccountConnectionLinkCreateResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AccountConnectionLinkCreateResponseStatus>
            >("status");
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
    public required string UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
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

    public AccountConnectionLinkCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountConnectionLinkCreateResponse(
        AccountConnectionLinkCreateResponse accountConnectionLinkCreateResponse
    )
        : base(accountConnectionLinkCreateResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountConnectionLinkCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountConnectionLinkCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountConnectionLinkCreateResponseFromRaw.FromRawUnchecked"/>
    public static AccountConnectionLinkCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountConnectionLinkCreateResponseFromRaw : IFromRawJson<AccountConnectionLinkCreateResponse>
{
    /// <inheritdoc/>
    public AccountConnectionLinkCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountConnectionLinkCreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AccountConnectionLinkCreateResponseObjectConverter))]
public enum AccountConnectionLinkCreateResponseObject
{
    XAccountConnectionLink,
}

sealed class AccountConnectionLinkCreateResponseObjectConverter
    : JsonConverter<AccountConnectionLinkCreateResponseObject>
{
    public override AccountConnectionLinkCreateResponseObject Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "x_account_connection_link" =>
                AccountConnectionLinkCreateResponseObject.XAccountConnectionLink,
            _ => (AccountConnectionLinkCreateResponseObject)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountConnectionLinkCreateResponseObject value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountConnectionLinkCreateResponseObject.XAccountConnectionLink =>
                    "x_account_connection_link",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(AccountConnectionLinkCreateResponsePurposeConverter))]
public enum AccountConnectionLinkCreateResponsePurpose
{
    Connect,
    Reconnect,
}

sealed class AccountConnectionLinkCreateResponsePurposeConverter
    : JsonConverter<AccountConnectionLinkCreateResponsePurpose>
{
    public override AccountConnectionLinkCreateResponsePurpose Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "connect" => AccountConnectionLinkCreateResponsePurpose.Connect,
            "reconnect" => AccountConnectionLinkCreateResponsePurpose.Reconnect,
            _ => (AccountConnectionLinkCreateResponsePurpose)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountConnectionLinkCreateResponsePurpose value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountConnectionLinkCreateResponsePurpose.Connect => "connect",
                AccountConnectionLinkCreateResponsePurpose.Reconnect => "reconnect",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(AccountConnectionLinkCreateResponseStatusConverter))]
public enum AccountConnectionLinkCreateResponseStatus
{
    Pending,
    Connecting,
    RequiresEmailCode,
    Connected,
    Failed,
    Expired,
    Revoked,
}

sealed class AccountConnectionLinkCreateResponseStatusConverter
    : JsonConverter<AccountConnectionLinkCreateResponseStatus>
{
    public override AccountConnectionLinkCreateResponseStatus Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => AccountConnectionLinkCreateResponseStatus.Pending,
            "connecting" => AccountConnectionLinkCreateResponseStatus.Connecting,
            "requires_email_code" => AccountConnectionLinkCreateResponseStatus.RequiresEmailCode,
            "connected" => AccountConnectionLinkCreateResponseStatus.Connected,
            "failed" => AccountConnectionLinkCreateResponseStatus.Failed,
            "expired" => AccountConnectionLinkCreateResponseStatus.Expired,
            "revoked" => AccountConnectionLinkCreateResponseStatus.Revoked,
            _ => (AccountConnectionLinkCreateResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountConnectionLinkCreateResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountConnectionLinkCreateResponseStatus.Pending => "pending",
                AccountConnectionLinkCreateResponseStatus.Connecting => "connecting",
                AccountConnectionLinkCreateResponseStatus.RequiresEmailCode =>
                    "requires_email_code",
                AccountConnectionLinkCreateResponseStatus.Connected => "connected",
                AccountConnectionLinkCreateResponseStatus.Failed => "failed",
                AccountConnectionLinkCreateResponseStatus.Expired => "expired",
                AccountConnectionLinkCreateResponseStatus.Revoked => "revoked",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
