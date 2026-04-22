using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using Draws = XTwitterScraper.Models.Draws;

namespace XTwitterScraper.Tests.Models.Draws;

public class DrawExportParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Draws::DrawExportParams
        {
            ID = "id",
            Format = Draws::Format.Csv,
            Type = Draws::Type.Winners,
        };

        string expectedID = "id";
        ApiEnum<string, Draws::Format> expectedFormat = Draws::Format.Csv;
        ApiEnum<string, Draws::Type> expectedType = Draws::Type.Winners;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedFormat, parameters.Format);
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Draws::DrawExportParams { ID = "id" };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Draws::DrawExportParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Format = null,
            Type = null,
        };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        Draws::DrawExportParams parameters = new()
        {
            ID = "id",
            Format = Draws::Format.Csv,
            Type = Draws::Type.Winners,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://xquik.com/api/v1/draws/id/export?format=csv&type=winners"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Draws::DrawExportParams
        {
            ID = "id",
            Format = Draws::Format.Csv,
            Type = Draws::Type.Winners,
        };

        Draws::DrawExportParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FormatTest : TestBase
{
    [Theory]
    [InlineData(Draws::Format.Csv)]
    [InlineData(Draws::Format.Json)]
    [InlineData(Draws::Format.Md)]
    [InlineData(Draws::Format.MdDocument)]
    [InlineData(Draws::Format.Pdf)]
    [InlineData(Draws::Format.Txt)]
    [InlineData(Draws::Format.Xlsx)]
    public void Validation_Works(Draws::Format rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Draws::Format> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Draws::Format>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Draws::Format.Csv)]
    [InlineData(Draws::Format.Json)]
    [InlineData(Draws::Format.Md)]
    [InlineData(Draws::Format.MdDocument)]
    [InlineData(Draws::Format.Pdf)]
    [InlineData(Draws::Format.Txt)]
    [InlineData(Draws::Format.Xlsx)]
    public void SerializationRoundtrip_Works(Draws::Format rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Draws::Format> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Draws::Format>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Draws::Format>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Draws::Format>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Draws::Type.Winners)]
    [InlineData(Draws::Type.Entries)]
    public void Validation_Works(Draws::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Draws::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Draws::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Draws::Type.Winners)]
    [InlineData(Draws::Type.Entries)]
    public void SerializationRoundtrip_Works(Draws::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Draws::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Draws::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Draws::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Draws::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
