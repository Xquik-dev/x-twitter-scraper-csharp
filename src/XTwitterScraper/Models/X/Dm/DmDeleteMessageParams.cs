// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Dm;

/// <summary>
/// Deletes 1 DM from the account's side. The other person keeps it. Success means the DM is gone from the account's conversation. A DM that stays gets 422 `x_dm_not_deleted`, and Xquik charges nothing.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public record class DmDeleteMessageParams : ParamsBase
{
    public required string UserID { get; init; }

    public string? MessageID { get; init; }

    /// <summary>
    /// Connected X account (@username or ID) that sees the DM.
    /// </summary>
    public required string Account
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>("account");
        }
        init { this._rawQueryData.Set("account", value); }
    }

    public DmDeleteMessageParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DmDeleteMessageParams(DmDeleteMessageParams dmDeleteMessageParams)
        : base(dmDeleteMessageParams)
    {
        this.UserID = dmDeleteMessageParams.UserID;
        this.MessageID = dmDeleteMessageParams.MessageID;
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DmDeleteMessageParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DmDeleteMessageParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string userID,
        string messageID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.UserID = userID;
        this.MessageID = messageID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DmDeleteMessageParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string userID,
        string messageID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            userID,
            messageID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["UserID"] = JsonSerializer.SerializeToElement(this.UserID),
                    ["MessageID"] = JsonSerializer.SerializeToElement(this.MessageID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(DmDeleteMessageParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.UserID?.Equals(other.UserID) ?? other.UserID == null)
            && (this.MessageID?.Equals(other.MessageID) ?? other.MessageID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/x/dm/{0}/messages/{1}", this.UserID, this.MessageID)
        )
        {
            Query = this.QueryString(options, SecurityOptions.All()),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options, SecurityOptions.All());
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
