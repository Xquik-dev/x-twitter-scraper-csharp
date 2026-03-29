using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.Account;

[JsonConverter(
    typeof(JsonModelConverter<AccountSetXUsernameResponse, AccountSetXUsernameResponseFromRaw>)
)]
public sealed record class AccountSetXUsernameResponse : JsonModel
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
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(true)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        _ = this.XUsername;
    }

    public AccountSetXUsernameResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountSetXUsernameResponse(AccountSetXUsernameResponse accountSetXUsernameResponse)
        : base(accountSetXUsernameResponse) { }
#pragma warning restore CS8618

    public AccountSetXUsernameResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountSetXUsernameResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountSetXUsernameResponseFromRaw.FromRawUnchecked"/>
    public static AccountSetXUsernameResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AccountSetXUsernameResponse(string xUsername)
        : this()
    {
        this.XUsername = xUsername;
    }
}

class AccountSetXUsernameResponseFromRaw : IFromRawJson<AccountSetXUsernameResponse>
{
    /// <inheritdoc/>
    public AccountSetXUsernameResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountSetXUsernameResponse.FromRawUnchecked(rawData);
}
