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
            EstimatedResults = 500,
            ProjectedPercent = 30,
            Source = "api_count",
            UsagePercent = 25,
        };

        bool expectedAllowed = true;
        long expectedEstimatedResults = 500;
        double expectedProjectedPercent = 30;
        string expectedSource = "api_count";
        double expectedUsagePercent = 25;

        Assert.Equal(expectedAllowed, model.Allowed);
        Assert.Equal(expectedEstimatedResults, model.EstimatedResults);
        Assert.Equal(expectedProjectedPercent, model.ProjectedPercent);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedUsagePercent, model.UsagePercent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtractionEstimateCostResponse
        {
            Allowed = true,
            EstimatedResults = 500,
            ProjectedPercent = 30,
            Source = "api_count",
            UsagePercent = 25,
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
            EstimatedResults = 500,
            ProjectedPercent = 30,
            Source = "api_count",
            UsagePercent = 25,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractionEstimateCostResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAllowed = true;
        long expectedEstimatedResults = 500;
        double expectedProjectedPercent = 30;
        string expectedSource = "api_count";
        double expectedUsagePercent = 25;

        Assert.Equal(expectedAllowed, deserialized.Allowed);
        Assert.Equal(expectedEstimatedResults, deserialized.EstimatedResults);
        Assert.Equal(expectedProjectedPercent, deserialized.ProjectedPercent);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedUsagePercent, deserialized.UsagePercent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtractionEstimateCostResponse
        {
            Allowed = true,
            EstimatedResults = 500,
            ProjectedPercent = 30,
            Source = "api_count",
            UsagePercent = 25,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractionEstimateCostResponse
        {
            Allowed = true,
            EstimatedResults = 500,
            ProjectedPercent = 30,
            Source = "api_count",
            UsagePercent = 25,
        };

        ExtractionEstimateCostResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
