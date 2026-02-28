using Dotnet_API_19.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_API_19.Data
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base (options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
