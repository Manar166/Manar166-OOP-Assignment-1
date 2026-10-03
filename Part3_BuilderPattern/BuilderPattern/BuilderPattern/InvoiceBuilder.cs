using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class InvoiceBuilder
    {
        public InvoiceBuilder(string invoiceId, string customerName)
        {
            if(string.IsNullOrWhiteSpace(invoiceId))
            {
                throw new ArgumentException("Invoice ID cannot be null or empty.", nameof(invoiceId));
            }
            if(string.IsNullOrWhiteSpace(customerName))
            {
                throw new ArgumentException("Customer Name cannot be null or empty.", nameof(customerName));
            }
            InvoiceId = invoiceId;
            CustomerName = customerName;
        }

        public string InvoiceId { get; }
        public string CustomerName { get; }

        public string CustomerEmail { get; private set; }
        public string CustomerPhone { get; private set; }

        public string BillingStreet { get; private set; }
        public string BillingCity { get; private set; }
        public string BillingState { get; private set; }
        public string BillingZipCode { get; private set; }
        public string BillingCountry { get; private set; }

        public string ShippingStreet { get; private set; }
        public string ShippingCity { get; private set; }
        public string ShippingState { get; private set; }
        public string ShippingZipCode { get; private set; }
        public string ShippingCountry { get; private set; }

        public DateTime OrderDate { get; private set; } = DateTime.UtcNow;
        public string PaymentMethod { get; private set; } = "CreditCard";
        public string Currency { get; private set; } = "USD";
        public decimal SubTotal { get; private set; }
        public decimal DiscountAmount { get; private set; }
        public decimal TaxAmount { get; private set; }

        public decimal TotalAmount => SubTotal - DiscountAmount + TaxAmount;

        public InvoiceBuilder SetCustomerEmail(string email)
        {
            CustomerEmail = email;
            return this;
        }

        public InvoiceBuilder SetCustomerPhone(string phone)
        {
            CustomerPhone = phone;
            return this;
        }

        public InvoiceBuilder SetBillingAdderss(string street, string city, string state, string zipCode, string country)
        {
            BillingStreet = street;
            BillingCity = city;
            BillingState = state;
            BillingZipCode = zipCode;
            BillingCountry = country;
            return this;
        }

        public InvoiceBuilder SetShippingAddress(string street, string city, string state, string zipCode, string country)
        {
            ShippingStreet = street;
            ShippingCity = city;
            ShippingState = state;
            ShippingZipCode = zipCode;
            ShippingCountry = country;
            return this;
        }

        public InvoiceBuilder SetOrderDate(DateTime orderDate)
        {
            OrderDate = orderDate;
            return this;
        }

        public InvoiceBuilder SetPaymentMethod(string paymentMethod)
        {
            PaymentMethod = paymentMethod;
            return this;
        }

        public InvoiceBuilder SetCurrency(string currency)
        {
            Currency = currency;
            return this;
        }

        public InvoiceBuilder SetSubTotal(decimal subTotal)
        {
            SubTotal = subTotal;
            return this;
        }

        public InvoiceBuilder SetDiscountAmount(decimal discountAmount)
        {
            DiscountAmount = discountAmount;
            return this;
        }

        public InvoiceBuilder SetTaxAmount(decimal taxAmount)
        {
            TaxAmount = taxAmount;
            return this;
        }

        

        public Invoice Build()
        {
            return new Invoice(InvoiceId, CustomerName, CustomerEmail, CustomerPhone,
                BillingStreet, BillingCity, BillingState, BillingZipCode, BillingCountry,
                ShippingStreet, ShippingCity, ShippingState, ShippingZipCode, ShippingCountry,
                OrderDate, PaymentMethod, Currency, SubTotal, DiscountAmount, TaxAmount);

        }


    }
}
