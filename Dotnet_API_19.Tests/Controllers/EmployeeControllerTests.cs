using Dotnet_API_19.Controllers;
using Dotnet_API_19.Entities.Dtos;
using Dotnet_API_19.Service.EmployeeService;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Dotnet_API_19.Tests.Controllers;

[TestFixture]
public sealed class EmployeeControllerTests
{
    private Mock<IEmployeeService> _service = null!;
    private EmployeeController _controller = null!;

    [SetUp]
    public void SetUp()
    {
        _service = new Mock<IEmployeeService>();
        _controller = new EmployeeController(_service.Object);
    }

    [Test]
    public async Task GetAllEmployee_WhenNoEmployees_ReturnsNotFound()
    {
        _service.Setup(x => x.GetAllEmployees(1, 10)).ReturnsAsync([]);

        var result = await _controller.GetAllEmployee(1, 10);

        Assert.That(result.Result, Is.TypeOf<NotFoundObjectResult>());
    }

    [Test]
    public async Task GetAllEmployee_WhenEmployeesExist_ReturnsOk()
    {
        var employees = new List<GetAllEmployeesDto> { new() };
        _service.Setup(x => x.GetAllEmployees(1, 10)).ReturnsAsync(employees);

        var result = await _controller.GetAllEmployee(1, 10);

        Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
        var ok = (OkObjectResult)result.Result!;
        Assert.That(ok.Value, Is.SameAs(employees));
    }
}
