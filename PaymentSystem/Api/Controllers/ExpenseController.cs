using MediatR;
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
    public async Task<ApiResponse<ExpenseResponse>> Post([FromBody] ExpenseRequest Expense)
    {
        var operation = new CreateExpenseCommand(Expense);
        var result = await mediator.Send(operation);
        return result;
    }
}
