using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.X.Users.Follow;

[JsonConverter(typeof(JsonModelConverter<FollowDeleteAllResponse, FollowDeleteAllResponseFromRaw>))]
public sealed record class FollowDeleteAllResponse : JsonModel
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

    public FollowDeleteAllResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowDeleteAllResponse(FollowDeleteAllResponse followDeleteAllResponse)
        : base(followDeleteAllResponse) { }
#pragma warning restore CS8618

    public FollowDeleteAllResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowDeleteAllResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowDeleteAllResponseFromRaw.FromRawUnchecked"/>
    public static FollowDeleteAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FollowDeleteAllResponseFromRaw : IFromRawJson<FollowDeleteAllResponse>
{
    /// <inheritdoc/>
    public FollowDeleteAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FollowDeleteAllResponse.FromRawUnchecked(rawData);
}
