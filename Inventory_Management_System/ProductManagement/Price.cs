using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.ProductManagement;

    public class Price : IComparable<Price>
    {
        private readonly decimal _itemPrice;

        public decimal ItemPrice
        {
            get => _itemPrice;
            init
            {
                if (value < 0)
                    throw new ArgumentException("Product price cannot be negative.");
                _itemPrice = value;
            }
        }

        public Currency Currency { get; init; }

        public Price(decimal itemPrice, Currency currency)
        {
            ItemPrice = itemPrice;
            Currency = currency;
        }

        public int CompareTo(Price? other)
        {
            ArgumentNullException.ThrowIfNull(other, nameof(other));

            // Convert the other price to the current currency before comparing
            decimal otherPriceInCurrentCurrency = other.ConvertTo(this.Currency);

            return ItemPrice.CompareTo(otherPriceInCurrentCurrency);
        }

        public decimal ConvertTo(Currency toCurrency)
        {
            if (Currency == toCurrency) return ItemPrice;

            decimal conversionRate = GetConversionRate(this.Currency, toCurrency);
            return ItemPrice * conversionRate;
        }

        private decimal GetConversionRate(Currency fromCurrency, Currency toCurrency)
        {
            return (fromCurrency, toCurrency) switch
            {
                (Currency.Dollar, Currency.Euro) => 0.85m,
                (Currency.Dollar, Currency.Pound) => 0.75m,
                (Currency.Euro, Currency.Dollar) => 1 / 0.85m,
                (Currency.Euro, Currency.Pound) => 0.75m / 0.85m,
                (Currency.Pound, Currency.Dollar) => 1 / 0.75m,
                (Currency.Pound, Currency.Euro) => 0.85m / 0.75m,
                _ => throw new ArgumentException("Unsupported currency conversion.")
            };
        }

        public override string ToString() => $"Price: {ItemPrice} {Currency}";
    }

