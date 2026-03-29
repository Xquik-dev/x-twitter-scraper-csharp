using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.ApiKeys;

[JsonConverter(typeof(JsonModelConverter<ApiKeyRevokeResponse, ApiKeyRevokeResponseFromRaw>))]
public sealed record class ApiKeyRevokeResponse : JsonModel
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

    public ApiKeyRevokeResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiKeyRevokeResponse(ApiKeyRevokeResponse apiKeyRevokeResponse)
        : base(apiKeyRevokeResponse) { }
#pragma warning restore CS8618

    public ApiKeyRevokeResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiKeyRevokeResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiKeyRevokeResponseFromRaw.FromRawUnchecked"/>
    public static ApiKeyRevokeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiKeyRevokeResponseFromRaw : IFromRawJson<ApiKeyRevokeResponse>
{
    /// <inheritdoc/>
    public ApiKeyRevokeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiKeyRevokeResponse.FromRawUnchecked(rawData);
}
