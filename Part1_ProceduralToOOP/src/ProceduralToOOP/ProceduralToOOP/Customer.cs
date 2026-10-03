using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace ProceduralToOOP
{
    public class Customer
    {
        //const int MAX_CUSTOMERS = 50;
        //int customerCount;
        //int customerIds[MAX_CUSTOMERS];
        //string customerNames[MAX_CUSTOMERS];
        //string customerEmails[MAX_CUSTOMERS];
        //string customerCities[MAX_CUSTOMERS];
        //bool customerIsVip[MAX_CUSTOMERS];


        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerCity { get; set; }
        public bool IsVIP { get; set; }

       

         public Customer()
        {
           
        }



        public Customer(int customerId, string customerName, string? customerEmail, string? customerCity, bool isVIP)
        {




            CustomerId = customerId;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerCity = customerCity;
            IsVIP = isVIP;

        }

        public override string ToString()
        {
            return $"# {CustomerId}  - {CustomerName} - {CustomerEmail} - {CustomerCity} - vip={(IsVIP ? "yes" : "no")}";
        }


    }
}
