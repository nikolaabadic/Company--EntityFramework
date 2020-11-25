using System;
using System.Collections.Generic;

namespace Company.Domain
{
    public class Task
    {
        public int TaskID { get; set; }
        public string Name { get; set; }
        public List<Responsibility> Employees { get; set; }
        public override string ToString()
        {
            return $"{TaskID} {Name}";
        }
    }
}
