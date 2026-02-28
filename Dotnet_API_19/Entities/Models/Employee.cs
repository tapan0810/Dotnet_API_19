namespace Dotnet_API_19.Entities.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Aage { get; set; } = string.Empty;
        public bool isActive { get; set; } = true;
    }
}
