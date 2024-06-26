using System;
using System.Threading.Tasks;

namespace ItemConsoleApp
{
    public class SalesMenu
    {
        private readonly SalesService _salesService;

        public SalesMenu()
        {
            _salesService = new SalesService();
        }

        public void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Manage Sales");
            Console.WriteLine("2. Exit");
            Console.WriteLine("Choose an option:");
        }

        public async Task ManageSales()
        {
            Console.WriteLine("1. Get All Sales");
            Console.WriteLine("2. Add New Sale");
            Console.WriteLine("3. Update Sale");
            Console.WriteLine("4. Delete Sale");
            Console.WriteLine("Choose an option:");

            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    await DisplayAllSales();
                    break;
                case "2":
                    await AddNewSale();
                    break;
                case "3":
                    await UpdateSale();
                    break;
                case "4":
                    await DeleteSale();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }

        private async Task DisplayAllSales()
        {
            var sales = await _salesService.GetSalesAsync();
            foreach (var sale in sales)
            {
                Console.WriteLine($"ItemCode: {sale.ItemCode}, Quantity: {sale.Quantity}, SaleDate: {sale.SaleDate}");
            }
        }

        private async Task AddNewSale()
        {
            Console.WriteLine("Enter Item Code:");
            var itemCode = Console.ReadLine();
            Console.WriteLine("Enter Quantity:");
            var quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Sale Date (yyyy-mm-dd):");
            var saleDate = DateTime.Parse(Console.ReadLine());

            var sale = new Sale { ItemCode = itemCode, Quantity = quantity, SaleDate = saleDate };
            var isSuccess = await _salesService.AddSaleAsync(sale);

            if (isSuccess)
                Console.WriteLine("Sale added successfully.");
            else
                Console.WriteLine("Failed to add sale. Please try again.");
        }

        private async Task UpdateSale()
        {
            Console.WriteLine("Enter Item Code to update:");
            var itemCode = Console.ReadLine();
            Console.WriteLine("Enter new Quantity:");
            var quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Sale Date (yyyy-mm-dd):");
            var saleDate = DateTime.Parse(Console.ReadLine());

            var sale = new Sale { ItemCode = itemCode, Quantity = quantity, SaleDate = saleDate };
            var isSuccess = await _salesService.UpdateSaleAsync(itemCode, sale);

            if (isSuccess)
                Console.WriteLine("Sale updated successfully.");
            else
                Console.WriteLine($"Failed to update sale with Item Code: {itemCode}. Please try again.");
        }

        private async Task DeleteSale()
        {
            Console.WriteLine("Enter Item Code to delete:");
            var itemCode = Console.ReadLine();
            var isSuccess = await _salesService.DeleteSaleAsync(itemCode);

            if (isSuccess)
                Console.WriteLine("Sale deleted successfully.");
            else
                Console.WriteLine($"Failed to delete sale with Item Code: {itemCode}. Please try again.");
        }
    }
}
