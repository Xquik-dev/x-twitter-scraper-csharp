// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Extractions;

namespace XTwitterScraper.Tests.Models.Extractions;

public class ExtractionRunResponseTest : TestBase
{
    const string EstimateJson = """
        {"allowed":true,"creditsAvailable":"50000","creditsRequired":"500","estimatedResults":500,"source":"followers"}
        """;

    const string StartedJson = """
        {"id":"ext_123","url":"https://dashboard.xquik.com/activity/a1b2c3d4e5f6","pollAfterMs":1000,"status":"pending","statusUrl":"/api/v1/extractions/ext_123","toolType":"follower_explorer","waitUrl":"/api/v1/extractions/ext_123?wait=10"}
        """;

    static ExtractionRunResponse Parse(string json) =>
        JsonSerializer.Deserialize<ExtractionRunResponse>(json, ModelBase.SerializerOptions)!;

    [Fact]
    public void DryRunEstimateParsesAsEstimate()
    {
        var response = Parse(EstimateJson);

        response.Validate();
        Assert.True(response.TryPickEstimate(out var estimate));
        Assert.False(response.TryPickStarted(out _));
        Assert.True(estimate.Allowed);
        Assert.Equal(500, estimate.EstimatedResults);
        Assert.Equal(Source.Followers, estimate.Source.Value());
        Assert.Equal(
            "estimate",
            response.Match(estimate: (_) => "estimate", started: (_) => "started")
        );
    }

    [Fact]
    public void StartedJobParsesWithEveryStatus()
    {
        foreach (var status in new[] { "pending", "running", "canceled", "completed", "failed" })
        {
            var response = Parse(StartedJson.Replace("\"pending\"", $"\"{status}\""));

            response.Validate();
            Assert.False(response.TryPickEstimate(out _));
            Assert.True(response.TryPickStarted(out var started));
            Assert.Equal("ext_123", started.ID);
            Assert.Equal(1000, started.PollAfterMs);
            Assert.Equal(status, started.Status.Raw());
            Assert.Equal(ExtractionJobToolType.FollowerExplorer, started.ToolType.Value());
            Assert.Equal("/api/v1/extractions/ext_123", started.StatusUrl);
            Assert.Equal("/api/v1/extractions/ext_123?wait=10", started.WaitUrl);
            Assert.Equal("https://dashboard.xquik.com/activity/a1b2c3d4e5f6", started.UrlValue);
        }
    }

    [Theory]
    [InlineData(EstimateJson)]
    [InlineData(StartedJson)]
    public void WireJsonRoundTripsUnchanged(string json)
    {
        var response = Parse(json);

        var again = JsonSerializer.SerializeToElement(response, ModelBase.SerializerOptions);

        Assert.True(JsonElement.DeepEquals(JsonDocument.Parse(json).RootElement, again));
        Assert.Equal(response, Parse(again.GetRawText()));
        Assert.Equal(0, response.GetHashCode());
        Assert.Contains("\"", response.ToString());
    }

    [Fact]
    public void BuiltVariantsSwitchAndCompare()
    {
        ExtractionRunResponse estimate = Parse(EstimateJson)
            .Match(
                estimate: (x) => x,
                started: (_) => throw new System.InvalidOperationException()
            );
        ExtractionRunResponse started = new ExtractionStarted()
        {
            ID = "ext_123",
            UrlValue = "https://dashboard.xquik.com/activity/a1b2c3d4e5f6",
            PollAfterMs = 1000,
            Status = ExtractionJobStatus.Running,
            StatusUrl = "/api/v1/extractions/ext_123",
            ToolType = ExtractionJobToolType.FollowerExplorer,
            WaitUrl = "/api/v1/extractions/ext_123?wait=10",
        };

        var seen = new System.Collections.Generic.List<string>();
        foreach (var response in new[] { estimate, started })
        {
            response.Validate();
            response.Switch(
                estimate: (_) => seen.Add("estimate"),
                started: (_) => seen.Add("started")
            );
        }

        Assert.Equal(["estimate", "started"], seen);
        Assert.NotEqual(estimate, started);
        Assert.Equal("running", started.Json.GetProperty("status").GetString());
    }

    [Theory]
    [InlineData("""{"id":"ext_123","status":"running"}""")]
    [InlineData("""{"allowed":true}""")]
    [InlineData("[]")]
    public void UnknownShapeFailsValidation(string json)
    {
        var response = Parse(json);

        Assert.Null(response.Value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => response.Validate());
        Assert.Throws<XTwitterScraperInvalidDataException>(() =>
            response.Switch(estimate: (_) => { }, started: (_) => { })
        );
        Assert.Throws<XTwitterScraperInvalidDataException>(() =>
            response.Match(estimate: (_) => 0, started: (_) => 1)
        );
        Assert.NotEqual(response, Parse(StartedJson));
    }
}
