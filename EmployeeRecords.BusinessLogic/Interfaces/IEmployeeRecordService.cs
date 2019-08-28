using EmployeeRecords.Models;
using System.Collections.Generic;

namespace EmployeeRecords.BusinessLogic.Interfaces
{
    public interface IEmployeeRecordService
    {
        void Add(Employee employee);
        void Update(Employee employee);
        void Remove(Employee employee);
        IEnumerable<Employee> GetAll();
    }
}
