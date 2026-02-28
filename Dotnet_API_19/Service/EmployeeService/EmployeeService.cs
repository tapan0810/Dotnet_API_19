using Dotnet_API_19.Data;
using Dotnet_API_19.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_API_19.Service.EmployeeService
{
    public class EmployeeService(EmployeeDbContext _context) : IEmployeeService
    {
        public async Task<List<GetAllEmployeesDto>> GetAllEmployees(int pageNumber, int pageSize)
        {
            var employees = await _context.Employees
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(s => new GetAllEmployeesDto
                    {
                        EmployeeName = s.EmployeeName,
                        Department = s.Department,
                        Aage = s.Aage,
                        isActive = s.isActive
                    }).ToListAsync();

            if(employees is null || employees.Count == 0)
            {
                return null;
            }
            return employees;

        }
    }
}
