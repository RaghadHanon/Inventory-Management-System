using Inventory_Management_System.ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.InventoryManagement
{
    public class Inventory
    {
        private List<Product> products = new List<Product>();
        // Add a product to the inventory
        public void AddProduct(string name, decimal price, Currency currency, int quantity)
        {
            var productPrice = new Price(price, currency);
            var product = new Product(name, quantity, productPrice);
            products.Add(product);

        }
        // View all products in the inventory
        public void ViewAllProducts()
        {
            if (!products.Any())
            {
                Log("\nNo products in inventory.");
                return;
            }

            products.Sort();
            Log("\nProducts in Inventory sorted based on Name-price:");
            foreach (var product in products)
            {
                Log(product.ToString());
            }


        }
        private void Log(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}
