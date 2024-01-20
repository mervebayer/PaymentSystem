using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Base.Response;
using PaymentSystem.Business.Cqrs;
using PaymentSystem.Schema;

namespace PaymentSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseController : ControllerBase
{
    private readonly IMediator mediator;

    public ExpenseController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = "Employee")]
    public async Task<ApiResponse<EmployeeExpenseResponse>> Post([FromBody] EmployeeExpenseRequest expense)
    {
        string id = (User.Identity as ClaimsIdentity).FindFirst("Id")?.Value;
        expense.UserId = int.Parse(id);
        var operation = new CreateExpenseCommand(expense);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    // [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Put(int id, [FromBody] ExpenseRequest expense)
    {
        var operation = new UpdateExpenseCommand(id, expense);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    // [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Delete(int id)
    {
        var operation = new DeleteExpenseCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}
