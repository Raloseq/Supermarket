using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket
{
    public abstract class Person
    {
        public string Name { get; protected set; }
        protected string Surname { get; set; }
        protected int Age { get; set; }
        protected string pesel;

       public string Pesel
        {
            get => pesel;
            protected set
            {
                if (value.Length == 11) pesel = value;
            }
        }

        public Person()
        {
            Name = "Adam";
            Surname = "Kowalski";
            Age = 20;
            Pesel = "12345678912";
        }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public Person(string name, string surname, int age, string pesel)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Pesel = pesel;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Imie: {Name} Nazwisko: {Surname} Wiek: {Age} Pesel: {Pesel}");
        }
    }
}
