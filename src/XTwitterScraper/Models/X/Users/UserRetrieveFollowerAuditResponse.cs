// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Users;

[JsonConverter(
    typeof(JsonModelConverter<
        UserRetrieveFollowerAuditResponse,
        UserRetrieveFollowerAuditResponseFromRaw
    >)
)]
public sealed record class UserRetrieveFollowerAuditResponse : JsonModel
{
    /// <summary>
    /// Report on the followers read. Classes rest on public profile signals, so they say what a profile looks like, never who runs it.
    /// </summary>
    public required global::XTwitterScraper.Models.FollowerAudit Audit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.FollowerAudit>(
                "audit"
            );
        }
        init { this._rawData.Set("audit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Audit.Validate();
    }

    public UserRetrieveFollowerAuditResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserRetrieveFollowerAuditResponse(
        UserRetrieveFollowerAuditResponse userRetrieveFollowerAuditResponse
    )
        : base(userRetrieveFollowerAuditResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserRetrieveFollowerAuditResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRetrieveFollowerAuditResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserRetrieveFollowerAuditResponseFromRaw.FromRawUnchecked"/>
    public static UserRetrieveFollowerAuditResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserRetrieveFollowerAuditResponseFromRaw : IFromRawJson<UserRetrieveFollowerAuditResponse>
{
    /// <inheritdoc/>
    public UserRetrieveFollowerAuditResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserRetrieveFollowerAuditResponse.FromRawUnchecked(rawData);
}
