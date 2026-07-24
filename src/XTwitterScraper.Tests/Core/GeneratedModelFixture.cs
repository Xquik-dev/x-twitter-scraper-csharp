// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using XTwitterScraper.Core;

namespace XTwitterScraper.Tests.Core;

static class GeneratedModelFixture
{
    static readonly object UnsupportedValue = new();

    static readonly Assembly SdkAssembly = typeof(XTwitterScraperClient).Assembly;

    static readonly IReadOnlyDictionary<string, JsonElement> EmptyRawData =
        new Dictionary<string, JsonElement>();

    public static TheoryData<Type> JsonModelTypes()
    {
        return TypesWhere(type => typeof(JsonModel).IsAssignableFrom(type));
    }

    public static TheoryData<Type> ParamsTypes()
    {
        return TypesWhere(type => typeof(ParamsBase).IsAssignableFrom(type));
    }

    public static MethodInfo? FindRawFactory(Type type)
    {
        return type.GetMethods(BindingFlags.Public | BindingFlags.Static)
            .SingleOrDefault(method =>
                method.Name == "FromRawUnchecked" && method.ReturnType == type
            );
    }

    public static ConstructorInfo? FindRawConstructor(Type type)
    {
        return type.GetConstructors()
            .SingleOrDefault(constructor =>
                constructor
                    .GetParameters()
                    .Any(parameter => IsRawParameter(parameter.ParameterType))
            );
    }

    public static object[] CreateArguments(IReadOnlyList<ParameterInfo> parameters)
    {
        return
        [
            .. parameters.Select(parameter =>
            {
                var value = CreateValue(parameter.ParameterType);
                if (ReferenceEquals(value, UnsupportedValue))
                {
                    throw new InvalidOperationException(
                        $"No test value is available for {parameter.ParameterType}."
                    );
                }
                return value;
            }),
        ];
    }

    public static Dictionary<PropertyInfo, object> AssignPublicProperties(object instance)
    {
        var assigned = new Dictionary<PropertyInfo, object>();
        foreach (
            var property in instance
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(property =>
                    property.SetMethod != null
                    && property.SetMethod.IsPublic
                    && property.GetIndexParameters().Length == 0
                )
        )
        {
            var value = CreateValue(property.PropertyType);
            if (ReferenceEquals(value, UnsupportedValue))
            {
                continue;
            }

            property.SetValue(instance, value);
            assigned[property] = value;
        }

        return assigned;
    }

    static TheoryData<Type> TypesWhere(Func<Type, bool> predicate)
    {
        TheoryData<Type> types = [];
        foreach (
            var type in SdkAssembly
                .GetTypes()
                .Where(type =>
                    type.IsClass
                    && !type.IsAbstract
                    && predicate(type)
                    && FindRawFactory(type) != null
                )
                .OrderBy(type => type.FullName, StringComparer.Ordinal)
        )
        {
            types.Add(type);
        }
        return types;
    }

    static bool IsRawParameter(Type type)
    {
        if (type == typeof(JsonElement))
        {
            return true;
        }
        if (!type.IsGenericType)
        {
            return false;
        }

        var genericType = type.GetGenericTypeDefinition();
        return genericType == typeof(Dictionary<,>)
            || genericType == typeof(IDictionary<,>)
            || genericType == typeof(IReadOnlyDictionary<,>);
    }

