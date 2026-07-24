// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Subscribe;

namespace XTwitterScraper.Tests.Models.Subscribe;

public class SubscribeCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscribeCreateResponse
        {
            Message = "Billing session created",
            Status = Status.CheckoutCreated,
            Url = "https://xquik.com/billing/session",
        };

        string expectedMessage = "Billing session created";
        ApiEnum<string, Status> expectedStatus = Status.CheckoutCreated;
        string expectedUrl = "https://xquik.com/billing/session";

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscribeCreateResponse
        {
            Message = "Billing session created",
            Status = Status.CheckoutCreated,
            Url = "https://xquik.com/billing/session",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscribeCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscribeCreateResponse
        {
            Message = "Billing session created",
            Status = Status.CheckoutCreated,
            Url = "https://xquik.com/billing/session",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscribeCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "Billing session created";
        ApiEnum<string, Status> expectedStatus = Status.CheckoutCreated;
        string expectedUrl = "https://xquik.com/billing/session";

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscribeCreateResponse
        {
            Message = "Billing session created",
            Status = Status.CheckoutCreated,
            Url = "https://xquik.com/billing/session",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscribeCreateResponse
        {
            Message = "Billing session created",
            Status = Status.CheckoutCreated,
            Url = "https://xquik.com/billing/session",
        };

        SubscribeCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.CheckoutCreated)]
    [InlineData(Status.AlreadySubscribed)]
    [InlineData(Status.PaymentIssue)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.CheckoutCreated)]
    [InlineData(Status.AlreadySubscribed)]
    [InlineData(Status.PaymentIssue)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
