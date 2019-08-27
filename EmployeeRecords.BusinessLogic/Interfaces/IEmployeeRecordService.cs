using EmployeeRecords.Models;
using System.Collections.Generic;

namespace EmployeeRecords.BusinessLogic.Interfaces
{
    public interface IEmployeeRecordService
    {
        void Add(Employee employee);
        IEnumerable<Employee> GetAll();
    }
}
