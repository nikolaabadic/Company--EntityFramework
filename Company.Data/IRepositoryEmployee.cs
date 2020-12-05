using Company.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Data
{
    public interface IRepositoryEmployee : IRepository<Employee>
    {
        public void UpdateEmployee(Employee employee);
    }
}
