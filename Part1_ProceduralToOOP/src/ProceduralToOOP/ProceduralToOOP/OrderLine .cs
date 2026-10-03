using System;
using System.Collections.Generic;
using System.Text;

namespace ProceduralToOOP
{
    public class OrderLine
    {
        public OrderLine(Product product, int quantity)
        {
           this.product = product;
            this.quantity = quantity;
        }

      //  public int ProductId { get; set; }
        public int quantity { get; set; }

        public Product product { get; set; }

        public double LineTotal { get { return product.ProductPrice * quantity; } }

        public override string ToString()
        {
            return $"ProductID={product.ProductId} ## Quantity={quantity} ## TOTAL={LineTotal}";
        }




    }
}
