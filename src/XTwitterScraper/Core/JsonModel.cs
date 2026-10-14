// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using System.Text.Json;

namespace XTwitterScraper.Core;

/// <summary>
/// The base class for all API objects that are serialized as JSON objects.
///
/// <para>API objects such as enums and unions do not inherit from this class.</para>
/// </summary>
public abstract record class JsonModel : ModelBase
{
    private protected JsonDictionary _rawData = new();

    /// <summary>
    /// The backing JSON properties of the instance.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement> RawData
    {
        get { return this._rawData.Freeze(); }
    }

    protected JsonModel(JsonModel jsonModel)
        : base(jsonModel)
    {
        this._rawData = new(jsonModel._rawData);
    }

    public sealed override string ToString() => this._rawData.ToString();

    public virtual bool Equals(JsonModel? other)
    {
        if (other == null)
        {
            return false;
        }

        return this._rawData.Equals(other._rawData);
    }

    public override int GetHashCode() => this._rawData.GetHashCode();
}

/// <summary>
/// <para>NOTE: This interface is in the style of a factory instance instead of using
/// abstract static methods because .NET Standard 2.0 doesn't support abstract static methods.</para>
/// </summary>
/// <seealso href="https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.runtimefeature.virtualstaticsininterfaces"/>
interface IFromRawJson<T>
{
    /// <summary>
    /// Returns an instance constructed from the given raw JSON properties.
    ///
    /// <para>Required field and type mismatches are not checked. In these cases accessing
    /// the relevant properties of the constructed instance may throw.</para>
    /// </summary>
    T FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData);
}
