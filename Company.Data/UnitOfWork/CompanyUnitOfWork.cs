using Company.Data.Implementation;
using Company.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Data.UnitOfWork
{
    public class CompanyUnitOfWork : IUnitOfWork
    {
        private CompanyContext context;

        public CompanyUnitOfWork(CompanyContext context)
        {
            this.context = context;
            Employee = new RepositoryEmployee(context);
            Department = new RepositoryDepartment(context);
            Task = new RepositoryTask(context);
        }

        public IRepositoryEmployee Employee { get; set; }
        public IRepositoryDepartment Department { get; set; }
        public IRepositoryTask Task { get; set; }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
