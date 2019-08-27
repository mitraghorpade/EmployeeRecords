using System.Collections.Generic;
using EmployeeRecords.BusinessLogic.Interfaces;
using EmployeeRecords.Interfaces;
using EmployeeRecords.Models;

namespace EmployeeRecords.BusinessLogic.Services
{
    public class EmployeeRecordsService : IEmployeeRecordService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IUnitOfWork _employeeUnitOfWork;

        public EmployeeRecordsService(IRepository<Employee> employeeRepository, IUnitOfWork employeeUnitOfWork)
        {
            _employeeRepository = employeeRepository;
            _employeeUnitOfWork = employeeUnitOfWork;
        }
        public void Add(Employee employee)
        {
            _employeeRepository.Add(employee);
            _employeeUnitOfWork.Save();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }
    }
}
