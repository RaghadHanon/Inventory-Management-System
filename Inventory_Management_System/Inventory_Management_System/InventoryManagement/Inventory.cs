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
        // Edit an existing product
        public void EditProduct(string name, string newName = null, decimal? newPrice = null, Currency? newCurrency = null, int? newQuantity = null)
        {
            var product = FindProductByName(name);
            if (product == null)
            {
                Log($"\nProduct '{name}' not found.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(newName))
            {
                product.Name = newName;
            }
            if (newPrice != null && newCurrency != null)
            {
                var newProductPrice = new Price(newPrice.Value, newCurrency.Value);
                product.UpdatePrice(newProductPrice);
            }
            if (newQuantity != null) product.Quantity = newQuantity.Value;

        }
        // Helper method to find a product by name
        private Product FindProductByName(string name)
        {
            return products.FirstOrDefault(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
        }
        // Delete a product from the inventory
        public void DeleteProduct(string name)
        {
            var product = FindProductByName(name);
            if (product == null)
            {
                Console.WriteLine($"Product '{name}' not found.");
                return;
            }

            products.Remove(product);

        }
        private void Log(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}
