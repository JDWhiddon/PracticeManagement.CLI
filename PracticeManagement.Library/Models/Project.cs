﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticeManagement.CLI.Models
{
    public class Project
    {
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public bool IsActive { get; set; }
        public string? ShortName { get; set; }
        public string? LongName { get; set; }
        public int ClientId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} - {LongName}\n Open: {IsActive}";
        }
    }
}
