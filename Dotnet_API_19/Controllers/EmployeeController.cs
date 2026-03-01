using Dotnet_API_19.Entities.Dtos;
using Dotnet_API_19.Service.EmployeeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_API_19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeService _employee) : ControllerBase
    {
        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult<List<GetAllEmployeesDto>>> GetAllEmployee(int pageNumber,int pageSize)
        {
            var employees = await _employee.GetAllEmployees(pageNumber, pageSize);
            if (employees == null || employees.Count == 0)
            {
                return NotFound("No employees found.");
            }
            return Ok(employees);
        }
    }
}
