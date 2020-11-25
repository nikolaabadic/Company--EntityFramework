using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Data
{
    public interface IRepository<T>
    {
        void Add(T e);
        List<T> GetAll();
        T FindByID(int id);
        void Delete(T e);
    }
}
