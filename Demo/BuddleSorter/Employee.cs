using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Employee
    {
        public Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return string.Format($"{Name},{Salary:C}");
        }

        public static bool CompareSalary(Employee e1, Employee e2)
        {
            return e1.Salary < e2.Salary;
        }
    }

    /*
     Employee[] employees =
            {
                new Employee("Bugs Bunny",20000),
                new Employee("Elmer Fudd",10000),
                new Employee("Daffy",25000),
                new Employee("Wile",100000.38m),
                new Employee("Forhorn",23000),
                new Employee("Road Runner",50000)  
            };
            BuddleSorter.Sort(employees,Employee.CompareSalary);
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
     */
}
