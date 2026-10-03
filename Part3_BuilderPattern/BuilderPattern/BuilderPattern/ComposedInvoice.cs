using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class ComposedInvoice
    {
        public ComposedInvoice(string invoiceId, string customerName, 
            string customerEmail, string customerPhone, 
            Address billingAddress, Address shippingAddress, Order orderDetails)
        {
            InvoiceId = invoiceId;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerPhone = customerPhone;
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
            OrderDetails = orderDetails;
        }

        public string InvoiceId { get; }
        public string CustomerName { get; }
        public string CustomerEmail { get; }
        public string CustomerPhone { get; }

        public Address BillingAddress { get; }
        public Address ShippingAddress { get; }
        public Order OrderDetails { get; }

        public class Builder
        {
            public Builder(string invoiceId,string customerName)
            {
                if (string.IsNullOrWhiteSpace(invoiceId))
                {
                    throw new ArgumentException("Invoice ID cannot be null or empty.", nameof(invoiceId));
                }
                if (string.IsNullOrWhiteSpace(customerName))
                {
                    throw new ArgumentException("Customer Name cannot be null or empty.", nameof(customerName));
                }
              
                this.invoiceId = invoiceId.ToString();
                this.customerName = customerName;
            }

            private string invoiceId;
            private string customerName;
            private string customerEmail;
            private string customerPhone;  
            private Address billingAddress;
            private Address shippingAddress;
            private Order orderDetails;

            public Builder SetCustomerEmail(string email)
            {
                customerEmail = email;
                return this;
            }

            public Builder SetCustomerPhone(string phone)
            {
                customerPhone = phone;
                return this;
            }

            public Builder SetBillingAddress(Address address)
            {
                billingAddress = address;
                return this;
            }

            public Builder SetShippingAddress(Address address)
            {
                shippingAddress = address;
                return this;
            }

            public Builder SetOrderDetails(Order details)
            {
                orderDetails = details;
                return this;
            }

            public ComposedInvoice Build()
            {
                return new ComposedInvoice(invoiceId, customerName, customerEmail, customerPhone, billingAddress, shippingAddress, orderDetails);
            }


        }


    }
}
