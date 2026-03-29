using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.ApiKeys;

[JsonConverter(typeof(JsonModelConverter<ApiKeyCreateResponse, ApiKeyCreateResponseFromRaw>))]
public sealed record class ApiKeyCreateResponse : JsonModel
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

    public required string FullKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("fullKey");
        }
        init { this._rawData.Set("fullKey", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required string Prefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("prefix");
        }
        init { this._rawData.Set("prefix", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.FullKey;
        _ = this.Name;
        _ = this.Prefix;
    }

    public ApiKeyCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiKeyCreateResponse(ApiKeyCreateResponse apiKeyCreateResponse)
        : base(apiKeyCreateResponse) { }
#pragma warning restore CS8618

    public ApiKeyCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiKeyCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiKeyCreateResponseFromRaw.FromRawUnchecked"/>
    public static ApiKeyCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiKeyCreateResponseFromRaw : IFromRawJson<ApiKeyCreateResponse>
{
    /// <inheritdoc/>
    public ApiKeyCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiKeyCreateResponse.FromRawUnchecked(rawData);
}
