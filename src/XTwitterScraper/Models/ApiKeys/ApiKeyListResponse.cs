using System;
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
    public required IReadOnlyList<Key> Keys
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Key>>("keys");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Key>>("keys", ImmutableArray.ToImmutableArray(value));
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
    public ApiKeyListResponse(IReadOnlyList<Key> keys)
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

[JsonConverter(typeof(JsonModelConverter<Key, KeyFromRaw>))]
public sealed record class Key : JsonModel
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

    public required bool IsActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isActive");
        }
        init { this._rawData.Set("isActive", value); }
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

    public DateTimeOffset? LastUsedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("lastUsedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lastUsedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.IsActive;
        _ = this.Name;
        _ = this.Prefix;
        _ = this.LastUsedAt;
    }

    public Key() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Key(Key key)
        : base(key) { }
#pragma warning restore CS8618

    public Key(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Key(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="KeyFromRaw.FromRawUnchecked"/>
    public static Key FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class KeyFromRaw : IFromRawJson<Key>
{
    /// <inheritdoc/>
    public Key FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Key.FromRawUnchecked(rawData);
}
