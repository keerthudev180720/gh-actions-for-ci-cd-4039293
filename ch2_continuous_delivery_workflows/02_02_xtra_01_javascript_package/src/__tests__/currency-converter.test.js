const CurrencyConverter = require('../currency-converter');

/**
 * Test suite for CurrencyConverter using Jest.
 */
describe('CurrencyConverter', () => {
    let converter;

    beforeEach(() => {
        converter = new CurrencyConverter();
    });

    test('Should convert USD to EUR correctly', () => {
        const amount = 100;
        const result = converter.convert(amount, "USD", "EUR");

        // 100 USD * 0.92 = 92 EUR
        expect(result).toBe(92.00);
    });

    test('Should convert between non-USD currencies', () => {
        const amount = 10;
        const result = converter.convert(amount, "GBP", "JPY");

        // 10 GBP -> USD -> JPY
        // Expected: approximately 1892.41 JPY
        expect(result).toBeGreaterThan(1890);
        expect(result).toBeLessThan(1895);
    });

    test('Should handle same currency conversion', () => {
        const amount = 100;
        const result = converter.convert(amount, "USD", "USD");

        expect(result).toBe(100.00);
    });

    test('Should throw exception for unsupported currency', () => {
        const amount = 100;

        expect(() => {
            converter.convert(amount, "USD", "XXX");
        }).toThrow("Unsupported currency");
    });

    test('Should throw exception for negative amount', () => {
        const amount = -100;

        expect(() => {
            converter.convert(amount, "USD", "EUR");
        }).toThrow("Amount cannot be negative");
    });

    test('Should correctly identify supported currencies', () => {
        expect(converter.isSupportedCurrency("USD")).toBe(true);
        expect(converter.isSupportedCurrency("EUR")).toBe(true);
        expect(converter.isSupportedCurrency("GBP")).toBe(true);
        expect(converter.isSupportedCurrency("XXX")).toBe(false);
    });

    test('Should handle zero amount', () => {
        const amount = 0;
        const result = converter.convert(amount, "USD", "EUR");

        expect(result).toBe(0.00);
    });
});