    static object CreateValue(Type type)
    {
        var nullableType = Nullable.GetUnderlyingType(type);
        if (nullableType != null)
        {
            return CreateValue(nullableType);
        }
        if (type == typeof(string))
        {
            return "value";
        }
        if (type == typeof(bool))
        {
            return true;
        }
        if (type == typeof(byte))
        {
            return (byte)1;
        }
        if (type == typeof(short))
        {
            return (short)1;
        }
        if (type == typeof(int))
        {
            return 1;
        }
        if (type == typeof(long))
        {
            return 1L;
        }
        if (type == typeof(float))
        {
            return 1F;
        }
        if (type == typeof(double))
        {
            return 1D;
        }
        if (type == typeof(decimal))
        {
            return 1M;
        }
        if (type == typeof(DateTime))
        {
            return new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        }
        if (type == typeof(DateTimeOffset))
        {
            return new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);
        }
        if (type == typeof(TimeSpan))
        {
            return TimeSpan.FromSeconds(1);
        }
        if (type == typeof(Guid))
        {
            return Guid.Parse("11111111-1111-1111-1111-111111111111");
        }
        if (type == typeof(Uri))
        {
            return new Uri("https://example.test/value");
        }
        if (type == typeof(JsonElement))
        {
            return JsonSerializer.SerializeToElement("value");
        }
        if (type == typeof(byte[]))
        {
            return new byte[] { 1 };
        }
        if (type == typeof(Stream))
        {
            return new MemoryStream([1]);
        }
        if (type == typeof(BinaryContent))
        {
            return new BinaryContent { Stream = new MemoryStream([1]) };
        }
        if (type == typeof(object))
        {
            return "value";
        }
        if (type.IsEnum)
        {
            return Enum.GetValues(type).GetValue(0) ?? UnsupportedValue;
        }
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ApiEnum<,>))
        {
            var enumType = type.GetGenericArguments()[1];
            var enumValue = Enum.GetValues(enumType).GetValue(0);
            var element = JsonSerializer.SerializeToElement(
                enumValue,
                enumType,
                ModelBase.SerializerOptions
            );
            return Activator.CreateInstance(type, element) ?? UnsupportedValue;
        }
        if (type.IsArray)
        {
            return Array.CreateInstance(type.GetElementType()!, 0);
        }
        if (type.IsGenericType)
        {
            var genericType = type.GetGenericTypeDefinition();
            var arguments = type.GetGenericArguments();
            if (
                genericType == typeof(Dictionary<,>)
                || genericType == typeof(IDictionary<,>)
                || genericType == typeof(IReadOnlyDictionary<,>)
            )
            {
                return Activator.CreateInstance(typeof(Dictionary<,>).MakeGenericType(arguments))
                    ?? UnsupportedValue;
            }
            if (
                genericType == typeof(List<>)
                || genericType == typeof(IList<>)
                || genericType == typeof(ICollection<>)
                || genericType == typeof(IEnumerable<>)
                || genericType == typeof(IReadOnlyCollection<>)
                || genericType == typeof(IReadOnlyList<>)
            )
            {
                return Activator.CreateInstance(typeof(List<>).MakeGenericType(arguments))
                    ?? UnsupportedValue;
            }
        }
        if (typeof(JsonModel).IsAssignableFrom(type))
        {
            var factory = FindRawFactory(type);
            return factory?.Invoke(null, [EmptyRawData]) ?? UnsupportedValue;
        }
        if (typeof(ModelBase).IsAssignableFrom(type) && !type.IsAbstract)
        {
            foreach (
                var constructor in type.GetConstructors()
                    .OrderBy(constructor => constructor.GetParameters().Length)
            )
            {
                var arguments = new List<object>();
                var supported = true;
                foreach (var parameter in constructor.GetParameters())
                {
                    if (parameter.ParameterType == type)
                    {
                        supported = false;
                        break;
                    }

                    var value = CreateValue(parameter.ParameterType);
                    if (ReferenceEquals(value, UnsupportedValue))
                    {
                        supported = false;
                        break;
                    }
                    arguments.Add(value);
                }
                if (supported)
                {
                    return constructor.Invoke([.. arguments]);
                }
            }
        }
        if (!type.IsAbstract && type.GetConstructor(Type.EmptyTypes) != null)
        {
            return Activator.CreateInstance(type) ?? UnsupportedValue;
        }

        return UnsupportedValue;
    }
}
