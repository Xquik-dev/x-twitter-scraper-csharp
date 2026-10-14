// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Core;

sealed class WrappedMultipartJsonSerializer
{
    public static T GetNotNullClass<T>(MultipartJsonElement element, string name)
        where T : class
    {
        T deserialized;
        try
        {
            deserialized =
                MultipartJsonSerializer.Deserialize<T>(element, ModelBase.SerializerOptions)
                ?? throw new XTwitterScraperInvalidDataException($"'{name}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new XTwitterScraperInvalidDataException(
                $"'{name}' must be of type {typeof(T).FullName}",
                e
            );
        }
        return deserialized;
    }

    public static T GetNotNullStruct<T>(MultipartJsonElement element, string name)
        where T : struct
    {
        T deserialized;
        try
        {
            deserialized =
                MultipartJsonSerializer.Deserialize<T?>(element, ModelBase.SerializerOptions)
                ?? throw new XTwitterScraperInvalidDataException($"'{name}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new XTwitterScraperInvalidDataException(
                $"'{name}' must be of type {typeof(T).FullName}",
                e
            );
        }
        return deserialized;
    }

    public static T? GetNullableClass<T>(MultipartJsonElement element, string name)
        where T : class
    {
        T? deserialized;
        try
        {
            deserialized = MultipartJsonSerializer.Deserialize<T?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        catch (JsonException e)
        {
            throw new XTwitterScraperInvalidDataException(
                $"'{name}' must be of type {typeof(T).FullName}",
                e
            );
        }
        return deserialized;
    }

    public static T? GetNullableStruct<T>(MultipartJsonElement element, string name)
        where T : struct
    {
        T? deserialized;
        try
        {
            deserialized = MultipartJsonSerializer.Deserialize<T?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        catch (JsonException e)
        {
            throw new XTwitterScraperInvalidDataException(
                $"'{name}' must be of type {typeof(T).FullName}",
                e
            );
        }
        return deserialized;
    }
}
