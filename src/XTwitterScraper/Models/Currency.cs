// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(CurrencyConverter))]
public enum Currency
{
    USD,
    EUR,
    GBP,
    TRY,
    JPY,
    CNY,
    KRW,
    CAD,
    AUD,
    MXN,
    AED,
    BRL,
    CHF,
    CZK,
    DKK,
    HKD,
    HUF,
    IDR,
    ILS,
    INR,
    MYR,
    NOK,
    NZD,
    PHP,
    PLN,
    QAR,
    RON,
    SAR,
    SEK,
    SGD,
    THB,
    ZAR,
}

sealed class CurrencyConverter : JsonConverter<Currency>
{
    public override Currency Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => Currency.USD,
            "EUR" => Currency.EUR,
            "GBP" => Currency.GBP,
            "TRY" => Currency.TRY,
            "JPY" => Currency.JPY,
            "CNY" => Currency.CNY,
            "KRW" => Currency.KRW,
            "CAD" => Currency.CAD,
            "AUD" => Currency.AUD,
            "MXN" => Currency.MXN,
            "AED" => Currency.AED,
            "BRL" => Currency.BRL,
            "CHF" => Currency.CHF,
            "CZK" => Currency.CZK,
            "DKK" => Currency.DKK,
            "HKD" => Currency.HKD,
            "HUF" => Currency.HUF,
            "IDR" => Currency.IDR,
            "ILS" => Currency.ILS,
            "INR" => Currency.INR,
            "MYR" => Currency.MYR,
            "NOK" => Currency.NOK,
            "NZD" => Currency.NZD,
            "PHP" => Currency.PHP,
            "PLN" => Currency.PLN,
            "QAR" => Currency.QAR,
            "RON" => Currency.RON,
            "SAR" => Currency.SAR,
            "SEK" => Currency.SEK,
            "SGD" => Currency.SGD,
            "THB" => Currency.THB,
            "ZAR" => Currency.ZAR,
            _ => (Currency)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Currency value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Currency.USD => "USD",
                Currency.EUR => "EUR",
                Currency.GBP => "GBP",
                Currency.TRY => "TRY",
                Currency.JPY => "JPY",
                Currency.CNY => "CNY",
                Currency.KRW => "KRW",
                Currency.CAD => "CAD",
                Currency.AUD => "AUD",
                Currency.MXN => "MXN",
                Currency.AED => "AED",
                Currency.BRL => "BRL",
                Currency.CHF => "CHF",
                Currency.CZK => "CZK",
                Currency.DKK => "DKK",
                Currency.HKD => "HKD",
                Currency.HUF => "HUF",
                Currency.IDR => "IDR",
                Currency.ILS => "ILS",
                Currency.INR => "INR",
                Currency.MYR => "MYR",
                Currency.NOK => "NOK",
                Currency.NZD => "NZD",
                Currency.PHP => "PHP",
                Currency.PLN => "PLN",
                Currency.QAR => "QAR",
                Currency.RON => "RON",
                Currency.SAR => "SAR",
                Currency.SEK => "SEK",
                Currency.SGD => "SGD",
                Currency.THB => "THB",
                Currency.ZAR => "ZAR",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
