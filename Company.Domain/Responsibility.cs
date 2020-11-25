using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Domain
{
    public class Responsibility
    {
        public int TaskID { get; set; }
        public Task Task { get; set; }
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}
