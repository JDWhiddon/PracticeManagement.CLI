using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.CLI.Models
{
    public class Client
    {
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public string IsActive { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\n Name: {Name}\n Open Date: {OpenDate}\n Notes: {Notes}";
        }

    }
}
