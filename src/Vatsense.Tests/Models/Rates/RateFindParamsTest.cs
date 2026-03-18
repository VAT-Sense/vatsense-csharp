using System;
using Vatsense.Models.Rates;

namespace Vatsense.Tests.Models.Rates;

public class RateFindParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RateFindParams
        {
            CountryCode = "GB",
            Eu = true,
            IPAddress = "86.27.166.97",
            Period = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProvinceCode = "ON",
            Type = "ebooks",
        };

        string expectedCountryCode = "GB";
        bool expectedEu = true;
        string expectedIPAddress = "86.27.166.97";
        DateTimeOffset expectedPeriod = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedProvinceCode = "ON";
        string expectedType = "ebooks";

        Assert.Equal(expectedCountryCode, parameters.CountryCode);
        Assert.Equal(expectedEu, parameters.Eu);
        Assert.Equal(expectedIPAddress, parameters.IPAddress);
        Assert.Equal(expectedPeriod, parameters.Period);
        Assert.Equal(expectedProvinceCode, parameters.ProvinceCode);
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RateFindParams { };

        Assert.Null(parameters.CountryCode);
        Assert.False(parameters.RawQueryData.ContainsKey("country_code"));
        Assert.Null(parameters.Eu);
        Assert.False(parameters.RawQueryData.ContainsKey("eu"));
        Assert.Null(parameters.IPAddress);
        Assert.False(parameters.RawQueryData.ContainsKey("ip_address"));
        Assert.Null(parameters.Period);
        Assert.False(parameters.RawQueryData.ContainsKey("period"));
        Assert.Null(parameters.ProvinceCode);
        Assert.False(parameters.RawQueryData.ContainsKey("province_code"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RateFindParams
        {
            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            Eu = null,
            IPAddress = null,
            Period = null,
            ProvinceCode = null,
            Type = null,
        };

        Assert.Null(parameters.CountryCode);
        Assert.False(parameters.RawQueryData.ContainsKey("country_code"));
        Assert.Null(parameters.Eu);
        Assert.False(parameters.RawQueryData.ContainsKey("eu"));
        Assert.Null(parameters.IPAddress);
        Assert.False(parameters.RawQueryData.ContainsKey("ip_address"));
        Assert.Null(parameters.Period);
        Assert.False(parameters.RawQueryData.ContainsKey("period"));
        Assert.Null(parameters.ProvinceCode);
        Assert.False(parameters.RawQueryData.ContainsKey("province_code"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        RateFindParams parameters = new()
        {
            CountryCode = "GB",
            Eu = true,
            IPAddress = "86.27.166.97",
            Period = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProvinceCode = "ON",
            Type = "ebooks",
        };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.Equal(
            new Uri(
                "https://api.vatsense.com/1.0/rates/rate?country_code=GB&eu=true&ip_address=86.27.166.97&period=2019-12-27T18%3a11%3a19.117%2b00%3a00&province_code=ON&type=ebooks"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RateFindParams
        {
            CountryCode = "GB",
            Eu = true,
            IPAddress = "86.27.166.97",
            Period = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProvinceCode = "ON",
            Type = "ebooks",
        };

        RateFindParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
