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
/// Sanitized X account summary returned by connect and reauth. Includes an optional
/// `loginCountry` field surfaced only when the declared proxy region had no Driver
/// capacity and the login fell back to a single US consumer device for this one-time
/// action. Future activity continues to use the selected `proxy_country`; the field
/// is omitted on normal logins.
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

    /// <summary>
    /// ISO-3166-1 alpha-2 country code of the Driver consumer device used for this
    /// login. Present only when the US fallback was triggered because Driver had
    /// no capacity in the declared region. Omitted otherwise.
    /// </summary>
    public string? LoginCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("loginCountry");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("loginCountry", value);
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
        _ = this.LoginCountry;
    }

    public AccountReauthResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountReauthResponse(AccountReauthResponse accountReauthResponse)
        : base(accountReauthResponse) { }
#pragma warning restore CS8618

    public AccountReauthResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
