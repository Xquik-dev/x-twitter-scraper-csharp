using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Accounts;

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

    public required string Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
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
        _ = this.Status;
        _ = this.XUsername;
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
