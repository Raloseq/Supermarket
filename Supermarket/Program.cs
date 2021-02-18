using MenuLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            //Customer customer1 = new Customer("Adam", "Kowalski", 12, "12345678912",300);
            Boss boss = new Boss("Janek",40,5000,"nice");
            Shopkeeper shopkeeper1 = new Shopkeeper("Rafal", "Kowal", 21, "12345678954", 3000, boss);
            List<Product> products = new List<Product>();
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer("Adam", "Kowalski", 12, "12345678912", 300));
            customers.Add(new Customer("Rafal", "Kowalski", 12, "12345678912", 300));
            customers.Add(new Customer("Rafal", "Kowalski", 12, "12345678912", 300));
            string filePath = @"C:\Users\User\source\repos\Supermarket\Supermarket\Products.txt";
            Transaction trans = new Transaction(shopkeeper1, customers);
            FillData(products, filePath);

            Menu mainMenu = new Menu(new string[] {
            "Sprawdz kto dzisiaj pracuje(Boss)",
            "Dodaj przedmiot(Pracownik)",
            "Wyswietl przedmioty(Pracownik)",
            "Sprawdz czy jestes w stanie dostac podwyzke(Pracownik)",
            "Kup przedmioty(Klient)",
            "Wyswietl koszyk(Klient)",
            "Zaplac(Klient)",
            "Wyswietl ilosc pieniedzy",
            "Nastepny klient",
            "Zapisz dodanie produktow"});

            int task;
            do
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                task = mainMenu.Display();
                switch (task)
                {
                    case 0:
                        shopkeeper1.DisplayEmployeeInfo();
                        Console.ReadKey();
                        break;
                    case 1:
                        shopkeeper1.AddItem(filePath);
                        FillData(products, filePath);
                        Console.ReadKey();
                        break;
                    case 2:
                        DisplayData(products);
                        Console.ReadKey();
                        break;
                    case 3:
                        shopkeeper1.Rise();
                        Console.ReadKey();
                        break;
                    case 4:
                        DisplayData(products);
                        customers[0].Buy(products);
                        Console.ReadKey();
                        break;
                    case 5:
                        customers[0].DisplayShoppingCart();
                        Console.ReadKey();
                        break;
                    case 6:
                        trans.CreateBill();
                        customers[0].Checkout(shopkeeper1);
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.WriteLine($"Zostalo ci: {customers[0].Money}");
                        Console.ReadKey();
                        break;
                    case 8:
                        Console.WriteLine("Nastepny !");
                        try
                        {
                            customers.RemoveAt(0);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Nikogo juz nie ma sprawdz czy dostaniesz podwyzke ;)");
                        }
                        task = mainMenu.Display();
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            } while (task >= 0 && task != 9);



            Console.ReadKey();
        }
        static void FillData(List<Product> list, string filePath)
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (var item in lines)
            {
                string[] entries = item.Split(';');
                Product newProduct = new Product();
                newProduct.name = entries[0];
                newProduct.price = Convert.ToInt32(entries[1]);
                newProduct.age = Convert.ToInt32(entries[2]);
                list.Add(newProduct);
            }
        }

        static void DisplayData(List<Product> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"Nazwa: {item.name} Cena: {item.price}");
            }
        }

    }

}
