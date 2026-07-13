using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Extractions;

namespace XTwitterScraper.Tests.Models.Extractions;

public class ExtractionEstimateCostResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractionEstimateCostResponse
        {
            Allowed = true,
            CreditsAvailable = "50000",
            CreditsRequired = "500",
            EstimatedResults = 500,
            Source = Source.ReplyCount,
            ResolvedXUserID = "123456",
        };

        bool expectedAllowed = true;
        string expectedCreditsAvailable = "50000";
        string expectedCreditsRequired = "500";
        long expectedEstimatedResults = 500;
        ApiEnum<string, Source> expectedSource = Source.ReplyCount;
        string expectedResolvedXUserID = "123456";

        Assert.Equal(expectedAllowed, model.Allowed);
        Assert.Equal(expectedCreditsAvailable, model.CreditsAvailable);
        Assert.Equal(expectedCreditsRequired, model.CreditsRequired);
        Assert.Equal(expectedEstimatedResults, model.EstimatedResults);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedResolvedXUserID, model.ResolvedXUserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtractionEstimateCostResponse
        {
            Allowed = true,
            CreditsAvailable = "50000",
            CreditsRequired = "500",
            EstimatedResults = 500,
            Source = Source.ReplyCount,
            ResolvedXUserID = "123456",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractionEstimateCostResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractionEstimateCostResponse
        {
            Allowed = true,
            CreditsAvailable = "50000",
            CreditsRequired = "500",
            EstimatedResults = 500,
            Source = Source.ReplyCount,
            ResolvedXUserID = "123456",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractionEstimateCostResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAllowed = true;
        string expectedCreditsAvailable = "50000";
        string expectedCreditsRequired = "500";
        long expectedEstimatedResults = 500;
        ApiEnum<string, Source> expectedSource = Source.ReplyCount;
        string expectedResolvedXUserID = "123456";

        Assert.Equal(expectedAllowed, deserialized.Allowed);
        Assert.Equal(expectedCreditsAvailable, deserialized.CreditsAvailable);
        Assert.Equal(expectedCreditsRequired, deserialized.CreditsRequired);
        Assert.Equal(expectedEstimatedResults, deserialized.EstimatedResults);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedResolvedXUserID, deserialized.ResolvedXUserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtractionEstimateCostResponse
        {
            Allowed = true,
            CreditsAvailable = "50000",
            CreditsRequired = "500",
            EstimatedResults = 500,
            Source = Source.ReplyCount,
            ResolvedXUserID = "123456",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtractionEstimateCostResponse
        {
            Allowed = true,
            CreditsAvailable = "50000",
            CreditsRequired = "500",
            EstimatedResults = 500,
            Source = Source.ReplyCount,
        };

        Assert.Null(model.ResolvedXUserID);
        Assert.False(model.RawData.ContainsKey("resolvedXUserId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtractionEstimateCostResponse
        {
            Allowed = true,
            CreditsAvailable = "50000",
            CreditsRequired = "500",
            EstimatedResults = 500,
            Source = Source.ReplyCount,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExtractionEstimateCostResponse
        {
            Allowed = true,
            CreditsAvailable = "50000",
            CreditsRequired = "500",
            EstimatedResults = 500,
            Source = Source.ReplyCount,

            // Null should be interpreted as omitted for these properties
            ResolvedXUserID = null,
        };

        Assert.Null(model.ResolvedXUserID);
        Assert.False(model.RawData.ContainsKey("resolvedXUserId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtractionEstimateCostResponse
        {
            Allowed = true,
            CreditsAvailable = "50000",
            CreditsRequired = "500",
            EstimatedResults = 500,
            Source = Source.ReplyCount,

            // Null should be interpreted as omitted for these properties
            ResolvedXUserID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractionEstimateCostResponse
        {
            Allowed = true,
            CreditsAvailable = "50000",
            CreditsRequired = "500",
            EstimatedResults = 500,
            Source = Source.ReplyCount,
            ResolvedXUserID = "123456",
        };

        ExtractionEstimateCostResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SourceTest : TestBase
{
    [Theory]
    [InlineData(Source.Followers)]
    [InlineData(Source.Following)]
    [InlineData(Source.PaginationCap)]
    [InlineData(Source.Posts)]
    [InlineData(Source.QuoteCount)]
    [InlineData(Source.ReplyCount)]
    [InlineData(Source.ResultsLimit)]
    [InlineData(Source.RetweetCount)]
    [InlineData(Source.Unknown)]
    public void Validation_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Source.Followers)]
    [InlineData(Source.Following)]
    [InlineData(Source.PaginationCap)]
    [InlineData(Source.Posts)]
    [InlineData(Source.QuoteCount)]
    [InlineData(Source.ReplyCount)]
    [InlineData(Source.ResultsLimit)]
    [InlineData(Source.RetweetCount)]
    [InlineData(Source.Unknown)]
    public void SerializationRoundtrip_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
