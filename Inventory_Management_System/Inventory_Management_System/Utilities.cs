using Inventory_Management_System.InventoryManagement;
using Inventory_Management_System.ProductManagement;

namespace Inventory_Management_System
{
    internal class Utilities
    {
        static Inventory inventory = new Inventory();

        internal static void InitializeStock()
        {
            // stock initialization
            inventory.AddProduct("Laptop", 1200.00m, Currency.Dollar, 10);
            inventory.AddProduct("Smartphone", 800.00m, Currency.Euro, 25);
            inventory.AddProduct("Headphones", 150.00m, Currency.Pound, 50);
            inventory.AddProduct("Tablet", 400.00m, Currency.Dollar, 15);
            inventory.AddProduct("Smartwatch", 200.00m, Currency.Euro, 30);

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
                Console.Write("Please select an option (1 - 3): ");

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

            inventory.AddProduct(name, price, currency, quantity);

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
            decimal? newPrice = !string.IsNullOrEmpty(priceInput) ? Convert.ToDecimal(priceInput) : (decimal?)null;

            Console.Write("Enter new currency (Dollar/Euro/Pound or press Enter to skip): ");
            string? currencyInput = Console.ReadLine();
            Currency? newCurrency = !string.IsNullOrEmpty(currencyInput) ? (Currency)Enum.Parse(typeof(Currency), currencyInput, true) : (Currency?)null;

            Console.Write("Enter new product quantity (or press Enter to skip): ");
            string? quantityInput = Console.ReadLine();
            int? newQuantity = !string.IsNullOrEmpty(quantityInput) ? Convert.ToInt32(quantityInput) : (int?)null;

            inventory.EditProduct(name, newName, newPrice, newCurrency, newQuantity);
        }
    }
}
