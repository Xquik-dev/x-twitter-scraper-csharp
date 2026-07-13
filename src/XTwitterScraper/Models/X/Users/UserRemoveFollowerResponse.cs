using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.X.Users;

[JsonConverter(
    typeof(JsonModelConverter<UserRemoveFollowerResponse, UserRemoveFollowerResponseFromRaw>)
)]
public sealed record class UserRemoveFollowerResponse : JsonModel
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

    public UserRemoveFollowerResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserRemoveFollowerResponse(UserRemoveFollowerResponse userRemoveFollowerResponse)
        : base(userRemoveFollowerResponse) { }
#pragma warning restore CS8618

    public UserRemoveFollowerResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRemoveFollowerResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserRemoveFollowerResponseFromRaw.FromRawUnchecked"/>
    public static UserRemoveFollowerResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserRemoveFollowerResponseFromRaw : IFromRawJson<UserRemoveFollowerResponse>
{
    /// <inheritdoc/>
    public UserRemoveFollowerResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserRemoveFollowerResponse.FromRawUnchecked(rawData);
}
