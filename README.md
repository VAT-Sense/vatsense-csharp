# VAT Sense C# SDK

The official C# / .NET library for the [VAT Sense](https://vatsense.com) REST API. Validate VAT/EORI numbers, look up VAT/GST rates, calculate prices, convert currencies, and generate VAT-compliant invoices.

## Installation

```sh
dotnet add package vatsense
```

## Quick start

Create a client using your API key from the [VAT Sense dashboard](https://vatsense.com/dashboard). The API uses HTTP Basic Auth with `user` as the username and your API key as the password.

```csharp
using Vatsense;

var client = new VatSenseClient()
{
    Username = "user",
    Password = "your_api_key",
};
```

You can also set the `VAT_SENSE_USERNAME` and `VAT_SENSE_PASSWORD` environment variables and the client will pick them up automatically.

### Validate a VAT number

```csharp
using Vatsense.Models.Validate;

var response = await client.Validate.Check(new ValidateCheckParams
{
    VatNumber = "GB288305674",
});

if (response.Data?.Valid == true)
{
    Console.WriteLine(response.Data.Company?.CompanyName);     // "BRITISH BROADCASTING CORPORATION"
    Console.WriteLine(response.Data.Company?.CompanyAddress);
    Console.WriteLine(response.Data.Company?.CountryCode);      // "GB"
}
```

VAT validation works for the UK, EU, Australia, Norway, Switzerland, South Africa, and Brazil.

### Validate an EORI number

```csharp
var response = await client.Validate.Check(new ValidateCheckParams
{
    EoriNumber = "GB123456789000",
});

if (response.Data?.Valid == true)
{
    Console.WriteLine(response.Data.Company?.CompanyName);
}
```

EORI validation is available for UK and EU numbers only.

### Get a consultation number

If you need an official consultation number from VIES (EU) or HMRC (UK), provide your own VAT number as the requester:

```csharp
var response = await client.Validate.Check(new ValidateCheckParams
{
    VatNumber = "FR12345678901",
    RequesterVatNumber = "FR98765432101",
});

Console.WriteLine(response.Data?.ConsultationNumber);
```

> **Note:** GB requester numbers only work for GB validations, and EU requester numbers only work for EU validations. Cross-region requests are not supported.

### Find the VAT rate for a country

```csharp
using Vatsense.Models.Rates;

var rate = await client.Rates.Find(new RateFindParams
{
    CountryCode = "DE",
});

Console.WriteLine(rate.Data?.CountryName);     // "Germany"
Console.WriteLine(rate.Data?.TaxRate?.Rate);   // 19
Console.WriteLine(rate.Data?.TaxRate?.Class);  // "standard"
```

### Find a rate for a specific product type

```csharp
var rate = await client.Rates.Find(new RateFindParams
{
    CountryCode = "DE",
    Type = "ebooks",
});

Console.WriteLine(rate.Data?.TaxRate?.Rate);   // 7
Console.WriteLine(rate.Data?.TaxRate?.Class);  // "reduced"
```

### Find a rate by IP address

Useful for determining the correct rate based on your customer's location:

```csharp
var rate = await client.Rates.Find(new RateFindParams
{
    IpAddress = "185.86.151.11",
});

Console.WriteLine(rate.Data?.CountryCode);     // "GB"
Console.WriteLine(rate.Data?.TaxRate?.Rate);   // 20
```

### Calculate a VAT-inclusive price

```csharp
var result = await client.Rates.CalculatePrice(new RateCalculatePriceParams
{
    Price = "100.00",
    TaxType = RateCalculatePriceParamsTaxType.Excl,
    CountryCode = "FR",
});

Console.WriteLine(result.Data?.VatPrice?.PriceInclVat);  // Price including VAT
Console.WriteLine(result.Data?.VatPrice?.PriceExclVat);  // Price excluding VAT
Console.WriteLine(result.Data?.VatPrice?.VatRate);        // VAT rate applied
Console.WriteLine(result.Data?.VatPrice?.Vat);            // VAT amount
```

### List all VAT rates

```csharp
var rates = await client.Rates.List();

foreach (var rate in rates.Data!)
{
    Console.WriteLine($"{rate.CountryCode}: {rate.CountryName}");
}

// Filter to EU countries only
var euRates = await client.Rates.List(new RateListParams { Eu = true });
```

## Handling errors

When the API returns an error, the library throws a typed exception:

```csharp
using Vatsense.Exceptions;

try
{
    var response = await client.Validate.Check(new ValidateCheckParams
    {
        VatNumber = "GB288305674",
    });
}
catch (VatSenseApiException e)
{
    Console.WriteLine(e.StatusCode);
    Console.WriteLine(e.Message);
}
```

A `412` error means the upstream validation service (VIES, HMRC, etc.) is temporarily unavailable. These requests do not count against your usage quota.

## Retries

Failed requests are automatically retried up to 2 times with exponential backoff. This includes connection errors, timeouts, 429, and 5xx responses.

```csharp
// Disable retries
var client = new VatSenseClient()
{
    Username = "user",
    Password = "your_api_key",
    MaxRetries = 0,
};
```

## Available services

| Service               | Description                                     |
| --------------------- | ----------------------------------------------- |
| `client.Validate`     | Validate VAT and EORI numbers                   |
| `client.Rates`        | VAT/GST rate lookups, price calculations         |
| `client.Countries`    | Country data and province lookups                |
| `client.Currency`     | Exchange rates and currency conversion           |
| `client.Invoice`      | Create and manage VAT-compliant invoices         |
| `client.Usage`        | Check your API usage                             |

## Documentation

Full API documentation is available at [vatsense.com/documentation](https://vatsense.com/documentation).

## Versioning

This package follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions. As the library is in initial development and has a major version of `0`, APIs may change at any time.

## Contributing

See [the contributing documentation](https://github.com/VAT-Sense/vatsense-csharp/tree/main/CONTRIBUTING.md).
