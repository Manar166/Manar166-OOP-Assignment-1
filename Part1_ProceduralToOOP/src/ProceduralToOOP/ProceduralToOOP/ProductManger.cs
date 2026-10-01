using System;
using System.Collections.Generic;
using System.Text;

namespace ProceduralToOOP
{
    public class ProductManger
    {
        List<Product> products = new List<Product>() 
        {

            (new Product(101, "USB Cable", 50.0, 100)),
            (new Product(102, "Wireless Mouse", 250.0, 40)),
            (new Product(103, "Mechanical Keyboard", 1200.0, 15)),
            (new Product(104, "Laptop Stand", 400.0, 25)),
        };
        const int MaxProducts = 50;

        public Product? GetProductById(int id)
        {
            foreach (var product in products)
            {
                if (id == product.ProductId)
                {
                    return product;
                }
            }
            return null;
        }

        public void AddProduct(Product p)
        {
            if (products.Count >= MaxProducts)
            {
                Console.WriteLine("Error:Product List is full");
                return;
            }
            var product = GetProductById(p.ProductId);
            if (product is null)
            {
                products.Add(p);
                return;
            }
            
            Console.WriteLine($"ERROR: Product id  {p.ProductId}  already exists.");
            



        }

        public void PrintProducts()
        {
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }

        

    }
}
