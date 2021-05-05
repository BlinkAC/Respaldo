using Respaldo.DTOs;
using Respaldo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Respaldo.Services
{
    public class CustomersS : DBS
    {
        public IQueryable<Customer> GetAllCustomers()
        {
            return dataContext.Customers.Select(s => s);
            
        }

        public Customer GetCustomerId(string id)
        {
            return GetAllCustomers().Where(w => w.CustomerId == id).FirstOrDefault();
        }

        public void AddCustomer(CustomerDto newCustomer)
        {
            var newC = new Customer()
            {
                CompanyName = newCustomer.Company,
                ContactName = newCustomer.Contact,
                City = newCustomer.Location1
            };

            dataContext.Customers.Add(newC);
            dataContext.SaveChanges();
        }

        public void UpdateCustomerName(string id,string name)
        {
            var Customer = GetAllCustomers().Where(w => w.CustomerId == id).FirstOrDefault();
            if (Customer != null)
            {
              Customer.ContactName = name;
             dataContext.SaveChanges();
            }
        }

        public void DeleteCustomer(string id)
        {
            var Cus = GetCustomerId(id);
            dataContext.Customers.Remove(Cus);
            dataContext.SaveChanges();
        }
    }
}
