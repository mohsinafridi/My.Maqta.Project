using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Db
{
    public class EmployeeContext:DbContext
    {
       
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
               : base(options)
        {
        }
        public DbSet<Employee> Employees{ get; set; }
    }
}
