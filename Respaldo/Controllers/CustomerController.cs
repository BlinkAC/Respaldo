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
    public class CustomerController : ControllerBase
    {
        new CustomersS cus = new CustomersS();
        // GET: api/<CustomerController>
        [HttpGet]
        public List<Customer> GetCustomer()
        {
            var customer = cus.GetAllCustomers().Select(s => new Customer
            {
                CustomerId = s.CustomerId,
                CompanyName = s.CompanyName,
                ContactTitle = s.ContactTitle,
                Address = s.Address
            }).ToList();
            return customer;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult GetCustomer(string id)
        {
            var customer = cus.GetCustomerId(id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customer);
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult PostCustomer([FromBody] CustomerDto newCustomer)
        {
            cus.AddCustomer(newCustomer);
            return Ok();

        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, string name)
        {
            cus.UpdateCustomerName(id, name);
            return Ok();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(string id)
        {
            cus.DeleteCustomer(id);
            return Ok();
        }
    }
}
