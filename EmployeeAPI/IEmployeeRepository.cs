using EmployeeAPI.Models;

namespace EmployeeAPI
{
    public interface IEmployeeRepository
    {
        public Task<Employee> GetEmployeeById(int Id);
        public Task<List<Employee>> GetAllEmployees();
        public Task<Employee> SaveEmployee(Employee obj);
        public Task<Employee> UpdateEmployee(int Id, Employee obj);
        public Task<int> DeleteEmployee(int Id);
    }
}
