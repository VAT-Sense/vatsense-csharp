using System;
using System.Collections.Generic;
using System.Text.Json;
using VatSense.Core;
using Invoice = VatSense.Models.Invoice;
using Item = VatSense.Models.Invoice.Item;

namespace VatSense.Tests.Models.Invoice;

public class InvoiceListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoice::InvoiceListResponse
        {
            Code = 200,
            Data =
            [
                new()
                {
                    ID = "in5aeae457cda2a",
                    Business = new()
                    {
                        Address = "address",
                        CompanyNumber = "company_number",
                        Logo = "logo",
                        Name = "name",
                        VatNumber = "vat_number",
                    },
                    Conversion = new() { CurrencyCode = "GBP", Rate = 1.523 },
                    Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrencyCode = "USD",
                    Customer = new()
                    {
                        Address = "address",
                        CompanyNumber = "company_number",
                        Logo = "logo",
                        Name = "name",
                        VatNumber = "vat_number",
                    },
                    Date = "2018-06-03 14:02:00",
                    HasVat = true,
                    InvoiceNumber = "203",
                    InvoiceUrl = "https://vatsense.com/invoice/1/in5aeae457cda2a",
                    IsCopy = false,
                    IsReverseCharge = false,
                    Items =
                    [
                        new()
                        {
                            ID = "ii5aeae457ce201",
                            DiscountRate = 40,
                            Item = "Standard payment plan",
                            Object = Item::Object.Item,
                            PriceEach = 19.99,
                            PriceTotal = 11.99,
                            Quantity = 1,
                            VatRate = 20,
                        },
                    ],
                    Notes = "notes",
                    NumItems = 1,
                    Object = Invoice::Object.Invoice,
                    TaxPoint = "2018-06-03 14:02:00",
                    TaxType = Invoice::InvoiceInvoiceTaxType.Incl,
                    Totals = new()
                    {
                        Discount = 8,
                        Subtotal = 11.99,
                        Total = 14.39,
                        Vat = 2.4,
                    },
                    Type = Invoice::InvoiceInvoiceType.Sale,
                    Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ZeroRated = false,
                },
            ],
            Success = true,
        };

        long expectedCode = 200;
        List<Invoice::InvoiceInvoice> expectedData =
        [
            new()
            {
                ID = "in5aeae457cda2a",
                Business = new()
                {
                    Address = "address",
                    CompanyNumber = "company_number",
                    Logo = "logo",
                    Name = "name",
                    VatNumber = "vat_number",
                },
                Conversion = new() { CurrencyCode = "GBP", Rate = 1.523 },
                Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrencyCode = "USD",
                Customer = new()
                {
                    Address = "address",
                    CompanyNumber = "company_number",
                    Logo = "logo",
                    Name = "name",
                    VatNumber = "vat_number",
                },
                Date = "2018-06-03 14:02:00",
                HasVat = true,
                InvoiceNumber = "203",
                InvoiceUrl = "https://vatsense.com/invoice/1/in5aeae457cda2a",
                IsCopy = false,
                IsReverseCharge = false,
                Items =
                [
                    new()
                    {
                        ID = "ii5aeae457ce201",
                        DiscountRate = 40,
                        Item = "Standard payment plan",
                        Object = Item::Object.Item,
                        PriceEach = 19.99,
                        PriceTotal = 11.99,
                        Quantity = 1,
                        VatRate = 20,
                    },
                ],
                Notes = "notes",
                NumItems = 1,
                Object = Invoice::Object.Invoice,
                TaxPoint = "2018-06-03 14:02:00",
                TaxType = Invoice::InvoiceInvoiceTaxType.Incl,
                Totals = new()
                {
                    Discount = 8,
                    Subtotal = 11.99,
                    Total = 14.39,
                    Vat = 2.4,
                },
                Type = Invoice::InvoiceInvoiceType.Sale,
                Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ZeroRated = false,
            },
        ];
        bool expectedSuccess = true;

        Assert.Equal(expectedCode, model.Code);
        Assert.NotNull(model.Data);
        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invoice::InvoiceListResponse
        {
            Code = 200,
            Data =
            [
                new()
                {
                    ID = "in5aeae457cda2a",
                    Business = new()
                    {
                        Address = "address",
                        CompanyNumber = "company_number",
                        Logo = "logo",
                        Name = "name",
                        VatNumber = "vat_number",
                    },
                    Conversion = new() { CurrencyCode = "GBP", Rate = 1.523 },
                    Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrencyCode = "USD",
                    Customer = new()
                    {
                        Address = "address",
                        CompanyNumber = "company_number",
                        Logo = "logo",
                        Name = "name",
                        VatNumber = "vat_number",
                    },
                    Date = "2018-06-03 14:02:00",
                    HasVat = true,
                    InvoiceNumber = "203",
                    InvoiceUrl = "https://vatsense.com/invoice/1/in5aeae457cda2a",
                    IsCopy = false,
                    IsReverseCharge = false,
                    Items =
                    [
                        new()
                        {
                            ID = "ii5aeae457ce201",
                            DiscountRate = 40,
                            Item = "Standard payment plan",
                            Object = Item::Object.Item,
                            PriceEach = 19.99,
                            PriceTotal = 11.99,
                            Quantity = 1,
                            VatRate = 20,
                        },
                    ],
                    Notes = "notes",
                    NumItems = 1,
                    Object = Invoice::Object.Invoice,
                    TaxPoint = "2018-06-03 14:02:00",
                    TaxType = Invoice::InvoiceInvoiceTaxType.Incl,
                    Totals = new()
                    {
                        Discount = 8,
                        Subtotal = 11.99,
                        Total = 14.39,
                        Vat = 2.4,
                    },
                    Type = Invoice::InvoiceInvoiceType.Sale,
                    Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ZeroRated = false,
                },
            ],
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoice::InvoiceListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoice::InvoiceListResponse
        {
            Code = 200,
            Data =
            [
                new()
                {
                    ID = "in5aeae457cda2a",
                    Business = new()
                    {
                        Address = "address",
                        CompanyNumber = "company_number",
                        Logo = "logo",
                        Name = "name",
                        VatNumber = "vat_number",
                    },
                    Conversion = new() { CurrencyCode = "GBP", Rate = 1.523 },
                    Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrencyCode = "USD",
                    Customer = new()
                    {
                        Address = "address",
                        CompanyNumber = "company_number",
                        Logo = "logo",
                        Name = "name",
                        VatNumber = "vat_number",
                    },
                    Date = "2018-06-03 14:02:00",
                    HasVat = true,
                    InvoiceNumber = "203",
                    InvoiceUrl = "https://vatsense.com/invoice/1/in5aeae457cda2a",
                    IsCopy = false,
                    IsReverseCharge = false,
                    Items =
                    [
                        new()
                        {
                            ID = "ii5aeae457ce201",
                            DiscountRate = 40,
                            Item = "Standard payment plan",
                            Object = Item::Object.Item,
                            PriceEach = 19.99,
                            PriceTotal = 11.99,
                            Quantity = 1,
                            VatRate = 20,
                        },
                    ],
                    Notes = "notes",
                    NumItems = 1,
                    Object = Invoice::Object.Invoice,
                    TaxPoint = "2018-06-03 14:02:00",
                    TaxType = Invoice::InvoiceInvoiceTaxType.Incl,
                    Totals = new()
                    {
                        Discount = 8,
                        Subtotal = 11.99,
                        Total = 14.39,
                        Vat = 2.4,
                    },
                    Type = Invoice::InvoiceInvoiceType.Sale,
                    Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ZeroRated = false,
                },
            ],
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoice::InvoiceListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCode = 200;
        List<Invoice::InvoiceInvoice> expectedData =
        [
            new()
            {
                ID = "in5aeae457cda2a",
                Business = new()
                {
                    Address = "address",
                    CompanyNumber = "company_number",
                    Logo = "logo",
                    Name = "name",
                    VatNumber = "vat_number",
                },
                Conversion = new() { CurrencyCode = "GBP", Rate = 1.523 },
                Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrencyCode = "USD",
                Customer = new()
                {
                    Address = "address",
                    CompanyNumber = "company_number",
                    Logo = "logo",
                    Name = "name",
                    VatNumber = "vat_number",
                },
                Date = "2018-06-03 14:02:00",
                HasVat = true,
                InvoiceNumber = "203",
                InvoiceUrl = "https://vatsense.com/invoice/1/in5aeae457cda2a",
                IsCopy = false,
                IsReverseCharge = false,
                Items =
                [
                    new()
                    {
                        ID = "ii5aeae457ce201",
                        DiscountRate = 40,
                        Item = "Standard payment plan",
                        Object = Item::Object.Item,
                        PriceEach = 19.99,
                        PriceTotal = 11.99,
                        Quantity = 1,
                        VatRate = 20,
                    },
                ],
                Notes = "notes",
                NumItems = 1,
                Object = Invoice::Object.Invoice,
                TaxPoint = "2018-06-03 14:02:00",
                TaxType = Invoice::InvoiceInvoiceTaxType.Incl,
                Totals = new()
                {
                    Discount = 8,
                    Subtotal = 11.99,
                    Total = 14.39,
                    Vat = 2.4,
                },
                Type = Invoice::InvoiceInvoiceType.Sale,
                Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ZeroRated = false,
            },
        ];
        bool expectedSuccess = true;

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.NotNull(deserialized.Data);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invoice::InvoiceListResponse
        {
            Code = 200,
            Data =
            [
                new()
                {
                    ID = "in5aeae457cda2a",
                    Business = new()
                    {
                        Address = "address",
                        CompanyNumber = "company_number",
                        Logo = "logo",
                        Name = "name",
                        VatNumber = "vat_number",
                    },
                    Conversion = new() { CurrencyCode = "GBP", Rate = 1.523 },
                    Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrencyCode = "USD",
                    Customer = new()
                    {
                        Address = "address",
                        CompanyNumber = "company_number",
                        Logo = "logo",
                        Name = "name",
                        VatNumber = "vat_number",
                    },
                    Date = "2018-06-03 14:02:00",
                    HasVat = true,
                    InvoiceNumber = "203",
                    InvoiceUrl = "https://vatsense.com/invoice/1/in5aeae457cda2a",
                    IsCopy = false,
                    IsReverseCharge = false,
                    Items =
                    [
                        new()
                        {
                            ID = "ii5aeae457ce201",
                            DiscountRate = 40,
                            Item = "Standard payment plan",
                            Object = Item::Object.Item,
                            PriceEach = 19.99,
                            PriceTotal = 11.99,
                            Quantity = 1,
                            VatRate = 20,
                        },
                    ],
                    Notes = "notes",
                    NumItems = 1,
                    Object = Invoice::Object.Invoice,
                    TaxPoint = "2018-06-03 14:02:00",
                    TaxType = Invoice::InvoiceInvoiceTaxType.Incl,
                    Totals = new()
                    {
                        Discount = 8,
                        Subtotal = 11.99,
                        Total = 14.39,
                        Vat = 2.4,
                    },
                    Type = Invoice::InvoiceInvoiceType.Sale,
                    Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ZeroRated = false,
                },
            ],
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Invoice::InvoiceListResponse { };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Invoice::InvoiceListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Invoice::InvoiceListResponse
        {
            // Null should be interpreted as omitted for these properties
            Code = null,
            Data = null,
            Success = null,
        };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Invoice::InvoiceListResponse
        {
            // Null should be interpreted as omitted for these properties
            Code = null,
            Data = null,
            Success = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoice::InvoiceListResponse
        {
            Code = 200,
            Data =
            [
                new()
                {
                    ID = "in5aeae457cda2a",
                    Business = new()
                    {
                        Address = "address",
                        CompanyNumber = "company_number",
                        Logo = "logo",
                        Name = "name",
                        VatNumber = "vat_number",
                    },
                    Conversion = new() { CurrencyCode = "GBP", Rate = 1.523 },
                    Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrencyCode = "USD",
                    Customer = new()
                    {
                        Address = "address",
                        CompanyNumber = "company_number",
                        Logo = "logo",
                        Name = "name",
                        VatNumber = "vat_number",
                    },
                    Date = "2018-06-03 14:02:00",
                    HasVat = true,
                    InvoiceNumber = "203",
                    InvoiceUrl = "https://vatsense.com/invoice/1/in5aeae457cda2a",
                    IsCopy = false,
                    IsReverseCharge = false,
                    Items =
                    [
                        new()
                        {
                            ID = "ii5aeae457ce201",
                            DiscountRate = 40,
                            Item = "Standard payment plan",
                            Object = Item::Object.Item,
                            PriceEach = 19.99,
                            PriceTotal = 11.99,
                            Quantity = 1,
                            VatRate = 20,
                        },
                    ],
                    Notes = "notes",
                    NumItems = 1,
                    Object = Invoice::Object.Invoice,
                    TaxPoint = "2018-06-03 14:02:00",
                    TaxType = Invoice::InvoiceInvoiceTaxType.Incl,
                    Totals = new()
                    {
                        Discount = 8,
                        Subtotal = 11.99,
                        Total = 14.39,
                        Vat = 2.4,
                    },
                    Type = Invoice::InvoiceInvoiceType.Sale,
                    Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ZeroRated = false,
                },
            ],
            Success = true,
        };

        Invoice::InvoiceListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
