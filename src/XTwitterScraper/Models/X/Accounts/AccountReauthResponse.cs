// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

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
/// Sanitized X account summary returned by connect and reauth.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AccountReauthResponse, AccountReauthResponseFromRaw>))]
public sealed record class AccountReauthResponse : JsonModel
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

    public required ApiEnum<string, AccountReauthResponseHealth> Health
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountReauthResponseHealth>>(
                "health"
            );
        }
        init { this._rawData.Set("health", value); }
    }

    public JsonElement Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("status");
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

    public ApiEnum<string, AccountReauthResponseObject>? Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AccountReauthResponseObject>>(
                "object"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("object", value);
        }
    }

    public long? PollAfterMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("pollAfterMs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pollAfterMs", value);
        }
    }

    public System::DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("expiresAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expiresAt", value);
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

    public string? Username
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("username");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("username", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        this.Health.Validate();
        if (!JsonElement.DeepEquals(this.Status, JsonSerializer.SerializeToElement("active")))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        _ = this.XUserID;
        _ = this.XUsername;
        this.Object?.Validate();
        _ = this.PollAfterMs;
        _ = this.ExpiresAt;
        _ = this.Message;
        _ = this.Username;
    }

    public AccountReauthResponse()
    {
        this.Status = JsonSerializer.SerializeToElement("active");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountReauthResponse(AccountReauthResponse accountReauthResponse)
        : base(accountReauthResponse) { }
#pragma warning restore CS8618

    public AccountReauthResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Status = JsonSerializer.SerializeToElement("active");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountReauthResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountReauthResponseFromRaw.FromRawUnchecked"/>
    public static AccountReauthResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountReauthResponseFromRaw : IFromRawJson<AccountReauthResponse>
{
    /// <inheritdoc/>
    public AccountReauthResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountReauthResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AccountReauthResponseHealthConverter))]
public enum AccountReauthResponseHealth
{
    Healthy,
    Locked,
    NeedsReauth,
    Recovering,
    Suspended,
    TemporaryIssue,
}

sealed class AccountReauthResponseHealthConverter : JsonConverter<AccountReauthResponseHealth>
{
    public override AccountReauthResponseHealth Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "healthy" => AccountReauthResponseHealth.Healthy,
            "locked" => AccountReauthResponseHealth.Locked,
            "needsReauth" => AccountReauthResponseHealth.NeedsReauth,
            "recovering" => AccountReauthResponseHealth.Recovering,
            "suspended" => AccountReauthResponseHealth.Suspended,
            "temporaryIssue" => AccountReauthResponseHealth.TemporaryIssue,
            _ => (AccountReauthResponseHealth)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountReauthResponseHealth value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountReauthResponseHealth.Healthy => "healthy",
                AccountReauthResponseHealth.Locked => "locked",
                AccountReauthResponseHealth.NeedsReauth => "needsReauth",
                AccountReauthResponseHealth.Recovering => "recovering",
                AccountReauthResponseHealth.Suspended => "suspended",
                AccountReauthResponseHealth.TemporaryIssue => "temporaryIssue",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(AccountReauthResponseObjectConverter))]
public enum AccountReauthResponseObject
{
    XAccountConnectionAttempt,
    XAccountConnectionChallenge,
}

sealed class AccountReauthResponseObjectConverter : JsonConverter<AccountReauthResponseObject>
{
    public override AccountReauthResponseObject Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "x_account_connection_attempt" => AccountReauthResponseObject.XAccountConnectionAttempt,
            "x_account_connection_challenge" =>
                AccountReauthResponseObject.XAccountConnectionChallenge,
            _ => (AccountReauthResponseObject)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountReauthResponseObject value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountReauthResponseObject.XAccountConnectionAttempt =>
                    "x_account_connection_attempt",
                AccountReauthResponseObject.XAccountConnectionChallenge =>
                    "x_account_connection_challenge",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
