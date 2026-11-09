// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(JsonModelConverter<UserLiveStatus, UserLiveStatusFromRaw>))]
public sealed record class UserLiveStatus : JsonModel
{
    /// <summary>
    /// True while the user's latest broadcast is running.
    /// </summary>
    public required bool Live
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("live");
        }
        init { this._rawData.Set("live", value); }
    }

    /// <summary>
    /// Latest broadcast, live or ended. Null when X shows none. Holds only its ID &amp; state when X can't read it in full.
    /// </summary>
    public required global::XTwitterScraper.Models.Broadcast? Broadcast
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.Broadcast>(
                "broadcast"
            );
        }
        init { this._rawData.Set("broadcast", value); }
    }

    /// <summary>
    /// ID of the user.
    /// </summary>
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("userId");
        }
        init { this._rawData.Set("userId", value); }
    }

    /// <summary>
    /// Username of the user.
    /// </summary>
    public required string UserName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("userName");
        }
        init { this._rawData.Set("userName", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Live;
        this.Broadcast?.Validate();
        _ = this.UserID;
        _ = this.UserName;
    }

    public UserLiveStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserLiveStatus(UserLiveStatus userLiveStatus)
        : base(userLiveStatus) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserLiveStatus(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserLiveStatus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserLiveStatusFromRaw.FromRawUnchecked"/>
    public static UserLiveStatus FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserLiveStatusFromRaw : IFromRawJson<UserLiveStatus>
{
    /// <inheritdoc/>
    public UserLiveStatus FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserLiveStatus.FromRawUnchecked(rawData);
}
