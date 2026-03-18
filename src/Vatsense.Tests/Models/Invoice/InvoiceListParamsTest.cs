using System;
using Vatsense.Models.Invoice;

namespace Vatsense.Tests.Models.Invoice;

public class InvoiceListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoiceListParams
        {
            Limit = 1,
            Offset = 0,
            Search = "search",
        };

        long expectedLimit = 1;
        long expectedOffset = 0;
        string expectedSearch = "search";

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedSearch, parameters.Search);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvoiceListParams { };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.Search);
        Assert.False(parameters.RawQueryData.ContainsKey("search"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InvoiceListParams
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Offset = null,
            Search = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.Search);
        Assert.False(parameters.RawQueryData.ContainsKey("search"));
    }

    [Fact]
    public void Url_Works()
    {
        InvoiceListParams parameters = new()
        {
            Limit = 1,
            Offset = 0,
            Search = "search",
        };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.Equal(
            new Uri("https://api.vatsense.com/1.0/invoice?limit=1&offset=0&search=search"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvoiceListParams
        {
            Limit = 1,
            Offset = 0,
            Search = "search",
        };

        InvoiceListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
