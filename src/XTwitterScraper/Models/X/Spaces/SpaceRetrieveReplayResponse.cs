// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Spaces;

[JsonConverter(
    typeof(JsonModelConverter<SpaceRetrieveReplayResponse, SpaceRetrieveReplayResponseFromRaw>)
)]
public sealed record class SpaceRetrieveReplayResponse : JsonModel
{
    /// <summary>
    /// Recording of an ended Space
    /// </summary>
    public required SpaceRetrieveReplayResponseReplay Replay
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SpaceRetrieveReplayResponseReplay>("replay");
        }
        init { this._rawData.Set("replay", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Replay.Validate();
    }

    public SpaceRetrieveReplayResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpaceRetrieveReplayResponse(SpaceRetrieveReplayResponse spaceRetrieveReplayResponse)
        : base(spaceRetrieveReplayResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpaceRetrieveReplayResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpaceRetrieveReplayResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpaceRetrieveReplayResponseFromRaw.FromRawUnchecked"/>
    public static SpaceRetrieveReplayResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpaceRetrieveReplayResponseFromRaw : IFromRawJson<SpaceRetrieveReplayResponse>
{
    /// <inheritdoc/>
    public SpaceRetrieveReplayResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SpaceRetrieveReplayResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SpaceRetrieveReplayResponseReplay,
        SpaceRetrieveReplayResponseReplayFromRaw
    >)
)]
public sealed record class SpaceRetrieveReplayResponseReplay : JsonModel
{
    /// <summary>
    /// HLS playlist of the recording
    /// </summary>
    public required string UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// Stream format, as X names it
    /// </summary>
    public string? StreamType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("streamType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("streamType", value);
        }
    }

    /// <summary>
    /// Stream status, as X names it
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UrlValue;
        _ = this.StreamType;
        _ = this.Status;
    }

    public SpaceRetrieveReplayResponseReplay() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpaceRetrieveReplayResponseReplay(
        SpaceRetrieveReplayResponseReplay spaceRetrieveReplayResponseReplay
    )
        : base(spaceRetrieveReplayResponseReplay) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpaceRetrieveReplayResponseReplay(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpaceRetrieveReplayResponseReplay(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpaceRetrieveReplayResponseReplayFromRaw.FromRawUnchecked"/>
    public static SpaceRetrieveReplayResponseReplay FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpaceRetrieveReplayResponseReplayFromRaw : IFromRawJson<SpaceRetrieveReplayResponseReplay>
{
    /// <inheritdoc/>
    public SpaceRetrieveReplayResponseReplay FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SpaceRetrieveReplayResponseReplay.FromRawUnchecked(rawData);
}
