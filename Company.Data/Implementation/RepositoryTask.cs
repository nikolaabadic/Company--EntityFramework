using Company.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Data.Implementation
{
    public  class RepositoryTask : IRepositoryTask
    {
        private CompanyContext context;

        public RepositoryTask(CompanyContext context)
        {
            this.context = context;
        }
        public void Add(Task t)
        {
            context.Tasks.Add(t);
        }

        public void Delete(Task t)
        {
            context.Tasks.Remove(t);
        }

        public Task FindByID(int id)
        {
            return context.Tasks.Find(id);
        }

        public List<Task> GetAll()
        {
            return context.Tasks.ToList();
        }
    }
}
