using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Extractions;

namespace XTwitterScraper.Tests.Models.Extractions;

public class ExtractionExportResultsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExtractionExportResultsParams { ID = "id", Format = Format.Csv };

        string expectedID = "id";
        ApiEnum<string, Format> expectedFormat = Format.Csv;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedFormat, parameters.Format);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExtractionExportResultsParams { ID = "id" };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExtractionExportResultsParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Format = null,
        };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
    }

    [Fact]
    public void Url_Works()
    {
        ExtractionExportResultsParams parameters = new() { ID = "id", Format = Format.Csv };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://xquik.com/api/v1/extractions/id/export?format=csv"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExtractionExportResultsParams { ID = "id", Format = Format.Csv };

        ExtractionExportResultsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FormatTest : TestBase
{
    [Theory]
    [InlineData(Format.Csv)]
    [InlineData(Format.Json)]
    [InlineData(Format.Md)]
    [InlineData(Format.MdDocument)]
    [InlineData(Format.Pdf)]
    [InlineData(Format.Txt)]
    [InlineData(Format.Xlsx)]
    public void Validation_Works(Format rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Format> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Format>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Format.Csv)]
    [InlineData(Format.Json)]
    [InlineData(Format.Md)]
    [InlineData(Format.MdDocument)]
    [InlineData(Format.Pdf)]
    [InlineData(Format.Txt)]
    [InlineData(Format.Xlsx)]
    public void SerializationRoundtrip_Works(Format rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Format> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Format>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Format>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Format>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
