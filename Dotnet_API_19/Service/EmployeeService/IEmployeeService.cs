using Dotnet_API_19.Entities.Dtos;

namespace Dotnet_API_19.Service.EmployeeService
{
    public interface IEmployeeService
    {
        public Task<List<GetAllEmployeesDto>> GetAllEmployees(int pageNumber,int pageSize);
    }
}
