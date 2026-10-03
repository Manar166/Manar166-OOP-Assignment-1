using System.Numerics;

namespace BuilderPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var invoice = new InvoiceBuilder("INV-2026-001", "John Doe")
    .SetCustomerEmail("john.doe@example.com")
    .SetCustomerPhone("+1-555-0199")
    .SetBillingAdderss("123 Elm St", "Springfield", "IL", "62704", "USA")
    .SetShippingAddress("456 Oak St", "Springfield", "IL", "62704", "USA")
    .SetOrderDate(DateTime.Now)
    .SetPaymentMethod("Credit Card")
    .SetCurrency("USD")
    .SetSubTotal(150.00m)
    .SetDiscountAmount(15.00m)
    .SetTaxAmount(12.00m)
    .Build();

            Console.WriteLine($"Invoice ID: {invoice.InvoiceId}, Customer Name: {invoice.CustomerName}, Customer Email: {invoice.CustomerEmail}," +
                $" Customer Phone: {invoice.CustomerPhone}, Billing Address: {invoice.BillingCity}, Shipping Address: {invoice.ShippingCity}");



            Address address=new Address.Builder()
                .SetStreet("123 Main St")
                .SetCity("Anytown")
                .SetState("CA")
                .SetZipCode("12345")
                .SetCountry("USA")
                .Build();
            Console.WriteLine($"Address: {address.Street}, {address.City}, {address.State} {address.ZipCode}, {address.Country}");

           
            Order order = new Order.Builder().WithOrderDate(DateTime.Now)
                .WithPaymentMethod("Credit Card")
                .WithCurrency("USD")
                .WithSubTotal(100.00m)
                .WithDiscountAmount(10.00m)
                .WithTaxAmount(8.00m)
                .Build();
            Console.WriteLine($"Order: {order.OrderDate}, {order.PaymentMethod}, {order.Currency}, {order.TotalAmount}");


            ComposedInvoice composedInvoice = new ComposedInvoice.Builder("INV001", "Ali").SetCustomerEmail("fwefgwr")
                .SetCustomerPhone("123-456-7890")
                .SetBillingAddress(address)
                .SetShippingAddress(address)
                .SetOrderDetails(order)
                .Build();
            Console.WriteLine($"Invoice: {composedInvoice.InvoiceId}, {composedInvoice.CustomerName} , {composedInvoice.CustomerEmail} , {composedInvoice.CustomerPhone}, " +
                $"{composedInvoice.BillingAddress.City}, {composedInvoice.ShippingAddress.City}, {composedInvoice.OrderDetails.TotalAmount} ");
            

        }
    }
}
