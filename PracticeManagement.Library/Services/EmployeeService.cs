using PracticeManagement.CLI.Models;
using PracticeManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Services
{
    public class EmployeeService
    {
        private static EmployeeService? instance;
        private static object _lock = new object();

        public static EmployeeService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new EmployeeService();
                    }
                }
                return instance;
            }
        }

        private List<Employee> listOfEmployees;

        private EmployeeService()
        {
            listOfEmployees = new List<Employee> {
                new Employee {Id = 1, Name = "Don", Rate = 100.00m},
                new Employee {Id = 2, Name = "Shaun", Rate = 115.00m},
                new Employee {Id = 3, Name = "Faun", Rate = 120.00m}
            };
        }

        public List<Employee> ListOfEmployees
        {
            get
            {
                return listOfEmployees;
            }
        }

        public List<Employee> Search(string query) => ListOfEmployees.Where(s => s.Name.ToUpper().Contains(query.ToUpper())).ToList();

        public Employee? Get(int id) => listOfEmployees.FirstOrDefault(e => e.Id == id);

        public void AddOrUpdate(Employee? employee)
        {
            if (employee.Id == 0)
            {
                //add
                employee.Id = LastId + 1;
                listOfEmployees.Add(employee);
            }
        }

        private int LastId
        {
            get
            {
                return ListOfEmployees.Any() ? ListOfEmployees.Select(c => c.Id).Max() : 1;
            }
        }

        public void Delete(int id)
        {
            var employeeToRemove = Get(id);
            if (employeeToRemove != null)
            {
                listOfEmployees.Remove(employeeToRemove);
            }
        }

        public void Read() => listOfEmployees.ForEach(Console.WriteLine);
    }
}
