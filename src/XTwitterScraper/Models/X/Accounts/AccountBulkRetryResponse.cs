using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Accounts;

[JsonConverter(
    typeof(JsonModelConverter<AccountBulkRetryResponse, AccountBulkRetryResponseFromRaw>)
)]
public sealed record class AccountBulkRetryResponse : JsonModel
{
    /// <summary>
    /// Number of accounts cleared
    /// </summary>
    public required long Cleared
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("cleared");
        }
        init { this._rawData.Set("cleared", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Cleared;
    }

    public AccountBulkRetryResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountBulkRetryResponse(AccountBulkRetryResponse accountBulkRetryResponse)
        : base(accountBulkRetryResponse) { }
#pragma warning restore CS8618

    public AccountBulkRetryResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountBulkRetryResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountBulkRetryResponseFromRaw.FromRawUnchecked"/>
    public static AccountBulkRetryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AccountBulkRetryResponse(long cleared)
        : this()
    {
        this.Cleared = cleared;
    }
}

class AccountBulkRetryResponseFromRaw : IFromRawJson<AccountBulkRetryResponse>
{
    /// <inheritdoc/>
    public AccountBulkRetryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountBulkRetryResponse.FromRawUnchecked(rawData);
}
