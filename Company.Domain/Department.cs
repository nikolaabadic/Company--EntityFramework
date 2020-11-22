using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Domain
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{DepartmentID} {Name}";
        }
    }
}
