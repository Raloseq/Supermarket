using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket
{
    public class Boss : Employee
    {
        public string mood;
        
        public Boss(string name, int age,decimal salary,string mood):base(name,age,salary)
        {
            Salary = salary;
            this.mood = mood;
        }

        public void ChangeMood(string mood)
        {
            this.mood = mood;
        }

        public override void DisplayEmployeeInfo()
        {
            Console.WriteLine($"Nastoj szefa {mood}");
        }
    }
}
