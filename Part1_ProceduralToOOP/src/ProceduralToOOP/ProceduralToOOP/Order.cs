using System;
using System.Collections.Generic;
using System.Text;

namespace ProceduralToOOP
{
    public class Order
    {
        //public Order(int orderId, int customerId, string? orderDates, Customer customer)
        //{
        //    OrderId = orderId;
        //    CustomerId = customerId;
          
        //    OrderDates = orderDates;
        //    this.customer = customer;
        //}

        //int orderCount = 0;
        //int orderIds[MAX_ORDERS];
        //int orderCustomerIndexes[MAX_ORDERS];
        //string orderDates[MAX_ORDERS];
        //bool orderIsPaid[MAX_ORDERS];
        //int orderLineCounts[MAX_ORDERS];

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public bool? IsPaid { get; set; }
        public List<OrderLine>? Lines { get; set; } = new List<OrderLine>();
        public string? OrderDates { get; set; }

        public Customer customer { get; set; }

        //public override string ToString()
        //        {
        //    return 
        //    $"\n=== ORDER #{OrderId} ===\n  Date: {OrderDates}\n Customer: {customer.CustomerName} (#{customer.CustomerId}) " +
        //    $"  Paid= {(IsPaid ? "yes" :"no")} Lines:";

        //}

        //public override string ToString()
        //{
        //    var sb = new StringBuilder();

        //    sb.AppendLine($"\n=== ORDER #{OrderId} ===");
        //    sb.AppendLine($"Date: {OrderDates}");
        //    sb.AppendLine($"Customer: {customer.CustomerName} (#{customer.CustomerId})");
        //    sb.AppendLine($"Paid: {(IsPaid ?? false ? "yes" : "no")}");
        //    sb.AppendLine("Lines:");
        //    if (Lines is not null)
        //    {
        //        foreach (var line in Lines)
        //        sb.AppendLine("  " + line.ToString());
        //    }

        //    return sb.ToString();
        //}


    }
}
