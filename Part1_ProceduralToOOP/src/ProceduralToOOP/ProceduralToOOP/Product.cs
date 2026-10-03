using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ProceduralToOOP
{
    public class Product
    {
        public Product(int productId, string productName, double productPrice, int productStock)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductStock = productStock;
        }

        //int productCount = 0;
        //int productIds[MAX_PRODUCTS];
        //string productNames[MAX_PRODUCTS];
        //double productPrices[MAX_PRODUCTS];
        //int productStock[MAX_PRODUCTS];

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductStock { get; set; }

        public override string ToString()
        {

            return  $"#{ProductId}  {ProductName}  price={ProductPrice}  stock={ProductStock}";

           
        }



    }
}
