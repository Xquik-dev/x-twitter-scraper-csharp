using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.X.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountDeleteResponse, AccountDeleteResponseFromRaw>))]
public sealed record class AccountDeleteResponse : JsonModel
{
    public JsonElement Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(true)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
    }

    public AccountDeleteResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountDeleteResponse(AccountDeleteResponse accountDeleteResponse)
        : base(accountDeleteResponse) { }
#pragma warning restore CS8618

    public AccountDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountDeleteResponseFromRaw.FromRawUnchecked"/>
    public static AccountDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountDeleteResponseFromRaw : IFromRawJson<AccountDeleteResponse>
{
    /// <inheritdoc/>
    public AccountDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountDeleteResponse.FromRawUnchecked(rawData);
}
