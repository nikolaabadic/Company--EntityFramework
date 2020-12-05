using Company.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Data.Implementation
{
    public class RepositoryEmployee : IRepositoryEmployee
    {
        private CompanyContext context;

        public RepositoryEmployee(CompanyContext context)
        {
            this.context = context;
        }
        public void Add(Employee e)
        {
            context.Employees.Add(e);
        }

        public void Delete(Employee e)
        {
            context.Employees.Remove(e);
        }

        public Employee FindByID(int id)
        {
            return context.Employees.Find(id);
        }

        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }
        public void UpdateEmployee(Employee employee)
        {
            context.Update(employee);
        }
    }
}
