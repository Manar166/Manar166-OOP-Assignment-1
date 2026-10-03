using System;
using System.Collections.Generic;
using System.Text;

namespace ProceduralToOOP
{
    public class CustomerManger
    {
       
        public const int MaxCustomers = 50;

        private List<Customer> customers = new List<Customer>() {

            (new Customer(1, "Mona Ali", "mona@example.com", "Cairo", true)),
           (new Customer(2, "Omar Hassan", "omar@example.com", "Alexandria", false)),
           (new Customer(3, "Sara Nabil", "sara@example.com", "Giza", false))

            };


        public void AddCustomer(Customer c)
        {
            if (customers.Count >= MaxCustomers)
            {
                Console.WriteLine("ERROR: customer list is full.");
                return;
            }
            var customer = FindCustomerById(c.CustomerId);
            if (customer is null)
            {
                customers.Add(c);
                return;
            }
            else
            {
                Console.WriteLine($"ERROR: customer id  {c.CustomerId}  already exists.\n");
            }


        }

        public Customer? FindCustomerById(int id)
        {
            
            return customers.Find(n => n.CustomerId == id);

            



        }

        public void PrintCustomers()
        {
            foreach (var customer in customers)
            {
               Console.WriteLine( customer.ToString());
            }

        }


    }
}
