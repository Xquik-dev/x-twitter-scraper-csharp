using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountListResponse, AccountListResponseFromRaw>))]
public sealed record class AccountListResponse : JsonModel
{
    public required IReadOnlyList<AccountListResponseAccount> Accounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AccountListResponseAccount>>(
                "accounts"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<AccountListResponseAccount>>(
                "accounts",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Accounts)
        {
            item.Validate();
        }
    }

    public AccountListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountListResponse(AccountListResponse accountListResponse)
        : base(accountListResponse) { }
#pragma warning restore CS8618

    public AccountListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountListResponseFromRaw.FromRawUnchecked"/>
    public static AccountListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AccountListResponse(IReadOnlyList<AccountListResponseAccount> accounts)
        : this()
    {
        this.Accounts = accounts;
    }
}

class AccountListResponseFromRaw : IFromRawJson<AccountListResponse>
{
    /// <inheritdoc/>
    public AccountListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccountListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Linked X account summary with username and connection status.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AccountListResponseAccount, AccountListResponseAccountFromRaw>)
)]
public sealed record class AccountListResponseAccount : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Status;
        _ = this.XUserID;
        _ = this.XUsername;
    }

    public AccountListResponseAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountListResponseAccount(AccountListResponseAccount accountListResponseAccount)
        : base(accountListResponseAccount) { }
#pragma warning restore CS8618

    public AccountListResponseAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountListResponseAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountListResponseAccountFromRaw.FromRawUnchecked"/>
    public static AccountListResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountListResponseAccountFromRaw : IFromRawJson<AccountListResponseAccount>
{
    /// <inheritdoc/>
    public AccountListResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountListResponseAccount.FromRawUnchecked(rawData);
}
