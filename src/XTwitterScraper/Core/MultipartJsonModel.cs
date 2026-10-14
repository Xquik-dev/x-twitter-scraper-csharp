// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;

namespace XTwitterScraper.Core;

/// <summary>
/// The base class for all API objects that are serialized as a mix of JSON objects
/// and binary content.
///
/// <para>API objects such as enums and unions do not inherit from this class.</para>
/// </summary>
public abstract record class MultipartJsonModel : ModelBase
{
    private protected MultipartJsonDictionary _rawData = new();

    protected MultipartJsonModel(MultipartJsonModel jsonModel)
        : base(jsonModel)
    {
        this._rawData = new(jsonModel._rawData);
    }

    /// <summary>
    /// The backing mix of JSON and binary content properties of the instance.
    /// </summary>
    public IReadOnlyDictionary<string, MultipartJsonElement> RawData
    {
        get { return this._rawData.Freeze(); }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// <para>NOTE: This interface is in the style of a factory instance instead of using
/// abstract static methods because .NET Standard 2.0 doesn't support abstract static methods.</para>
/// </summary>
/// <seealso href="https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.runtimefeature.virtualstaticsininterfaces"/>
interface IFromRawMultipartJson<T>
{
    T FromRawUnchecked(IReadOnlyDictionary<string, MultipartJsonElement> rawData);
}
