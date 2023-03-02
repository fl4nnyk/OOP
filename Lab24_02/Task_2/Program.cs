using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_2
{
    class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int Experience { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "John", Salary = 50000, Experience = 3 },
            new Employee { Name = "Jane", Salary = 60000, Experience = 5 },
            new Employee { Name = "Bob", Salary = 45000, Experience = 2 },
            new Employee { Name = "Alice", Salary = 55000, Experience = 4 }
        };

            var sortedBySalary = employees.OrderBy(e => e.Salary);

            Console.WriteLine("Сортування за зарплатою:");
            foreach (var employee in sortedBySalary)
            {
                Console.WriteLine("{0} - {1:C}", employee.Name, employee.Salary);
            }

            var sortedByExperience = employees.OrderByDescending(e => e.Experience);

            Console.WriteLine("Сортування за досвідом роботи:");
            foreach (var employee in sortedByExperience)
            {
                Console.WriteLine("{0} - {1} років", employee.Name, employee.Experience);
            }
        }
    }

}
