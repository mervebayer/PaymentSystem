using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Base.Enum;
using PaymentSystem.Base.Response;
using PaymentSystem.Business.Cqrs;
using PaymentSystem.Schema;

namespace PaymentSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeExpenseController : ControllerBase
{
    private readonly IMediator mediator;

    public EmployeeExpenseController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = "Employee")]
    public async Task<ApiResponse<EmployeeExpenseResponse>> Post([FromBody] EmployeeExpenseRequest expense)
    {
        string id = (User.Identity as ClaimsIdentity).FindFirst("Id")?.Value;
        expense.UserId = int.Parse(id);
        var operation = new CreateEmployeeExpenseCommand(expense);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Employee")]
    public async Task<ApiResponse> Put(int id, [FromBody] EmployeeExpenseRequest expense)
    {
        string userId = (User.Identity as ClaimsIdentity).FindFirst("Id")?.Value;
        expense.UserId = int.Parse(userId);
        var operation = new UpdateEmployeeExpenseCommand(id, expense);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Employee")]
    public async Task<ApiResponse> Delete(int id)
    {
        string userId = (User.Identity as ClaimsIdentity).FindFirst("Id")?.Value;
        var operation = new DeleteEmployeeExpenseCommand(id, int.Parse(userId));
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet]
    [Authorize(Roles = "Employee")]
    public async Task<ApiResponse<List<EmployeeExpenseResponse>>> Get()
    {
        string userId = (User.Identity as ClaimsIdentity).FindFirst("Id")?.Value;
        var operation = new GetAllEmployeeExpenseQuery(int.Parse(userId));
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Employee")]
    public async Task<ApiResponse<EmployeeExpenseResponse>> Get(int id)
    {
        string userId = (User.Identity as ClaimsIdentity).FindFirst("Id")?.Value;
        var operation = new GetEmployeeExpenseByIdQuery(int.Parse(userId), id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("ByParameters")]
    [Authorize(Roles = "Employee")]
    public async Task<ApiResponse<List<EmployeeExpenseResponse>>> GetByParameter(
        [FromQuery] StatusEnum Status,
        [FromQuery] string? Location,
        [FromQuery] DateTime expenseDate,
        [FromQuery] DateTime requestDate)
    {
        string userId = (User.Identity as ClaimsIdentity).FindFirst("Id")?.Value;
        var operation = new GetEmployeeExpenseByParameterQuery(Status,Location,expenseDate,requestDate, int.Parse(userId));
        var result = await mediator.Send(operation);
        return result;
    }
}
