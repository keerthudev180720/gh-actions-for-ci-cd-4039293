using Xunit;

namespace CurrencyConverter.Tests;

/// <summary>
/// Test suite for CurrencyConverter using xUnit.
/// </summary>
public class CurrencyConverterTests
{
    private readonly CurrencyConverter _converter;

    public CurrencyConverterTests()
    {
        _converter = new CurrencyConverter();
    }

    [Fact]
    public void Convert_UsdToEur_ConvertsCorrectly()
    {
        decimal amount = 100;
        decimal result = _converter.Convert(amount, "USD", "EUR");

        // 100 USD * 0.92 = 92 EUR
        Assert.Equal(92.00m, result);
    }

    [Fact]
    public void Convert_GbpToJpy_ConvertsBetweenNonUsdCurrencies()
    {
        decimal amount = 10;
        decimal result = _converter.Convert(amount, "GBP", "JPY");

        // 10 GBP -> USD -> JPY
        // Expected: approximately 1892.41 JPY
        Assert.True(result > 1890m);
        Assert.True(result < 1895m);
    }

    [Fact]
    public void Convert_SameCurrency_ReturnsSameAmount()
    {
        decimal amount = 100;
        decimal result = _converter.Convert(amount, "USD", "USD");

        Assert.Equal(100.00m, result);
    }

    [Fact]
    public void Convert_UnsupportedCurrency_ThrowsArgumentException()
    {
        decimal amount = 100;

        Assert.Throws<ArgumentException>(() =>
        {
            _converter.Convert(amount, "USD", "XXX");
        });
    }

    [Fact]
    public void Convert_NegativeAmount_ThrowsArgumentException()
    {
        decimal amount = -100;

        Assert.Throws<ArgumentException>(() =>
        {
            _converter.Convert(amount, "USD", "EUR");
        });
    }

    [Fact]
    public void IsSupportedCurrency_SupportedCurrencies_ReturnsTrue()
    {
        Assert.True(_converter.IsSupportedCurrency("USD"));
        Assert.True(_converter.IsSupportedCurrency("EUR"));
        Assert.True(_converter.IsSupportedCurrency("GBP"));
    }

    [Fact]
    public void IsSupportedCurrency_UnsupportedCurrency_ReturnsFalse()
    {
        Assert.False(_converter.IsSupportedCurrency("XXX"));
    }

    [Fact]
    public void Convert_ZeroAmount_HandlesCorrectly()
    {
        decimal amount = 0;
        decimal result = _converter.Convert(amount, "USD", "EUR");

        Assert.Equal(0.00m, result);
    }
}
