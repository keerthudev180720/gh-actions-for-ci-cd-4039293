using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverter;

/// <summary>
/// A simple currency converter using C#.
/// Demonstrates .NET build process with modern C#.
/// </summary>
public class CurrencyConverter
{
    /// <summary>
    /// Exchange rates relative to USD
    /// </summary>
    private static readonly Dictionary<string, decimal> ExchangeRates = new()
    {
        { "USD", 1.00m },
        { "EUR", 0.92m },
        { "GBP", 0.79m },
        { "JPY", 149.50m },
        { "CAD", 1.36m }
    };

    /// <summary>
    /// Default constructor for CurrencyConverter.
    /// Creates a new instance of the currency converter.
    /// </summary>
    public CurrencyConverter()
    {
        // Default constructor
    }

    /// <summary>
    /// Converts an amount from one currency to another.
    /// </summary>
    /// <param name="amount">The amount to convert</param>
    /// <param name="fromCurrency">The source currency code</param>
    /// <param name="toCurrency">The target currency code</param>
    /// <returns>The converted amount</returns>
    /// <exception cref="ArgumentException">Thrown when currency codes are invalid or amount is negative</exception>
    public decimal Convert(decimal amount, string fromCurrency, string toCurrency)
    {
        ValidateCurrency(fromCurrency);
        ValidateCurrency(toCurrency);

        if (amount < 0)
        {
            throw new ArgumentException("Amount cannot be negative");
        }

        // Convert to USD first, then to target currency
        var amountInUsd = amount / ExchangeRates[fromCurrency];
        var result = amountInUsd * ExchangeRates[toCurrency];

        // Round to 2 decimal places
        return Math.Round(result, 2, MidpointRounding.AwayFromZero);
    }

    /// <summary>
    /// Checks if a currency code is supported.
    /// </summary>
    /// <param name="currencyCode">The currency code to check</param>
    /// <returns>True if supported, false otherwise</returns>
    public bool IsSupportedCurrency(string currencyCode)
    {
        return ExchangeRates.ContainsKey(currencyCode);
    }

    /// <summary>
    /// Validates that a currency code is supported.
    /// </summary>
    /// <param name="currencyCode">The currency code to validate</param>
    /// <exception cref="ArgumentException">Thrown when currency code is not supported</exception>
    private void ValidateCurrency(string currencyCode)
    {
        if (!IsSupportedCurrency(currencyCode))
        {
            var supportedCurrencies = string.Join(", ", ExchangeRates.Keys);
            throw new ArgumentException(
                $"Unsupported currency: {currencyCode}. Supported currencies: {supportedCurrencies}"
            );
        }
    }
}
