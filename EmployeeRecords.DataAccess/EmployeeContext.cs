using System;
using EmployeeRecords.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecords.DataAccess
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) :
            base(options)
        {

        }

        public virtual DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee {Id=1, FirstName = "Carson", LastName = "Alexander", DateTimeCreated = DateTime.Parse("2005-09-01") },
                new Employee {Id=2, FirstName = "Meredith", LastName = "Alonso", DateTimeCreated = DateTime.Parse("2002-09-01") },
                new Employee {Id=3, FirstName = "Arturo", LastName = "Anand", DateTimeCreated = DateTime.Parse("2003-09-01") },
                new Employee {Id=4, FirstName = "Gytis", LastName = "Barzdukas", DateTimeCreated = DateTime.Parse("2002-09-01") },
                new Employee {Id=5, FirstName = "Yan", LastName = "Li", DateTimeCreated = DateTime.Parse("2002-09-01") },
                new Employee {Id=6, FirstName = "Peggy", LastName = "Justice", DateTimeCreated = DateTime.Parse("2001-09-01") },
                new Employee {Id=7, FirstName = "Laura", LastName = "Norman", DateTimeCreated = DateTime.Parse("2003-09-01") },
                new Employee {Id=8, FirstName = "Nino", LastName = "Olivetto", DateTimeCreated = DateTime.Parse("2005-09-01") }
                );
        }
    }
}
