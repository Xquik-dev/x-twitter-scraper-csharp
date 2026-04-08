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
    public required IReadOnlyList<XAccount> Accounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<XAccount>>("accounts");
        }
        init
        {
            this._rawData.Set<ImmutableArray<XAccount>>(
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
    public AccountListResponse(IReadOnlyList<XAccount> accounts)
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
