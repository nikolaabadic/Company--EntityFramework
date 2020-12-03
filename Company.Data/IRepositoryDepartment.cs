using Company.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Data
{
    public interface IRepositoryDepartment : IRepository<Department>
    {
        public void UpdateDepartment(int id, Department department);
    }
}
