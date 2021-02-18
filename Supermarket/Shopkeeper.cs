using System;
using System.IO;

namespace Supermarket
{
    public class Shopkeeper : Employee
    {
        public int customersToday;
        Boss boss;
        public Shopkeeper()
        {

        }
        public Shopkeeper(string name, string surname, int age, string pesel, decimal salary, Boss boss) : base(name, surname, age, pesel, salary)
        {
            this.boss = boss;
            customersToday = 0;
            Salary = salary;
        }

        public void AddItem(string filePath)
        {
            Console.WriteLine("nazwa;cena;wiek(18/0)");
            string item = Console.ReadLine();
            File.AppendAllText(filePath, item + Environment.NewLine);
        }

        public void Rise()
        {
            if (customersToday > 1 && boss.mood == "nice")
            {
                Console.WriteLine("Oho szef ma dobry humor bedzie podwyzka");
                Salary += 100;
            }
            else if (boss.mood == "nice" && customersToday < 2)
            {
                Console.WriteLine("Szef ma dobry humor trzeba tylko odbebnic klientow");
            }
            else
            {
                Console.WriteLine("Nici z podwyzki szef jest wkur****");
            }
        }

        public override void DisplayEmployeeInfo()
        {
            Console.WriteLine($"Dzisiaj sprzedaje : {Name}");
            Console.WriteLine($"Klientow dzisiaj : {customersToday}");
            Console.WriteLine($"Placa : {Salary}");
        }
    }
}
