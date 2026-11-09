// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(JsonModelConverter<TweetEdit, TweetEditFromRaw>))]
public sealed record class TweetEdit : JsonModel
{
    public IReadOnlyList<string>? EditTweetIDs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("editTweetIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "editTweetIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? EditableUntilMsecs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("editableUntilMsecs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("editableUntilMsecs", value);
        }
    }

    public string? InitialTweetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("initialTweetId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("initialTweetId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EditTweetIDs;
        _ = this.EditableUntilMsecs;
        _ = this.InitialTweetID;
    }

    public TweetEdit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetEdit(TweetEdit tweetEdit)
        : base(tweetEdit) { }
#pragma warning restore CS8618

    public TweetEdit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetEdit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetEditFromRaw.FromRawUnchecked"/>
    public static TweetEdit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetEditFromRaw : IFromRawJson<TweetEdit>
{
    /// <inheritdoc/>
    public TweetEdit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetEdit.FromRawUnchecked(rawData);
}
