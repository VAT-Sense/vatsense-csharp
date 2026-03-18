using System;
using System.Collections.Generic;
using System.Text.Json;
using Vatsense.Core;
using Vatsense.Exceptions;
using Invoice = Vatsense.Models.Invoice;
using Item = Vatsense.Models.Invoice.Item;

namespace Vatsense.Tests.Models.Invoice;

public class InvoiceInvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoice::InvoiceInvoice
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
        };

        string expectedID = "in5aeae457cda2a";
        Invoice::Business expectedBusiness = new()
        {
            Address = "address",
            CompanyNumber = "company_number",
            Logo = "logo",
            Name = "name",
            VatNumber = "vat_number",
        };
        Invoice::InvoiceConversionInput expectedConversion = new()
        {
            CurrencyCode = "GBP",
            Rate = 1.523,
        };
        DateTimeOffset expectedCreated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrencyCode = "USD";
        Invoice::Customer expectedCustomer = new()
        {
            Address = "address",
            CompanyNumber = "company_number",
            Logo = "logo",
            Name = "name",
            VatNumber = "vat_number",
        };
        string expectedDate = "2018-06-03 14:02:00";
        bool expectedHasVat = true;
        string expectedInvoiceNumber = "203";
        string expectedInvoiceUrl = "https://vatsense.com/invoice/1/in5aeae457cda2a";
        bool expectedIsCopy = false;
        bool expectedIsReverseCharge = false;
        List<Item::InvoiceItem> expectedItems =
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
        ];
        string expectedNotes = "notes";
        long expectedNumItems = 1;
        ApiEnum<string, Invoice::Object> expectedObject = Invoice::Object.Invoice;
        string expectedTaxPoint = "2018-06-03 14:02:00";
        ApiEnum<string, Invoice::InvoiceInvoiceTaxType> expectedTaxType =
            Invoice::InvoiceInvoiceTaxType.Incl;
        Invoice::Totals expectedTotals = new()
        {
            Discount = 8,
            Subtotal = 11.99,
            Total = 14.39,
            Vat = 2.4,
        };
        ApiEnum<string, Invoice::InvoiceInvoiceType> expectedType =
            Invoice::InvoiceInvoiceType.Sale;
        DateTimeOffset expectedUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedZeroRated = false;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBusiness, model.Business);
        Assert.Equal(expectedConversion, model.Conversion);
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedDate, model.Date);
        Assert.Equal(expectedHasVat, model.HasVat);
        Assert.Equal(expectedInvoiceNumber, model.InvoiceNumber);
        Assert.Equal(expectedInvoiceUrl, model.InvoiceUrl);
        Assert.Equal(expectedIsCopy, model.IsCopy);
        Assert.Equal(expectedIsReverseCharge, model.IsReverseCharge);
        Assert.NotNull(model.Items);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedNotes, model.Notes);
        Assert.Equal(expectedNumItems, model.NumItems);
        Assert.Equal(expectedObject, model.Object);
        Assert.Equal(expectedTaxPoint, model.TaxPoint);
        Assert.Equal(expectedTaxType, model.TaxType);
        Assert.Equal(expectedTotals, model.Totals);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdated, model.Updated);
        Assert.Equal(expectedZeroRated, model.ZeroRated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invoice::InvoiceInvoice
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoice::InvoiceInvoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoice::InvoiceInvoice
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoice::InvoiceInvoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "in5aeae457cda2a";
        Invoice::Business expectedBusiness = new()
        {
            Address = "address",
            CompanyNumber = "company_number",
            Logo = "logo",
            Name = "name",
            VatNumber = "vat_number",
        };
        Invoice::InvoiceConversionInput expectedConversion = new()
        {
            CurrencyCode = "GBP",
            Rate = 1.523,
        };
        DateTimeOffset expectedCreated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrencyCode = "USD";
        Invoice::Customer expectedCustomer = new()
        {
            Address = "address",
            CompanyNumber = "company_number",
            Logo = "logo",
            Name = "name",
            VatNumber = "vat_number",
        };
        string expectedDate = "2018-06-03 14:02:00";
        bool expectedHasVat = true;
        string expectedInvoiceNumber = "203";
        string expectedInvoiceUrl = "https://vatsense.com/invoice/1/in5aeae457cda2a";
        bool expectedIsCopy = false;
        bool expectedIsReverseCharge = false;
        List<Item::InvoiceItem> expectedItems =
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
        ];
        string expectedNotes = "notes";
        long expectedNumItems = 1;
        ApiEnum<string, Invoice::Object> expectedObject = Invoice::Object.Invoice;
        string expectedTaxPoint = "2018-06-03 14:02:00";
        ApiEnum<string, Invoice::InvoiceInvoiceTaxType> expectedTaxType =
            Invoice::InvoiceInvoiceTaxType.Incl;
        Invoice::Totals expectedTotals = new()
        {
            Discount = 8,
            Subtotal = 11.99,
            Total = 14.39,
            Vat = 2.4,
        };
        ApiEnum<string, Invoice::InvoiceInvoiceType> expectedType =
            Invoice::InvoiceInvoiceType.Sale;
        DateTimeOffset expectedUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedZeroRated = false;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBusiness, deserialized.Business);
        Assert.Equal(expectedConversion, deserialized.Conversion);
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(expectedDate, deserialized.Date);
        Assert.Equal(expectedHasVat, deserialized.HasVat);
        Assert.Equal(expectedInvoiceNumber, deserialized.InvoiceNumber);
        Assert.Equal(expectedInvoiceUrl, deserialized.InvoiceUrl);
        Assert.Equal(expectedIsCopy, deserialized.IsCopy);
        Assert.Equal(expectedIsReverseCharge, deserialized.IsReverseCharge);
        Assert.NotNull(deserialized.Items);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedNotes, deserialized.Notes);
        Assert.Equal(expectedNumItems, deserialized.NumItems);
        Assert.Equal(expectedObject, deserialized.Object);
        Assert.Equal(expectedTaxPoint, deserialized.TaxPoint);
        Assert.Equal(expectedTaxType, deserialized.TaxType);
        Assert.Equal(expectedTotals, deserialized.Totals);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdated, deserialized.Updated);
        Assert.Equal(expectedZeroRated, deserialized.ZeroRated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invoice::InvoiceInvoice
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Invoice::InvoiceInvoice
        {
            Conversion = new() { CurrencyCode = "GBP", Rate = 1.523 },
            Customer = new()
            {
                Address = "address",
                CompanyNumber = "company_number",
                Logo = "logo",
                Name = "name",
                VatNumber = "vat_number",
            },
            Notes = "notes",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Business);
        Assert.False(model.RawData.ContainsKey("business"));
        Assert.Null(model.Created);
        Assert.False(model.RawData.ContainsKey("created"));
        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.Date);
        Assert.False(model.RawData.ContainsKey("date"));
        Assert.Null(model.HasVat);
        Assert.False(model.RawData.ContainsKey("has_vat"));
        Assert.Null(model.InvoiceNumber);
        Assert.False(model.RawData.ContainsKey("invoice_number"));
        Assert.Null(model.InvoiceUrl);
        Assert.False(model.RawData.ContainsKey("invoice_url"));
        Assert.Null(model.IsCopy);
        Assert.False(model.RawData.ContainsKey("is_copy"));
        Assert.Null(model.IsReverseCharge);
        Assert.False(model.RawData.ContainsKey("is_reverse_charge"));
        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
        Assert.Null(model.NumItems);
        Assert.False(model.RawData.ContainsKey("num_items"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.TaxPoint);
        Assert.False(model.RawData.ContainsKey("tax_point"));
        Assert.Null(model.TaxType);
        Assert.False(model.RawData.ContainsKey("tax_type"));
        Assert.Null(model.Totals);
        Assert.False(model.RawData.ContainsKey("totals"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
        Assert.Null(model.ZeroRated);
        Assert.False(model.RawData.ContainsKey("zero_rated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Invoice::InvoiceInvoice
        {
            Conversion = new() { CurrencyCode = "GBP", Rate = 1.523 },
            Customer = new()
            {
                Address = "address",
                CompanyNumber = "company_number",
                Logo = "logo",
                Name = "name",
                VatNumber = "vat_number",
            },
            Notes = "notes",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Invoice::InvoiceInvoice
        {
            Conversion = new() { CurrencyCode = "GBP", Rate = 1.523 },
            Customer = new()
            {
                Address = "address",
                CompanyNumber = "company_number",
                Logo = "logo",
                Name = "name",
                VatNumber = "vat_number",
            },
            Notes = "notes",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Business = null,
            Created = null,
            CurrencyCode = null,
            Date = null,
            HasVat = null,
            InvoiceNumber = null,
            InvoiceUrl = null,
            IsCopy = null,
            IsReverseCharge = null,
            Items = null,
            NumItems = null,
            Object = null,
            TaxPoint = null,
            TaxType = null,
            Totals = null,
            Type = null,
            Updated = null,
            ZeroRated = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Business);
        Assert.False(model.RawData.ContainsKey("business"));
        Assert.Null(model.Created);
        Assert.False(model.RawData.ContainsKey("created"));
        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.Date);
        Assert.False(model.RawData.ContainsKey("date"));
        Assert.Null(model.HasVat);
        Assert.False(model.RawData.ContainsKey("has_vat"));
        Assert.Null(model.InvoiceNumber);
        Assert.False(model.RawData.ContainsKey("invoice_number"));
        Assert.Null(model.InvoiceUrl);
        Assert.False(model.RawData.ContainsKey("invoice_url"));
        Assert.Null(model.IsCopy);
        Assert.False(model.RawData.ContainsKey("is_copy"));
        Assert.Null(model.IsReverseCharge);
        Assert.False(model.RawData.ContainsKey("is_reverse_charge"));
        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
        Assert.Null(model.NumItems);
        Assert.False(model.RawData.ContainsKey("num_items"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.TaxPoint);
        Assert.False(model.RawData.ContainsKey("tax_point"));
        Assert.Null(model.TaxType);
        Assert.False(model.RawData.ContainsKey("tax_type"));
        Assert.Null(model.Totals);
        Assert.False(model.RawData.ContainsKey("totals"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
        Assert.Null(model.ZeroRated);
        Assert.False(model.RawData.ContainsKey("zero_rated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Invoice::InvoiceInvoice
        {
            Conversion = new() { CurrencyCode = "GBP", Rate = 1.523 },
            Customer = new()
            {
                Address = "address",
                CompanyNumber = "company_number",
                Logo = "logo",
                Name = "name",
                VatNumber = "vat_number",
            },
            Notes = "notes",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Business = null,
            Created = null,
            CurrencyCode = null,
            Date = null,
            HasVat = null,
            InvoiceNumber = null,
            InvoiceUrl = null,
            IsCopy = null,
            IsReverseCharge = null,
            Items = null,
            NumItems = null,
            Object = null,
            TaxPoint = null,
            TaxType = null,
            Totals = null,
            Type = null,
            Updated = null,
            ZeroRated = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Invoice::InvoiceInvoice
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
            Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrencyCode = "USD",
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
        };

        Assert.Null(model.Conversion);
        Assert.False(model.RawData.ContainsKey("conversion"));
        Assert.Null(model.Customer);
        Assert.False(model.RawData.ContainsKey("customer"));
        Assert.Null(model.Notes);
        Assert.False(model.RawData.ContainsKey("notes"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Invoice::InvoiceInvoice
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
            Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrencyCode = "USD",
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Invoice::InvoiceInvoice
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
            Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrencyCode = "USD",
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

            Conversion = null,
            Customer = null,
            Notes = null,
        };

        Assert.Null(model.Conversion);
        Assert.True(model.RawData.ContainsKey("conversion"));
        Assert.Null(model.Customer);
        Assert.True(model.RawData.ContainsKey("customer"));
        Assert.Null(model.Notes);
        Assert.True(model.RawData.ContainsKey("notes"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Invoice::InvoiceInvoice
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
            Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrencyCode = "USD",
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

            Conversion = null,
            Customer = null,
            Notes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoice::InvoiceInvoice
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
        };

        Invoice::InvoiceInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BusinessTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoice::Business
        {
            Address = "address",
            CompanyNumber = "company_number",
            Logo = "logo",
            Name = "name",
            VatNumber = "vat_number",
        };

        string expectedAddress = "address";
        string expectedCompanyNumber = "company_number";
        string expectedLogo = "logo";
        string expectedName = "name";
        string expectedVatNumber = "vat_number";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedCompanyNumber, model.CompanyNumber);
        Assert.Equal(expectedLogo, model.Logo);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedVatNumber, model.VatNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invoice::Business
        {
            Address = "address",
            CompanyNumber = "company_number",
            Logo = "logo",
            Name = "name",
            VatNumber = "vat_number",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoice::Business>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoice::Business
        {
            Address = "address",
            CompanyNumber = "company_number",
            Logo = "logo",
            Name = "name",
            VatNumber = "vat_number",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoice::Business>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAddress = "address";
        string expectedCompanyNumber = "company_number";
        string expectedLogo = "logo";
        string expectedName = "name";
        string expectedVatNumber = "vat_number";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedCompanyNumber, deserialized.CompanyNumber);
        Assert.Equal(expectedLogo, deserialized.Logo);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedVatNumber, deserialized.VatNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invoice::Business
        {
            Address = "address",
            CompanyNumber = "company_number",
            Logo = "logo",
            Name = "name",
            VatNumber = "vat_number",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Invoice::Business { Logo = "logo" };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.CompanyNumber);
        Assert.False(model.RawData.ContainsKey("company_number"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.VatNumber);
        Assert.False(model.RawData.ContainsKey("vat_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Invoice::Business { Logo = "logo" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Invoice::Business
        {
            Logo = "logo",

            // Null should be interpreted as omitted for these properties
            Address = null,
            CompanyNumber = null,
            Name = null,
            VatNumber = null,
        };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.CompanyNumber);
        Assert.False(model.RawData.ContainsKey("company_number"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.VatNumber);
        Assert.False(model.RawData.ContainsKey("vat_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Invoice::Business
        {
            Logo = "logo",

            // Null should be interpreted as omitted for these properties
            Address = null,
            CompanyNumber = null,
            Name = null,
            VatNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Invoice::Business
        {
            Address = "address",
            CompanyNumber = "company_number",
            Name = "name",
            VatNumber = "vat_number",
        };

        Assert.Null(model.Logo);
        Assert.False(model.RawData.ContainsKey("logo"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Invoice::Business
        {
            Address = "address",
            CompanyNumber = "company_number",
            Name = "name",
            VatNumber = "vat_number",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Invoice::Business
        {
            Address = "address",
            CompanyNumber = "company_number",
            Name = "name",
            VatNumber = "vat_number",

            Logo = null,
        };

        Assert.Null(model.Logo);
        Assert.True(model.RawData.ContainsKey("logo"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Invoice::Business
        {
            Address = "address",
            CompanyNumber = "company_number",
            Name = "name",
            VatNumber = "vat_number",

            Logo = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoice::Business
        {
            Address = "address",
            CompanyNumber = "company_number",
            Logo = "logo",
            Name = "name",
            VatNumber = "vat_number",
        };

        Invoice::Business copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoice::Customer
        {
            Address = "address",
            CompanyNumber = "company_number",
            Logo = "logo",
            Name = "name",
            VatNumber = "vat_number",
        };

        string expectedAddress = "address";
        string expectedCompanyNumber = "company_number";
        string expectedLogo = "logo";
        string expectedName = "name";
        string expectedVatNumber = "vat_number";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedCompanyNumber, model.CompanyNumber);
        Assert.Equal(expectedLogo, model.Logo);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedVatNumber, model.VatNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invoice::Customer
        {
            Address = "address",
            CompanyNumber = "company_number",
            Logo = "logo",
            Name = "name",
            VatNumber = "vat_number",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoice::Customer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoice::Customer
        {
            Address = "address",
            CompanyNumber = "company_number",
            Logo = "logo",
            Name = "name",
            VatNumber = "vat_number",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoice::Customer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAddress = "address";
        string expectedCompanyNumber = "company_number";
        string expectedLogo = "logo";
        string expectedName = "name";
        string expectedVatNumber = "vat_number";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedCompanyNumber, deserialized.CompanyNumber);
        Assert.Equal(expectedLogo, deserialized.Logo);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedVatNumber, deserialized.VatNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invoice::Customer
        {
            Address = "address",
            CompanyNumber = "company_number",
            Logo = "logo",
            Name = "name",
            VatNumber = "vat_number",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Invoice::Customer { Logo = "logo" };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.CompanyNumber);
        Assert.False(model.RawData.ContainsKey("company_number"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.VatNumber);
        Assert.False(model.RawData.ContainsKey("vat_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Invoice::Customer { Logo = "logo" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Invoice::Customer
        {
            Logo = "logo",

            // Null should be interpreted as omitted for these properties
            Address = null,
            CompanyNumber = null,
            Name = null,
            VatNumber = null,
        };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.CompanyNumber);
        Assert.False(model.RawData.ContainsKey("company_number"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.VatNumber);
        Assert.False(model.RawData.ContainsKey("vat_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Invoice::Customer
        {
            Logo = "logo",

            // Null should be interpreted as omitted for these properties
            Address = null,
            CompanyNumber = null,
            Name = null,
            VatNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Invoice::Customer
        {
            Address = "address",
            CompanyNumber = "company_number",
            Name = "name",
            VatNumber = "vat_number",
        };

        Assert.Null(model.Logo);
        Assert.False(model.RawData.ContainsKey("logo"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Invoice::Customer
        {
            Address = "address",
            CompanyNumber = "company_number",
            Name = "name",
            VatNumber = "vat_number",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Invoice::Customer
        {
            Address = "address",
            CompanyNumber = "company_number",
            Name = "name",
            VatNumber = "vat_number",

            Logo = null,
        };

        Assert.Null(model.Logo);
        Assert.True(model.RawData.ContainsKey("logo"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Invoice::Customer
        {
            Address = "address",
            CompanyNumber = "company_number",
            Name = "name",
            VatNumber = "vat_number",

            Logo = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoice::Customer
        {
            Address = "address",
            CompanyNumber = "company_number",
            Logo = "logo",
            Name = "name",
            VatNumber = "vat_number",
        };

        Invoice::Customer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ObjectTest : TestBase
{
    [Theory]
    [InlineData(Invoice::Object.Invoice)]
    public void Validation_Works(Invoice::Object rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoice::Object> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoice::Object>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<VatSenseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoice::Object.Invoice)]
    public void SerializationRoundtrip_Works(Invoice::Object rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoice::Object> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoice::Object>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoice::Object>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoice::Object>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InvoiceInvoiceTaxTypeTest : TestBase
{
    [Theory]
    [InlineData(Invoice::InvoiceInvoiceTaxType.Incl)]
    [InlineData(Invoice::InvoiceInvoiceTaxType.Excl)]
    public void Validation_Works(Invoice::InvoiceInvoiceTaxType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoice::InvoiceInvoiceTaxType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoice::InvoiceInvoiceTaxType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<VatSenseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoice::InvoiceInvoiceTaxType.Incl)]
    [InlineData(Invoice::InvoiceInvoiceTaxType.Excl)]
    public void SerializationRoundtrip_Works(Invoice::InvoiceInvoiceTaxType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoice::InvoiceInvoiceTaxType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Invoice::InvoiceInvoiceTaxType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoice::InvoiceInvoiceTaxType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Invoice::InvoiceInvoiceTaxType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TotalsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoice::Totals
        {
            Discount = 8,
            Subtotal = 11.99,
            Total = 14.39,
            Vat = 2.4,
        };

        double expectedDiscount = 8;
        double expectedSubtotal = 11.99;
        double expectedTotal = 14.39;
        double expectedVat = 2.4;

        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedSubtotal, model.Subtotal);
        Assert.Equal(expectedTotal, model.Total);
        Assert.Equal(expectedVat, model.Vat);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invoice::Totals
        {
            Discount = 8,
            Subtotal = 11.99,
            Total = 14.39,
            Vat = 2.4,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoice::Totals>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoice::Totals
        {
            Discount = 8,
            Subtotal = 11.99,
            Total = 14.39,
            Vat = 2.4,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoice::Totals>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedDiscount = 8;
        double expectedSubtotal = 11.99;
        double expectedTotal = 14.39;
        double expectedVat = 2.4;

        Assert.Equal(expectedDiscount, deserialized.Discount);
        Assert.Equal(expectedSubtotal, deserialized.Subtotal);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.Equal(expectedVat, deserialized.Vat);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invoice::Totals
        {
            Discount = 8,
            Subtotal = 11.99,
            Total = 14.39,
            Vat = 2.4,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Invoice::Totals { };

        Assert.Null(model.Discount);
        Assert.False(model.RawData.ContainsKey("discount"));
        Assert.Null(model.Subtotal);
        Assert.False(model.RawData.ContainsKey("subtotal"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
        Assert.Null(model.Vat);
        Assert.False(model.RawData.ContainsKey("vat"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Invoice::Totals { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Invoice::Totals
        {
            // Null should be interpreted as omitted for these properties
            Discount = null,
            Subtotal = null,
            Total = null,
            Vat = null,
        };

        Assert.Null(model.Discount);
        Assert.False(model.RawData.ContainsKey("discount"));
        Assert.Null(model.Subtotal);
        Assert.False(model.RawData.ContainsKey("subtotal"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
        Assert.Null(model.Vat);
        Assert.False(model.RawData.ContainsKey("vat"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Invoice::Totals
        {
            // Null should be interpreted as omitted for these properties
            Discount = null,
            Subtotal = null,
            Total = null,
            Vat = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoice::Totals
        {
            Discount = 8,
            Subtotal = 11.99,
            Total = 14.39,
            Vat = 2.4,
        };

        Invoice::Totals copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InvoiceInvoiceTypeTest : TestBase
{
    [Theory]
    [InlineData(Invoice::InvoiceInvoiceType.Sale)]
    [InlineData(Invoice::InvoiceInvoiceType.Refund)]
    public void Validation_Works(Invoice::InvoiceInvoiceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoice::InvoiceInvoiceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoice::InvoiceInvoiceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<VatSenseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoice::InvoiceInvoiceType.Sale)]
    [InlineData(Invoice::InvoiceInvoiceType.Refund)]
    public void SerializationRoundtrip_Works(Invoice::InvoiceInvoiceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoice::InvoiceInvoiceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoice::InvoiceInvoiceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoice::InvoiceInvoiceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoice::InvoiceInvoiceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
