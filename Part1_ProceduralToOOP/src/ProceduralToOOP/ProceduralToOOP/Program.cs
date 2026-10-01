using ProceduralToOOP.Services;
using System.Security.Cryptography.X509Certificates;

namespace ProceduralToOOP
{
    internal class Program
    {
        public static CustomerManger custmerMange = new CustomerManger();
        public static ProductManger productMange = new ProductManger();
        public static OrderService orderService = new OrderService();

        static void Main(string[] args)
        {
            orderService.RunDemoScenario();
            custmerMange.PrintCustomers();
            productMange.PrintProducts();
            orderService.PrintOrders();
            Menu();






        }

        static void Menu()
        {
          
            while (true)
            {

                Console.WriteLine("\n---------- MENU ----------");
                Console.WriteLine("1) Print customers");
                Console.WriteLine("2) Print products");
                Console.WriteLine("3) Print all orders");
                Console.WriteLine("4) Print one order by id");
                Console.WriteLine("5) Create order");
                Console.WriteLine("6) Add line to order");
                Console.WriteLine("7) Mark order paid");
                Console.WriteLine("8) Show paid sales total");
                Console.WriteLine("0) Exit");
                Console.Write("Choice: ");

                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {

                            custmerMange.PrintCustomers();
                            break;


                        }
                    case "2":
                        {
                            productMange.PrintProducts();
                            break;
                        }
                    case "3":
                        {
                            orderService.PrintOrders();
                            break;
                        }
                    case "4":
                        {
                            orderService.PrintOneOrderById();
                            break;
                        }
                    case "5":
                        {
                            orderService.CreatOrder();
                            break;
                        }
                    case "6":
                        {
                            orderService.AddOrderLine();
                            break;
                        }
                    case "7":
                        {
                            orderService.MarkOrderPaid();
                            break;
                        }
                    case "8":
                        {
                            orderService.paidOrders();

                            break;
                        }
                    case "0":
                        {
                            Console.WriteLine("Bye");
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong Input");
                            break;
                        }

                   }
                }
            }

     



    }
}
