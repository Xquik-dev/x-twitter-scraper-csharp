using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.ApiKeys;

[JsonConverter(typeof(JsonModelConverter<ApiKeyListResponse, ApiKeyListResponseFromRaw>))]
public sealed record class ApiKeyListResponse : JsonModel
{
    public required IReadOnlyList<ApiKey> Keys
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ApiKey>>("keys");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiKey>>(
                "keys",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Keys)
        {
            item.Validate();
        }
    }

    public ApiKeyListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiKeyListResponse(ApiKeyListResponse apiKeyListResponse)
        : base(apiKeyListResponse) { }
#pragma warning restore CS8618

    public ApiKeyListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiKeyListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiKeyListResponseFromRaw.FromRawUnchecked"/>
    public static ApiKeyListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ApiKeyListResponse(IReadOnlyList<ApiKey> keys)
        : this()
    {
        this.Keys = keys;
    }
}

class ApiKeyListResponseFromRaw : IFromRawJson<ApiKeyListResponse>
{
    /// <inheritdoc/>
    public ApiKeyListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ApiKeyListResponse.FromRawUnchecked(rawData);
}
