using System;
using System.Linq;
using EmployeeRecords.BusinessLogic.Interfaces;
using EmployeeRecords.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace EmployeeRecordsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRecordService _employeeRecordService;

        public EmployeeController(IEmployeeRecordService employeeRecordService)
        {
            _employeeRecordService = employeeRecordService;
        }
        
        /// <summary>
        /// Get the list of employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var allEmployees = _employeeRecordService.GetAll();
                return Ok(allEmployees);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }
        
        /// <summary>
        /// Add another employee in the database
        /// </summary>
        /// <param name="employeeInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] EmployeeForInsertingData employeeInfo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400);
                }

                var employee = new Employee()
                {
                    FirstName = employeeInfo.FirstName,
                    LastName = employeeInfo.LastName,
                    DateCreated = DateTime.Now
                };
                _employeeRecordService.Add(employee);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Method for updating entries in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeInfo"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmployeeForInsertingData employeeInfo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400);
                }

                var existingEmployee = _employeeRecordService.GetAll().FirstOrDefault(q => q.Id == id);
                if (existingEmployee == null) return NotFound();

                existingEmployee.FirstName = employeeInfo.FirstName;
                existingEmployee.LastName = employeeInfo.LastName;
                existingEmployee.DateCreated = DateTime.Now;
                _employeeRecordService.Update(existingEmployee);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }



        [HttpDelete]
        public IActionResult Delete([FromBody] Employee employeeInfo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400);
                }

                _employeeRecordService.Remove(employeeInfo);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }
    }
}
