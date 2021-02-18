using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Supermarket
{
    public class Transaction
    {
        List<Customer> customers;
        Shopkeeper shopkeeper;

        public Transaction(Shopkeeper shopkeeper, List<Customer> customers)
        {
            this.shopkeeper = shopkeeper;
            this.customers = customers;
        }

        public void CreateBill()
        {
            string filePath = @"C:\Users\User\source\repos\Supermarket\Supermarket\bill.txt";
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine($"Sprzedawca: {shopkeeper.Name}");
                sw.WriteLine($"Nabywca: {customers[0].Name}");
                sw.Write($"Zakupione produkty:");
                foreach (var item in customers[0].shoppingCart)
                {
                    sw.Write($" {item} ");
                }

                sw.WriteLine("\nO wartosci:");
                int total = 0;
                foreach (var item in customers[0].shoppingCartValue)
                {
                    total += item;
                }
                sw.WriteLine(total);
                sw.WriteLine($"Data:{DateTime.Now}");
            }              
        }
    }
}
