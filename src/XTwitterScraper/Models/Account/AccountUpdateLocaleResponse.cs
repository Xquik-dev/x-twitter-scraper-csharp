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
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.Account;

[JsonConverter(
    typeof(JsonModelConverter<AccountUpdateLocaleResponse, AccountUpdateLocaleResponseFromRaw>)
)]
public sealed record class AccountUpdateLocaleResponse : JsonModel
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

    /// <summary>
    /// Fields the request sent that this route does not read, in the order sent. They changed nothing. The answer leaves this out when the route read every field.
    /// </summary>
    public IReadOnlyList<string>? IgnoredFields
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("ignoredFields");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "ignoredFields",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(true)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        _ = this.IgnoredFields;
    }

    public AccountUpdateLocaleResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountUpdateLocaleResponse(AccountUpdateLocaleResponse accountUpdateLocaleResponse)
        : base(accountUpdateLocaleResponse) { }
#pragma warning restore CS8618

    public AccountUpdateLocaleResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountUpdateLocaleResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountUpdateLocaleResponseFromRaw.FromRawUnchecked"/>
    public static AccountUpdateLocaleResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountUpdateLocaleResponseFromRaw : IFromRawJson<AccountUpdateLocaleResponse>
{
    /// <inheritdoc/>
    public AccountUpdateLocaleResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountUpdateLocaleResponse.FromRawUnchecked(rawData);
}
