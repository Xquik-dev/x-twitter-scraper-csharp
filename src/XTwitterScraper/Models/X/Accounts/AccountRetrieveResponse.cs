using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountRetrieveResponse, AccountRetrieveResponseFromRaw>))]
public sealed record class AccountRetrieveResponse : JsonModel
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

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
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

    public DateTimeOffset? CookiesObtainedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("cookiesObtainedAt");
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

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
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
        _ = this.Status;
        _ = this.XUserID;
        _ = this.XUsername;
        _ = this.CookiesObtainedAt;
        _ = this.ProxyCountry;
        _ = this.UpdatedAt;
    }

    public AccountRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountRetrieveResponse(AccountRetrieveResponse accountRetrieveResponse)
        : base(accountRetrieveResponse) { }
#pragma warning restore CS8618

    public AccountRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static AccountRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountRetrieveResponseFromRaw : IFromRawJson<AccountRetrieveResponse>
{
    /// <inheritdoc/>
    public AccountRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountRetrieveResponse.FromRawUnchecked(rawData);
}
