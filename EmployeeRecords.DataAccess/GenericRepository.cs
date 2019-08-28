using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EmployeeRecords.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecords.DataAccess
{
    public class GenericRepository<T> : IRepository<T> where T: class
    {
        private readonly DbContext _context;
        private DbSet<T> DbSet => _context.Set<T>();
        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
             DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<T> GetQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}
