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

namespace XTwitterScraper.Models.X;

[JsonConverter(typeof(JsonModelConverter<XGetHashflagsResponse, XGetHashflagsResponseFromRaw>))]
public sealed record class XGetHashflagsResponse : JsonModel
{
    public required IReadOnlyList<global::XTwitterScraper.Models.Hashflag> Hashflags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.Hashflag>
            >("hashflags");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.Hashflag>>(
                "hashflags",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Hashflags returned &amp; charged.
    /// </summary>
    public required long Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    /// <summary>
    /// Hashflags that match the filters, before limit.
    /// </summary>
    public required long Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    /// <summary>
    /// What to send instead. Present only when no hashflag matches.
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Hashflags)
        {
            item.Validate();
        }
        _ = this.Count;
        _ = this.Total;
        _ = this.Message;
    }

    public XGetHashflagsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XGetHashflagsResponse(XGetHashflagsResponse xGetHashflagsResponse)
        : base(xGetHashflagsResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public XGetHashflagsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    XGetHashflagsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="XGetHashflagsResponseFromRaw.FromRawUnchecked"/>
    public static XGetHashflagsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class XGetHashflagsResponseFromRaw : IFromRawJson<XGetHashflagsResponse>
{
    /// <inheritdoc/>
    public XGetHashflagsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => XGetHashflagsResponse.FromRawUnchecked(rawData);
}
