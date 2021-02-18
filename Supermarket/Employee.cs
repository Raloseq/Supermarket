using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Supermarket
{
    public abstract class Employee : Person
    {
        public decimal Salary { get; set; }
        public Employee():base()
        {

        }
        public Employee(string name, int age, decimal salary): base(name,age)
        {
            Salary = salary;
        }
        public Employee(string name,string surname,int age, string pesel, decimal salary):base(name,surname,age,pesel)
        {
            Salary = salary;
        }

        public abstract void DisplayEmployeeInfo();
    }
}
