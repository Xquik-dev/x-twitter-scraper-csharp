// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using XTwitterScraper.Core;

namespace XTwitterScraper.Tests.Core;

public class GeneratedModelContractTest
{
    public static TheoryData<Type> JsonModelTypes() => GeneratedModelFixture.JsonModelTypes();

    public static TheoryData<Type> ParamsTypes() => GeneratedModelFixture.ParamsTypes();

    [Theory]
    [MemberData(nameof(JsonModelTypes))]
    public void JsonModelPropertiesRoundTrip(Type modelType)
    {
        var model = Assert.IsType<JsonModel>(
            Activator.CreateInstance(modelType),
            exactMatch: false
        );
        var assigned = GeneratedModelFixture.AssignPublicProperties(model);

        Assert.Equal(modelType, model.GetType());
        Assert.Equal(assigned.Count, assigned.Count(item => item.Key.GetValue(model) != null));
        Assert.True(model.RawData.Count >= assigned.Count);
        Assert.Contains("{", model.ToString(), StringComparison.Ordinal);

        var copyConstructor = modelType.GetConstructor([modelType]);
        if (copyConstructor != null)
        {
            var copy = Assert.IsType<JsonModel>(copyConstructor.Invoke([model]), exactMatch: false);
            Assert.Equal(model, copy);
        }
    }

    [Theory]
    [MemberData(nameof(JsonModelTypes))]
    public void JsonModelRawLifecycleWorks(Type modelType)
    {
        var factory = Assert.IsType<MethodInfo>(
            GeneratedModelFixture.FindRawFactory(modelType),
            exactMatch: false
        );
        var model = Assert.IsType<JsonModel>(
            factory.Invoke(null, GeneratedModelFixture.CreateArguments(factory.GetParameters())),
            exactMatch: false
        );

        Assert.Equal(modelType, model.GetType());
        Assert.Empty(model.RawData);
        Assert.Contains("{", model.ToString(), StringComparison.Ordinal);
        Assert.Equal(model.GetHashCode(), model.GetHashCode());
        Assert.True(model.Equals(model));
        Assert.False(model.Equals(null));

        var rawConstructor = GeneratedModelFixture.FindRawConstructor(modelType);
        if (rawConstructor != null)
        {
            var fromConstructor = Assert.IsType<JsonModel>(
                rawConstructor.Invoke(
                    GeneratedModelFixture.CreateArguments(rawConstructor.GetParameters())
                ),
                exactMatch: false
            );
            Assert.Equal(modelType, fromConstructor.GetType());
            Assert.Contains("{", fromConstructor.ToString(), StringComparison.Ordinal);
            Assert.True(fromConstructor.Equals(fromConstructor));
        }

        var copyConstructor = modelType.GetConstructor([modelType]);
        if (copyConstructor != null)
        {
            var copy = Assert.IsType<JsonModel>(copyConstructor.Invoke([model]), exactMatch: false);
            Assert.Equal(model, copy);
        }
    }

    [Theory]
    [MemberData(nameof(ParamsTypes))]
    public void ParamsPropertiesRoundTrip(Type paramsType)
    {
        var parameters = Assert.IsType<ParamsBase>(
            Activator.CreateInstance(paramsType),
            exactMatch: false
        );
        var assigned = GeneratedModelFixture.AssignPublicProperties(parameters);
        ClientOptions options = new()
        {
            BaseUrl = "https://example.test",
            ApiKey = "test-api-key",
            BearerToken = "test-bearer-token",
        };
        using var optionsHttpClient = options.HttpClient;
        using var request = new HttpRequestMessage();

        Assert.Equal(paramsType, parameters.GetType());
        Assert.Equal(assigned.Count, assigned.Count(item => item.Key.GetValue(parameters) != null));
        Assert.True(parameters.Url(options).IsAbsoluteUri);
        parameters.AddHeadersToRequest(request, options);
        Assert.True(request.Headers.Contains("X-Stainless-Lang"));
        using var content = parameters.BodyContent();

        var copyConstructor = paramsType.GetConstructor([paramsType]);
        if (copyConstructor != null)
        {
            var copy = Assert.IsType<ParamsBase>(
                copyConstructor.Invoke([parameters]),
                exactMatch: false
            );
            Assert.Equal(parameters, copy);
        }
    }

    [Theory]
    [MemberData(nameof(ParamsTypes))]
    public void ParamsRawLifecycleWorks(Type paramsType)
    {
        var factory = Assert.IsType<MethodInfo>(
            GeneratedModelFixture.FindRawFactory(paramsType),
            exactMatch: false
        );
        var parameters = Assert.IsType<ParamsBase>(
            factory.Invoke(null, GeneratedModelFixture.CreateArguments(factory.GetParameters())),
            exactMatch: false
        );
        ClientOptions options = new()
        {
            BaseUrl = "https://example.test",
            ApiKey = "test-api-key",
            BearerToken = "test-bearer-token",
        };
        using var optionsHttpClient = options.HttpClient;
        using var request = new HttpRequestMessage();

        Assert.Equal(paramsType, parameters.GetType());
        Assert.Empty(parameters.RawHeaderData);
        Assert.Empty(parameters.RawQueryData);
        Assert.Contains("{", parameters.ToString(), StringComparison.Ordinal);
        Assert.Equal(parameters.GetHashCode(), parameters.GetHashCode());
        Assert.True(parameters.Equals(parameters));
        Assert.False(parameters.Equals(null));
        Assert.True(parameters.Url(options).IsAbsoluteUri);
        parameters.AddHeadersToRequest(request, options);
        Assert.True(request.Headers.Contains("X-Stainless-Lang"));
        var bodyCanRetry = parameters.BodyCanRetry();
        Assert.Equal(bodyCanRetry, parameters.BodyCanRetry());

        var rawConstructor = GeneratedModelFixture.FindRawConstructor(paramsType);
        if (rawConstructor != null)
        {
            var fromConstructor = Assert.IsType<ParamsBase>(
                rawConstructor.Invoke(
                    GeneratedModelFixture.CreateArguments(rawConstructor.GetParameters())
                ),
                exactMatch: false
            );
            Assert.Equal(paramsType, fromConstructor.GetType());
            Assert.Contains("{", fromConstructor.ToString(), StringComparison.Ordinal);
            Assert.True(fromConstructor.Equals(fromConstructor));
        }

        var copyConstructor = paramsType.GetConstructor([paramsType]);
        if (copyConstructor != null)
        {
            var copy = Assert.IsType<ParamsBase>(
                copyConstructor.Invoke([parameters]),
                exactMatch: false
            );
            Assert.Equal(parameters, copy);
        }
    }
}
