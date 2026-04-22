using System.Text.Json;
using XTwitterScraper.Core;
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
            Source = "replyCount",
            ResolvedXUserID = "123456",
        };

        bool expectedAllowed = true;
        string expectedCreditsAvailable = "50000";
        string expectedCreditsRequired = "500";
        long expectedEstimatedResults = 500;
        string expectedSource = "replyCount";
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
            Source = "replyCount",
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
            Source = "replyCount",
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
        string expectedSource = "replyCount";
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
            Source = "replyCount",
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
            Source = "replyCount",
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
            Source = "replyCount",
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
            Source = "replyCount",

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
            Source = "replyCount",

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
            Source = "replyCount",
            ResolvedXUserID = "123456",
        };

        ExtractionEstimateCostResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
