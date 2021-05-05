using Respaldo.DTOs;
using Respaldo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Respaldo.Services
{
    public class EmployeeS : DBS
    {
        public IQueryable<Employee> GetAllEmployees()
        {
            return dataContext.Employees.Select(s => s);
        }

        public Employee GetEmployeeId(int id)
        {
            return GetAllEmployees().Where(w => w.EmployeeId == id).FirstOrDefault();
        }

        public void AddEmployee(EmployeeDto newEmployee)
        {
            var newEm = new Employee()
            {
                FirstName = newEmployee.Name,
                LastName = newEmployee.SecondName,
                Title = newEmployee.Position
            };

            dataContext.Employees.Add(newEm);
            dataContext.SaveChanges();
        }

        public void UpdateemployeeName(int id, string name)
        {
            var employee = GetAllEmployees().Where(w => w.EmployeeId == id).FirstOrDefault();
            if (employee != null)
            {
                employee.FirstName = name;
                dataContext.SaveChanges();
            }
        }
        public void DeleteEmployee(int id)
        {
            var emp = GetEmployeeId(id);
            dataContext.Employees.Remove(emp);
            dataContext.SaveChanges();
        }
    }
}
