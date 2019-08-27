using EmployeeRecords.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecords.DataAccess
{
    public class EmployeeUnitOfWork: IUnitOfWork
    {
        private readonly DbContext _context;

        public EmployeeUnitOfWork(DbContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
