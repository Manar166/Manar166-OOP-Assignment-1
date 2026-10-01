using System;
using System.Collections.Generic;
using System.Text;

namespace ProceduralToOOP.Services
{
    public class OrderService
    {
        OrderManger orderManger = new OrderManger();
       // CustomerManger customerManger = new CustomerManger();

        public void PrintOneOrderById() 
        {
            Console.WriteLine("Enter Order Id");
            bool isSucceed = int.TryParse(Console.ReadLine(), out int id);
            if (!isSucceed)
            {
                Console.WriteLine("Wrong input");
                return; 
            }
            var order = orderManger.GetOrderById(id);
            if (order is not null)
            {
                orderManger.PrintOneOrder(order);
                return;
            }
            Console.WriteLine("Order doesnot Exist");







        }

        public void PrintOrders()
        {
            orderManger.PrintAllOrders();
        }

        public void CreatOrder()
        {
            
            Console.WriteLine("OrderId");
           
            var isOderIdParsed = int.TryParse(Console.ReadLine(), out int orderId);
            if (!isOderIdParsed)
            {
                Console.WriteLine("wrongInput");
                return;
            }

            Console.WriteLine("CustomerID");

            var isCustomerIdParsed = int.TryParse(Console.ReadLine(), out int customerId);
            if (!isCustomerIdParsed)
            {
                Console.WriteLine("wrong CustomerID");
                return;
            }
            
            Console.WriteLine("Date");

            string? Date = Console.ReadLine();

            var customer = orderManger.customerManger.FindCustomerById(customerId);

            Order order = new Order()
            {
                OrderId= orderId,
                CustomerId=customerId,
                customer=customer,
                OrderDates=Date
            };

            orderManger.AddOrder(order);



        }

        public void AddOrderLine()
        {
            Console.WriteLine("Enter Order Id");
            var isOrderIdParsed = int.TryParse(Console.ReadLine(), out int orderId);
            Console.WriteLine("EnterProductId");
            var isProductParsed = int.TryParse(Console.ReadLine(), out int productId);
            Console.WriteLine("EnterQuantity");
            var isQuantityParsed = int.TryParse(Console.ReadLine(), out int Quantity);

            orderManger.AddOrderLine(orderId, productId, Quantity);



        }

        public void MarkOrderPaid()
        {
            Console.WriteLine("EnterOrderId");
            bool isSucceed = int.TryParse(Console.ReadLine(), out int id);
            if (!isSucceed)
            {
                Console.WriteLine("Wrong input");
                return;
            }
            orderManger.MarkOrderPaid(id);

        }


        public void paidOrders()
        {
            Console.WriteLine($"Paid sales total:{orderManger.paidOrders()}");
        }

        public void RunDemoScenario()
        {
            // === Order 1001 ===
            var order1 = new Order()
            {
                OrderId = 1001,
                CustomerId = 1,
                customer = orderManger.customerManger.FindCustomerById(1),
                OrderDates = "2026-09-15"
            };
            orderManger.AddOrder(order1);

            orderManger.AddOrderLine(1001, 101, 2); // USB Cable x2
            orderManger.AddOrderLine(1001, 102, 1); // Wireless Mouse x1
            orderManger.MarkOrderPaid(1001);


            // === Order 1002 ===
            var order2 = new Order()
            {
                OrderId = 1002,
                CustomerId = 2,
                customer = orderManger.customerManger.FindCustomerById(2),
                OrderDates = "2026-09-15"
            };
            orderManger.AddOrder(order2);

            orderManger.AddOrderLine(1002, 103, 1); // Mechanical Keyboard x1
            orderManger.AddOrderLine(1002, 104, 1); // Laptop Stand x1


            // === Order 1003 ===
            var order3 = new Order()
            {
                OrderId = 1003,
                CustomerId = 3,
                customer = orderManger.customerManger.FindCustomerById(3),
                OrderDates = "2026-09-16"
            };
            orderManger.AddOrder(order3);

            orderManger.AddOrderLine(1003, 101, 5); // USB Cable x5
            orderManger.MarkOrderPaid(1003);
        }

    }
}
