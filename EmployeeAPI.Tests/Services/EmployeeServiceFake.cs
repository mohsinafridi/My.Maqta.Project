using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Tests.Services
{
    public class EmployeeServiceFake //: IEmployeeRepository
    {
        private readonly List<Employee> _employees;
        public EmployeeServiceFake()
        {
            _employees = new List<Employee>()
            {
                new Employee() {
                    Id = 1,
                    FirstName = "Mohsin", 
                    LastName="Azam", 
                    Email= "mohsin.afridi91@gmail.com" ,
                    Phone = "123123123"
                },

              new Employee() {
                    Id =2,
                    FirstName = "Muhammad",
                    LastName="Ali",
                    Email= "m.ali@gmail.com" ,
                    Phone = "123123123"
                },
              new Employee() {
                    Id = 3,
                    FirstName = "Abdul",
                    LastName="Mutlib",
                    Email= "abdul.mutlib@gmail.com" ,
                    Phone = "123123123"
                }
            };
        }
        public int DeleteEmployee(int Id)
        {
            var existing = _employees.First(a => a.Id == Id);
            _employees.Remove(existing);
            return 1;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employees;
        }
        public Employee SaveEmployee(Employee obj)
        {
            Employee employeeObj = new Employee();
            employeeObj.Id = 4;
            employeeObj.FirstName = "Fake FirstName";
            employeeObj.LastName = "Fake Last Name";
            employeeObj.Email = "fahe@gmail.com";
            employeeObj.Phone = "213123123";
            _employees.Add(employeeObj);
            return employeeObj;
        }

        public Task<Employee> UpdateEmployee(int Id, Employee obj)
        {
            throw new NotImplementedException();
        }

        
    }
}
