using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ProceduralToOOP
{
    public class OrderManger
    {
        ProductManger productManger = new ProductManger();
        public CustomerManger customerManger = new CustomerManger();
        const int MaxOrders = 100;
        List <Order> orders = new List<Order>();

        public void AddOrder(Order o)
        {
            if (orders.Count >= MaxOrders)
            {
                Console.WriteLine("Orders List is full");
                return;
            }
            var order = GetOrderById(o.OrderId);
            if (order is not null)
            {
                Console.WriteLine("Order already Exists");
                
                return;
            }
            var customer = customerManger.FindCustomerById(o.CustomerId);
            if (customer is null)
            {
                Console.WriteLine("ERROR:Customer doesnt exist");
            }
            o.customer = customer;
            orders.Add(o);




        }

        public Order? GetOrderById(int id) => orders.Find(n => n.OrderId == id);


        public void PrintAllOrders()
        {
            foreach (var order in orders)
            {
                var sb = new StringBuilder();

                sb.AppendLine($"\n=== ORDER #{order.OrderId} ===");
                sb.AppendLine($"Date: {order.OrderDates}");
                
                sb.AppendLine($"Customer: {order.customer?.CustomerName} (#{order.customer?.CustomerId})");
                sb.AppendLine($"Paid: {(order.IsPaid ?? false ? "yes" : "no")}");
                sb.AppendLine("Lines:");
                if (order.Lines is not null)
                {
                    foreach (var line in order.Lines)
                        sb.AppendLine("  " + line.ToString());
                }


                Console.WriteLine(sb);
            }
        }
        public void PrintOneOrder(Order order)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"\n=== ORDER #{order.OrderId} ===");
            sb.AppendLine($"Date: {order.OrderDates}");

            sb.AppendLine($"Customer: {order.customer?.CustomerName} (#{order.customer?.CustomerId})");
            sb.AppendLine($"Paid: {(order.IsPaid ?? false ? "yes" : "no")}");
            sb.AppendLine("Lines:");
            if (order.Lines is not null)
            {
                foreach (var line in order.Lines)
                    sb.AppendLine("  " + line.ToString());
            }


            Console.WriteLine(sb);

        }

        public void AddOrderLine(int orderId, int productId, int Quantity)
        {
            var order =GetOrderById(orderId);
            if (order is null)
            {
                Console.WriteLine("order ID doesnot exist");
                return;
            }
            var product = productManger.GetProductById(productId);
            if (product is null)
            {
                Console.WriteLine("Product ID doesnot exist");
                return;
            }

            if (Quantity > product.ProductStock)
            {
                Console.WriteLine("Product quantity is not avialable");
                return;



            }

            order.Lines.Add(new OrderLine(product, Quantity));




        }


        public void MarkOrderPaid(int id)
        {
            var order = GetOrderById(id);
            if (order is null)
            {
                Console.WriteLine("Order does not exist");
                return;
            }
            if (order.Lines?.Count == 0)
            {
                Console.WriteLine("ERROR: cannot pay an empty order.");
                return;
            }
            if (order.IsPaid == true)
            {
                Console.WriteLine("order Marked Paid Before.");
                return;
            }
            order.IsPaid = true;

        }

        public double paidOrders()
        {
            double sum = 00.00;
            foreach (var order in orders)
            {
                if (order.IsPaid==true)
                {
                    sum += CalculateTotalOreder(order.OrderId);
                }
            }
            return sum;

        }

        public double CalculateTotalOreder(int orderId)
        {
            double total = 0.0;
            var order = GetOrderById(orderId);
            if (order is null)
            {
                Console.WriteLine("Order does not Exist");
                return 00.00;
            }


            if (order.Lines is null || order.Lines.Count == 0)
            {
                Console.WriteLine("No Lines");
                return 0.00;
            }
            foreach (var orderLine in order.Lines)
            {

                total += orderLine.LineTotal;
            }


            var customer = customerManger.FindCustomerById(order.CustomerId);
                if (customer is null)
                {
                    Console.WriteLine("Customer does not exist.");
                    return total;

                }

                if (customer.IsVIP)
                { total = total * 0.90; }

              
           


            return total;
        }





    }
}
