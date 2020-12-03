using Company.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Data.Implementation
{
    public class RepositoryDepartment : IRepositoryDepartment
    {
        private CompanyContext context;

        public RepositoryDepartment(CompanyContext context)
        {
            this.context = context;
        }
        public void Add(Department d)
        {
            context.Departments.Add(d);
        }

        public void Delete(Department d)
        {
            context.Departments.Remove(d);
        }

        public Department FindByID(int id)
        {
            return context.Departments.Find(id);
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public void UpdateDepartment(int id, Department department)
        {
            department.DepartmentID = id;
            context.Update(department);
        }
    }
}
