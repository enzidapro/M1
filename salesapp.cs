using System;

namespace ItemConsoleApp
{
    public class SalesApp
    {
        private readonly SalesMenu _salesMenu;

        public SalesApp()
        {
            _salesMenu = new SalesMenu();
        }

        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===========================================");
            Console.WriteLine("      Welcome to Sales Management System    ");
            Console.WriteLine("===========================================");
            Console.ResetColor();

            while (true)
            {
                _salesMenu.DisplayMenu();
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        _salesMenu.ManageSales();
                        break;
                    case "2":
                        Console.WriteLine("Exiting application...");
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}
