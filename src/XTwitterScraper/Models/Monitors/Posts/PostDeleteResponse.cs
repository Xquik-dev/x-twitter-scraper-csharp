// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.Monitors.Posts;

[JsonConverter(typeof(JsonModelConverter<PostDeleteResponse, PostDeleteResponseFromRaw>))]
public sealed record class PostDeleteResponse : JsonModel
{
    public required ApiEnum<string, PostDeleteResponseDeletionStatus> DeletionStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PostDeleteResponseDeletionStatus>>(
                "deletionStatus"
            );
        }
        init { this._rawData.Set("deletionStatus", value); }
    }

    /// <summary>
    /// Poll this monitor URL until it returns 404.
    /// </summary>
    public required string StatusUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("statusUrl");
        }
        init { this._rawData.Set("statusUrl", value); }
    }

    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DeletionStatus.Validate();
        _ = this.StatusUrl;
        _ = this.Success;
    }

    public PostDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostDeleteResponse(PostDeleteResponse postDeleteResponse)
        : base(postDeleteResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PostDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PostDeleteResponseFromRaw.FromRawUnchecked"/>
    public static PostDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PostDeleteResponseFromRaw : IFromRawJson<PostDeleteResponse>
{
    /// <inheritdoc/>
    public PostDeleteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PostDeleteResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PostDeleteResponseDeletionStatusConverter))]
public enum PostDeleteResponseDeletionStatus
{
    Deleting,
}

sealed class PostDeleteResponseDeletionStatusConverter
    : JsonConverter<PostDeleteResponseDeletionStatus>
{
    public override PostDeleteResponseDeletionStatus Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deleting" => PostDeleteResponseDeletionStatus.Deleting,
            _ => (PostDeleteResponseDeletionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PostDeleteResponseDeletionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PostDeleteResponseDeletionStatus.Deleting => "deleting",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
