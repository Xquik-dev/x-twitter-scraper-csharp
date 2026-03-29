using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.Credits;

[JsonConverter(
    typeof(JsonModelConverter<CreditTopupBalanceResponse, CreditTopupBalanceResponseFromRaw>)
)]
public sealed record class CreditTopupBalanceResponse : JsonModel
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

    public CreditTopupBalanceResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditTopupBalanceResponse(CreditTopupBalanceResponse creditTopupBalanceResponse)
        : base(creditTopupBalanceResponse) { }
#pragma warning restore CS8618

    public CreditTopupBalanceResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditTopupBalanceResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditTopupBalanceResponseFromRaw.FromRawUnchecked"/>
    public static CreditTopupBalanceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditTopupBalanceResponseFromRaw : IFromRawJson<CreditTopupBalanceResponse>
{
    /// <inheritdoc/>
    public CreditTopupBalanceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditTopupBalanceResponse.FromRawUnchecked(rawData);
}
