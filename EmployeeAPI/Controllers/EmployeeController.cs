using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            return Ok(await _employeeRepository.GetAllEmployees());
        }
        
          [HttpGet("{Id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int Id)
        {
            var employeeObj =await _employeeRepository.GetEmployeeById(Id);
            if (employeeObj is null)
                return NotFound();

            return Ok(employeeObj);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> SaveEmployee([FromBody] Employee Obj)
        {
            return await _employeeRepository.SaveEmployee(Obj);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteEmployee(int Id)
        {
            var returnId = await _employeeRepository.DeleteEmployee(Id);
            if (returnId == 0)
                return NotFound();

            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<Employee>> UpdateEmployee([FromBody] Employee Obj)
        {
            return await _employeeRepository.UpdateEmployee(Obj.Id,Obj);
        }

    }
}
