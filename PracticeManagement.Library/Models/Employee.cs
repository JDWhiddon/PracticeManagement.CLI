using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeManagement.CLI.Models;

namespace PracticeManagement.Library.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Rate { get; set; }
        private List<Employee>? employees { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} {Name} Rate: {Rate}";
        }
    }
}
