using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket
{
    public class Customer : Person
    {
        int money;
        public List<string> shoppingCart = new List<string>();
        public List<int> shoppingCartValue = new List<int>();

        public int Money
        {
            get => money;
            set
            {
                if (value > 0) money = value;
                else money = 0;
            }
        }

        public Customer()
        {
            Money = 20;
        }
        public Customer(string name, int age,int money):base(name,age)
        {
            Money = money;
        }
        public Customer(string name,string surname,int age,string pesel,int money):base(name, surname, age, pesel)
        {
            Money = money;
        }
        public bool Buy(List<Product> product)
        {
            Console.WriteLine($"Witaj {Name}");          
            Console.WriteLine($"Wybierz przedmiot do kupienia(1-{product.Count})");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                if (product[choice - 1].age > Age)
                {
                    Console.WriteLine("Za mlody/a jestes zeby to kupic");
                    return false;
                }
                else
                {
                    shoppingCart.Add(product[choice - 1].name);
                    shoppingCartValue.Add(product[choice - 1].price);
                    return true;
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Nie ma takiego produktu");
                return true;
            }
            
        }

        public void DisplayShoppingCart()
        {
            if(shoppingCart.Count == 0)
            {
                Console.WriteLine("Koszyk jest pusty");
            } else
            {
                foreach (var item in shoppingCart)
                {
                    Console.WriteLine($"{item}");
                }
            }
        }

        public bool Checkout(Shopkeeper shopkeeper)
        {
            int total = 0;
            if (shoppingCart.Count == 0)
            { 
                Console.WriteLine("Nie ma za co placic :)");
                return true;
            }
            else
            {
                foreach (var item in shoppingCartValue)
                {
                    total += item;
                }
                Console.WriteLine($"Zakupy wyniosly cie {total}zl");

                if (Money < total) 
                { 
                    Console.WriteLine($"Bez kasy jestes ? nara");
                    return false;
                }
                else
                {
                    Money -= total;
                    Console.WriteLine($"Dziekujemy za zakupy zapraszamy ponownie");
                    shopkeeper.customersToday++;
                    shoppingCart.Clear();
                    shoppingCartValue.Clear();
                    return true;
                }
            }

        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Stan twoich pieniedzy: {Money}");
        }

    }
}
