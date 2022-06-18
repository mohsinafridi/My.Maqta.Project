using EmployeeAPI.Db;
using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;
        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }
        public async Task<int> DeleteEmployee(int employeeId)
        {
            var employeeObj = await _context.Employees.SingleOrDefaultAsync(d => d.Id == employeeId);
            if (employeeObj != null)
            {
                _context.Employees.Remove(employeeObj);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int Id)
        {
            var obj = await _context.Employees.SingleOrDefaultAsync(e => e.Id == Id);
            if (obj != null)
                return obj;

            return obj;
        }

        public async Task<Employee> SaveEmployee(Employee obj)
        {
            Employee employeeObj = new Employee();
            employeeObj = new Employee();
            employeeObj.FirstName = obj.FirstName;
            employeeObj.LastName = obj.LastName;
            employeeObj.Email = obj.Email;
            employeeObj.Phone = obj.Phone;

            _context.Employees.Add(employeeObj);
            await _context.SaveChangesAsync();

            return employeeObj;
        }

        public async Task<Employee> UpdateEmployee(int employeeId, Employee obj)
        {
            var employeeObj = await _context.Employees.SingleOrDefaultAsync(x => x.Id == employeeId);
            if (employeeObj != null)
            {
                employeeObj.FirstName = obj.FirstName;
                employeeObj.LastName = obj.LastName;
                employeeObj.Email = obj.Email;
                employeeObj.Phone = obj.Phone;

                _context.Employees.Update(employeeObj);
                await _context.SaveChangesAsync();
            }
            return employeeObj;
        }


    }
}
