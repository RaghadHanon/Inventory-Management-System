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
        private List<Product> _products = new List<Product>();
        public void AddProduct(Product product)
        {
            
            _products.Add(product);

        }
        public void ViewAllProducts()
        {
            if (!_products.Any())
            {
                Log("\nNo products in inventory.");
                return;
            }

            _products.Sort();
            Log("\nProducts in Inventory sorted based on Name-price:");
            foreach (var product in _products)
            {
                Log(product.ToString());
            }


        }
        public void EditProduct(string name, string? newName = null, decimal? newPrice = null, Currency? newCurrency = null, int? newQuantity = null)
        {
            var product = FindProductByName(name);
            if (product == null)
            {
                Log($"\nProduct '{name}' not found.");
                return;
            }
            ProductValidator.Validate(product ,newName, newPrice,newCurrency ,newQuantity);

        }
        private Product FindProductByName(string name)
        {
            return _products.FirstOrDefault(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
        }
        public void DeleteProduct(string name)
        {
            var product = FindProductByName(name);
            if (product == null)
            {
                Console.WriteLine($"Product '{name}' not found.");
                return;
            }

            _products.Remove(product);

        }
        public void SearchProduct(string name)
        {
            var product = FindProductByName(name);
            if (product == null)
            {
                Log($"\nProduct '{name}' not found.");
            }
            else
            {
                Log($"\nProduct: {product.ToString()}");
            }
        }
        private void Log(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}
