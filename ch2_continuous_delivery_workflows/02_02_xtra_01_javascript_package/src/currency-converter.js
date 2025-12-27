/**
 * A simple currency converter using JavaScript.
 * Demonstrates npm build process with modern JavaScript.
 */
class CurrencyConverter {
    /**
     * Default constructor for CurrencyConverter.
     * Creates a new instance of the currency converter.
     */
    constructor() {
        // Exchange rates relative to USD
        this.EXCHANGE_RATES = new Map([
            ["USD", 1.00],
            ["EUR", 0.92],
            ["GBP", 0.79],
            ["JPY", 149.50],
            ["CAD", 1.36]
        ]);
    }

    /**
     * Converts an amount from one currency to another.
     *
     * @param {number} amount - The amount to convert
     * @param {string} fromCurrency - The source currency code
     * @param {string} toCurrency - The target currency code
     * @returns {number} The converted amount
     * @throws {Error} If currency codes are invalid or amount is negative
     */
    convert(amount, fromCurrency, toCurrency) {
        this.validateCurrency(fromCurrency);
        this.validateCurrency(toCurrency);

        if (amount < 0) {
            throw new Error("Amount cannot be negative");
        }

        // Convert to USD first, then to target currency
        const amountInUsd = amount / this.EXCHANGE_RATES.get(fromCurrency);
        const result = amountInUsd * this.EXCHANGE_RATES.get(toCurrency);

        // Round to 2 decimal places
        return Math.round(result * 100) / 100;
    }

    /**
     * Checks if a currency code is supported.
     *
     * @param {string} currencyCode - The currency code to check
     * @returns {boolean} True if supported, false otherwise
     */
    isSupportedCurrency(currencyCode) {
        return this.EXCHANGE_RATES.has(currencyCode);
    }

    /**
     * Validates that a currency code is supported.
     *
     * @private
     * @param {string} currencyCode - The currency code to validate
     * @throws {Error} If currency code is not supported
     */
    validateCurrency(currencyCode) {
        if (!this.isSupportedCurrency(currencyCode)) {
            const supportedCurrencies = Array.from(this.EXCHANGE_RATES.keys()).join(", ");
            throw new Error(
                `Unsupported currency: ${currencyCode}. Supported currencies: ${supportedCurrencies}`
            );
        }
    }
}

// Export for use as a module
if (typeof module !== 'undefined' && module.exports) {
    module.exports = CurrencyConverter;
}

// Demo functionality when run directly
if (require.main === module) {
    const converter = new CurrencyConverter();

    console.log("=== Currency Converter Demo ===\n");

    // Demo conversions
    const conversions = [
        [100, "USD", "EUR"],
        [50, "GBP", "JPY"],
        [1000, "JPY", "CAD"]
    ];

    for (const [amount, from, to] of conversions) {
        const result = converter.convert(amount, from, to);
        console.log(`${amount} ${from} = ${result} ${to}`);
    }

    console.log("\nConversions complete.");
}
