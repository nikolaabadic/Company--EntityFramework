using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepositoryEmployee Employee { get; set; }
        public IRepositoryDepartment Department { get; set; }
        public IRepositoryTask Task { get; set; }
        void Commit();
    }
}
