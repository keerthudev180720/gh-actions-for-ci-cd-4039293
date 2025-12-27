# frozen_string_literal: true

require "spec_helper"
require "currency_converter"

RSpec.describe CurrencyConverter do
  subject(:converter) { described_class.new }

  describe "#convert" do
    context "when converting USD to EUR" do
      it "converts correctly" do
        amount = 100
        result = converter.convert(amount, "USD", "EUR")

        # 100 USD * 0.92 = 92 EUR
        expect(result).to eq(92.00)
      end
    end

    context "when converting between non-USD currencies" do
      it "converts GBP to JPY correctly" do
        amount = 10
        result = converter.convert(amount, "GBP", "JPY")

        # 10 GBP -> USD -> JPY
        # Expected: approximately 1892.41 JPY
        expect(result).to be > 1890
        expect(result).to be < 1895
      end
    end

    context "when converting same currency" do
      it "returns the same amount" do
        amount = 100
        result = converter.convert(amount, "USD", "USD")

        expect(result).to eq(100.00)
      end
    end

    context "when currency is unsupported" do
      it "raises an ArgumentError" do
        amount = 100

        expect do
          converter.convert(amount, "USD", "XXX")
        end.to raise_error(ArgumentError, /Unsupported currency/)
      end
    end

    context "when amount is negative" do
      it "raises an ArgumentError" do
        amount = -100

        expect do
          converter.convert(amount, "USD", "EUR")
        end.to raise_error(ArgumentError, "Amount cannot be negative")
      end
    end

    context "when amount is zero" do
      it "handles zero amount correctly" do
        amount = 0
        result = converter.convert(amount, "USD", "EUR")

        expect(result).to eq(0.00)
      end
    end
  end

  describe "#supported_currency?" do
    it "returns true for supported currencies" do
      expect(converter.supported_currency?("USD")).to be true
      expect(converter.supported_currency?("EUR")).to be true
      expect(converter.supported_currency?("GBP")).to be true
    end

    it "returns false for unsupported currencies" do
      expect(converter.supported_currency?("XXX")).to be false
    end
  end
end
