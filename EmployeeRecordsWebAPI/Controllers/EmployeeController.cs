using System;
using EmployeeRecords.BusinessLogic.Interfaces;
using EmployeeRecords.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Post([FromBody] Employee employeeInfo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400);
                }

                _employeeRecordService.Add(employeeInfo);

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
