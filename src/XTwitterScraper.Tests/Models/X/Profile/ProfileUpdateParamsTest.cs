using System;
using XTwitterScraper.Models.X.Profile;

namespace XTwitterScraper.Tests.Models.X.Profile;

public class ProfileUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProfileUpdateParams
        {
            Account = "@elonmusk",
            Description = "description_value",
            Location = "location_value",
            Name = "Example Name",
            UrlValue = "https://xquik.com/example",
        };

        string expectedAccount = "@elonmusk";
        string expectedDescription = "description_value";
        string expectedLocation = "location_value";
        string expectedName = "Example Name";
        string expectedUrlValue = "https://xquik.com/example";

        Assert.Equal(expectedAccount, parameters.Account);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedLocation, parameters.Location);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedUrlValue, parameters.UrlValue);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProfileUpdateParams { Account = "@elonmusk" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Location);
        Assert.False(parameters.RawBodyData.ContainsKey("location"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawBodyData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProfileUpdateParams
        {
            Account = "@elonmusk",

            // Null should be interpreted as omitted for these properties
            Description = null,
            Location = null,
            Name = null,
            UrlValue = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Location);
        Assert.False(parameters.RawBodyData.ContainsKey("location"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawBodyData.ContainsKey("url"));
    }

    [Fact]
    public void Url_Works()
    {
        ProfileUpdateParams parameters = new() { Account = "@elonmusk" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/profile"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProfileUpdateParams
        {
            Account = "@elonmusk",
            Description = "description_value",
            Location = "location_value",
            Name = "Example Name",
            UrlValue = "https://xquik.com/example",
        };

        ProfileUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
