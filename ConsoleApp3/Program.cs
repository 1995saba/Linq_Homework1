using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Model1 m = new Model1();

            // Task 1
            int minAge, maxAge;
            int daysInYear = 365;

            Console.WriteLine("Введите минимальный возраст:");
            string minAgeAsString = Console.ReadLine();
            bool resMin = Int32.TryParse(minAgeAsString, out minAge);

            Console.WriteLine("Введите максимальный возраст:");
            string maxAgeAsString = Console.ReadLine();
            bool resMax = Int32.TryParse(maxAgeAsString, out maxAge);

            var allEmployees = m.Employees.ToList();

            var employeesByAge = allEmployees
                    .Where(p => ((DateTime.Now - p.BirthDate)
                                    .Value.Days / daysInYear) >= minAge
                             && ((DateTime.Now - p.BirthDate)
                                    .Value.Days / daysInYear) <= maxAge)
                    .Select(p => new { p.EmployeeID, p.FirstName, p.LastName });

            foreach (var item in employeesByAge)
            {
                Console.WriteLine(item);
            }

            // Task 2
            var allCountries = allEmployees
                .Select(p => p.Country).Distinct();

            foreach (var item in allCountries)
            {
                Console.WriteLine(item);
                var employeesByCountries = allEmployees
                            .Where(p => p.Country == item)
                            .Select(p => new { p.FirstName, p.LastName });

                foreach (var employee in employeesByCountries)
                {
                    Console.WriteLine(employee);
                }
            }

            // Task 3
            foreach (var employee in allEmployees)
            {
                Console.WriteLine(employee.FirstName + ' ' + employee.LastName);
                Console.WriteLine("Supervisor:");

                var supervisor = allEmployees
                            .Where(p => p.EmployeeID == employee.ReportsTo)
                            .Select(p => new { p.FirstName, p.LastName });

                foreach (var item in supervisor)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Subordinate:");
                var subordinates = allEmployees
                            .Where(p => p.ReportsTo == employee.EmployeeID)
                            .Select(p => new { p.FirstName, p.LastName });

                foreach (var item in subordinates)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();
            }

            // Task 5
            var allProducts = m.Products.ToList();

            var unitsInStock = allProducts
                .Select(p => p.UnitsInStock)
                .Distinct();

            foreach (var item in unitsInStock)
            {
                Console.WriteLine(item);
                var productsByQuantities = allProducts
                            .Where(p => p.UnitsInStock == item)
                            .Select(p => new { p.ProductName});

                foreach (var product in productsByQuantities)
                {
                    Console.WriteLine(product);
                }
                Console.WriteLine();
            }

            Console.ReadLine();

        }
    }
}
