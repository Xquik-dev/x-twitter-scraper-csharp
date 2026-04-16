using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Account;

namespace XTwitterScraper.Tests.Models.Account;

public class AccountUpdateLocaleParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountUpdateLocaleParams { Locale = Locale.En };

        ApiEnum<string, Locale> expectedLocale = Locale.En;

        Assert.Equal(expectedLocale, parameters.Locale);
    }

    [Fact]
    public void Url_Works()
    {
        AccountUpdateLocaleParams parameters = new() { Locale = Locale.En };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/account"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountUpdateLocaleParams { Locale = Locale.En };

        AccountUpdateLocaleParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class LocaleTest : TestBase
{
    [Theory]
    [InlineData(Locale.En)]
    [InlineData(Locale.Tr)]
    [InlineData(Locale.Es)]
    public void Validation_Works(Locale rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Locale> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Locale>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Locale.En)]
    [InlineData(Locale.Tr)]
    [InlineData(Locale.Es)]
    public void SerializationRoundtrip_Works(Locale rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Locale> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Locale>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Locale>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Locale>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
