using System;
using System.Linq;
using EmployeeRecords.BusinessLogic.Services;
using EmployeeRecords.DataAccess;
using EmployeeRecords.Interfaces;
using EmployeeRecords.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace EmployeeRecords.UnitTest.Services
{
    [TestClass]
    public class EmployeeRecordsServiceTest
    {
        private Employee _employee;
        private DbContextOptions<EmployeeContext> _options;
        private EmployeeContext _context;
        private EmployeeUnitOfWork _myUnitOfWork;
        private IRepository<Employee> _myRepo;
        private EmployeeRecordsService _service;
        [TestInitialize]
        public void TestInit()
        {
            _employee = new Employee()
            {
                DateCreated = DateTime.Now,
                FirstName = "Mitra",
                LastName = "Ghorpade"
            };
            _options = new DbContextOptionsBuilder<EmployeeContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            _context = new EmployeeContext(_options);
            _myUnitOfWork = new EmployeeUnitOfWork(_context);
            _myRepo = new GenericRepository<Employee>(_context);
            _service = new EmployeeRecordsService(_myRepo, _myUnitOfWork);
        }


        [TestMethod]
        public void Add_writes_to_database()
        {
            _service.Add(_employee);
            _context.SaveChanges();

            const int expectedCount = 1;
            using (var context = new EmployeeContext(_options))
            {
                Assert.AreEqual(expectedCount, context.Employees.Count());
            }
        }

        [TestMethod]
        public void Find_records_in_database()
        {
            _service.Add(_employee);
            _context.SaveChanges();

            var employeeRecord = _service.GetAll().FirstOrDefault(q => q.FirstName == _employee.FirstName);

            Assert.IsNotNull(employeeRecord);
        }
    }
}
