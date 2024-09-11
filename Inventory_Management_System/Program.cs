using Inventory_Management_System.Utility;

namespace Inventory_Management_System;
    internal class Program
    {
        static void Main(string[] args)
        {
            Utilities.InitializeStock();
            Utilities.ShowMainMenu();
        }
    }

