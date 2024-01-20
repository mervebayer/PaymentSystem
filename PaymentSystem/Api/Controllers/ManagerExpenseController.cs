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
public class ManagerExpenseController : ControllerBase
{
    private readonly IMediator mediator;

    public ManagerExpenseController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpPut("{id}")]
    [Authorize(Roles = "Manager")]
    public async Task<ApiResponse> Put(int id, [FromQuery] ManagerExpenseRequestQueryModel expense)
    {
        string userId = (User.Identity as ClaimsIdentity).FindFirst("Id")?.Value;
        var data = new ManagerExpenseRequest
            {
                Status = expense.Status,
                RejectionReason = expense.RejectionReason,
                UpdateUserId = int.Parse(userId)
            };
        var operation = new UpdateManagerExpenseCommand(id, data);
        var result = await mediator.Send(operation);
        return result;
    }


    [HttpGet]
    [Authorize(Roles = "Manager")]
    public async Task<ApiResponse<List<ManagerExpenseResponse>>> Get()
    {
        var operation = new GetAllExpenseQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Manager")]
    public async Task<ApiResponse<ManagerExpenseResponse>> Get(int id)
    {
        var operation = new GetExpenseByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("ByParameters")]
    [Authorize(Roles = "Manager")]
    public async Task<ApiResponse<List<ManagerExpenseResponse>>> GetByParameter(
        [FromQuery] StatusEnum Status,
        [FromQuery] string? Location,
        [FromQuery] DateTime expenseDate,
        [FromQuery] DateTime requestDate)
    {
        var operation = new GetExpenseByParameterQuery(Status,Location,expenseDate,requestDate);
        var result = await mediator.Send(operation);
        return result;
    }
}
