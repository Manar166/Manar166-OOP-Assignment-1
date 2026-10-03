using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class Order
    {
        public Order(DateTime orderDate, string paymentMethod, string currency, decimal subTotal, decimal discountAmount, decimal taxAmount)
        {
            OrderDate = orderDate;
            PaymentMethod = paymentMethod;
            Currency = currency;
            SubTotal = subTotal;
            DiscountAmount = discountAmount;
            TaxAmount = taxAmount;
        }

        public DateTime OrderDate { get; }
        public string PaymentMethod { get; }
        public string Currency { get; }
        public decimal SubTotal { get; }
        public decimal DiscountAmount { get; }
        public decimal TaxAmount { get; }
        public decimal TotalAmount => SubTotal - DiscountAmount + TaxAmount;

        public class Builder
        {
            private DateTime orderDate = DateTime.UtcNow;
            private string paymentMethod = "CreditCard";
            private string currency = "USD";
            private decimal subTotal;
            private decimal discountAmount;
            private decimal taxAmount;

            public Builder WithOrderDate(DateTime dateTime)
            {
                orderDate = dateTime;
                return this;
            }

            public Builder WithPaymentMethod(string method)
            {
                paymentMethod = method;
                return this;
            }
            public Builder WithCurrency(string currencyCode)
            {
                currency = currencyCode;
                return this;
            }

            public Builder WithSubTotal(decimal amount)
            {
                subTotal = amount;
                return this;
            }

            public Builder WithDiscountAmount(decimal amount)
            {
                discountAmount = amount;
                return this;
            }

            public Builder WithTaxAmount(decimal amount)
            {
                taxAmount = amount;
                return this;
            }

            public Order Build()
            {
                return new Order(orderDate, paymentMethod, currency, subTotal, discountAmount, taxAmount);
            }

            

        }
    }
}
