using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeRecords.Interfaces
{
    public interface IRepository<T> where T: class
    {
        void Add(T entity);
        IQueryable<T> GetQueryable();
        IEnumerable<T> GetAll();
    }
}
