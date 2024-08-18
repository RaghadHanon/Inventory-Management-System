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
                Console.WriteLine("---------------------- Inventory Management System ----------------------");


                Console.WriteLine("1. Add a product");
                Console.WriteLine("2. View all products");
                Console.Write("Please select an option (1 - 2): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        ViewAllProducts();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.\n");
                        break;
                }
            } while (!exit);
        }
        static void AddProduct()
        {
            ViewAllProducts();
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
    }
}
