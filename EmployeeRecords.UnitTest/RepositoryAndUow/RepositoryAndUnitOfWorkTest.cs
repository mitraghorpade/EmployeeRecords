using System;
using System.Linq;
using EmployeeRecords.DataAccess;
using EmployeeRecords.Interfaces;
using EmployeeRecords.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeRecords.UnitTest.RepositoryAndUow
{
    [TestClass]
    class RepositoryAndUnitOfWorkTest
    {
        private Employee _employee1;
        private Employee _employee2;
        private DbContextOptions<EmployeeContext> _options;
        private EmployeeContext _context;
        private EmployeeUnitOfWork _myUnitOfWork;
        private IRepository<Employee> _myRepo;
        [TestInitialize]
        public void TestInit()
        {
            _employee1 = new Employee()
            {
                DateCreated = DateTime.Now,
                FirstName = "Mitra",
                LastName = "Ghorpade"
            };
            _employee2 = new Employee()
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
        }


        [TestMethod]
        public void Add_writes_to_database()
        {
            _myRepo.Add(_employee1);
            _myRepo.Add(_employee2);
            _myUnitOfWork.Save();

            const int expectedCount = 2;
            using (var context = new EmployeeContext(_options))
            {
                Assert.AreEqual(expectedCount, context.Employees.Count());
            }
        }
    }
}
