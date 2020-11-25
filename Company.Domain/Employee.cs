using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Domain
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public List<Payment> Payments { get; set; }
        public List<Responsibility> Tasks { get; set; }
        public override string ToString()
        {
            return $"{EmployeeID} {Name} {Lastname} {Department.Name}";
        }
    }
}
