using Inventory_Management_System.InventoryManagement;
using Inventory_Management_System.ProductManagement;
using System.Diagnostics;
using System.Xml.Linq;

namespace Inventory_Management_System.Utility
{
    internal class Utilities
    {
        static Inventory inventory = new Inventory();

        internal static void InitializeStock()
        {
            // stock initialization
            var product = new Product("Laptop", 10, new Price(1200.00m, Currency.Dollar));
            inventory.AddProduct(product);
            product = new Product("Smartphone", 25, new Price(800.00m, Currency.Euro));
            inventory.AddProduct(product);
            product = new Product("Headphones", 50, new Price(150.00m, Currency.Pound));
            inventory.AddProduct(product);
            product = new Product("Tablet", 25, new Price(400.00m, Currency.Dollar));
            inventory.AddProduct(product);
            product = new Product("Smartwatch", 30, new Price(200.00m, Currency.Euro));
            inventory.AddProduct(product);

        }

        internal static void ShowMainMenu()
        {
            bool exit = false;

            do
            {
                Console.WriteLine("\n---------------------- Inventory Management System ----------------------\n");


                ViewAllProducts();

                Console.WriteLine("\n1. Add a product");
                Console.WriteLine("2. View all products");
                Console.WriteLine("3. Edit a product");
                Console.WriteLine("4. Delete a product");
                Console.WriteLine("5. Search for a product");
                Console.WriteLine("6. Exit");
                Console.Write("Please select an option (1-6): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        ViewAllProducts();
                        break;
                    case "3":
                        EditProduct();
                        break;
                    case "4":
                        DeleteProduct();
                        break;
                    case "5":
                        SearchProduct();
                        break;
                    case "6":
                        ExitApplication();
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.\n");
                        break;
                }
            } while (!exit);
        }
        static void AddProduct()
        {
            Console.Write("Enter product name (more than 2 characters): ");
            string name = Console.ReadLine();

            Console.Write("Enter product price (non-negative value): ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter currency (Dollar/Euro/Pound): ");
            Currency currency = (Currency)Enum.Parse(typeof(Currency), Console.ReadLine(), true);

            Console.Write("Enter product quantity (non-negativ negative): ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            var productPrice = new Price(price, currency);
            var product = new Product(name, quantity, productPrice);

            inventory.AddProduct(product);

        }
        static void ViewAllProducts()
        {
            inventory.ViewAllProducts();
            Console.WriteLine();
        }

        static void EditProduct()
        {
            ViewAllProducts();
            Console.Write("Enter the name of the product you want to edit: ");
            string name = Console.ReadLine();

            Console.Write("Enter new product name (or press Enter to skip): ");
            string? newName = Console.ReadLine();
            newName = string.IsNullOrWhiteSpace(newName) ? null : newName;

            Console.Write("Enter new product price (or press Enter to skip): ");
            string? priceInput = Console.ReadLine();
            decimal? newPrice = null;
            if (!string.IsNullOrEmpty(priceInput) && decimal.TryParse(priceInput, out decimal parsedPrice))
            {
                newPrice = parsedPrice;
            }

            Console.Write("Enter new currency (Dollar/Euro/Pound or press Enter to skip): ");
            string? currencyInput = Console.ReadLine();
            Currency? newCurrency = null;
            if (!string.IsNullOrEmpty(currencyInput) && Enum.TryParse(currencyInput, true, out Currency parsedCurrency))
            {
                newCurrency = parsedCurrency;
            }

            Console.Write("Enter new product quantity (or press Enter to skip): ");
            string? quantityInput = Console.ReadLine();
            int? newQuantity = null;
            if (!string.IsNullOrEmpty(quantityInput) && int.TryParse(quantityInput, out int parsedQuantity))
            {
                newQuantity = parsedQuantity;
            }

            inventory.EditProduct(name, newName, newPrice, newCurrency, newQuantity);
        }

        static void DeleteProduct()
        {
            Console.Write("Enter the name of the product you want to delete: ");
            string name = Console.ReadLine();
            inventory.DeleteProduct(name);

        }

        static void SearchProduct()
        {
            Console.Write("Enter the name of the product you want to search for: ");
            string name = Console.ReadLine();
            inventory.SearchProduct(name);
        }
        static void ExitApplication()
        {
            Console.WriteLine("Exiting the application.");
        }
    }
}
