using Respaldo.DTOs;
using Respaldo.Models;
using Respaldo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Respaldo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        new EmployeeS emp = new EmployeeS();
        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Employee> GetEmployees()
        {
            var employee = emp.GetAllEmployees().Select(s => new Employee
            {
                EmployeeId = s.EmployeeId,
                FirstName = s.FirstName,
                Address = s.Address
            }).ToList();
            return employee;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = emp.GetEmployeeId(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult PostEmployee([FromBody] EmployeeDto newEmployee)
        {
            emp.AddEmployee(newEmployee);
            return Ok();

        }
        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, string name)
        {
            emp.UpdateemployeeName(id, name);
            return Ok();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            emp.DeleteEmployee(id);
            return Ok();
        }
    }
}
