using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Base.Response;
using PaymentSystem.Business.Cqrs;
using PaymentSystem.Schema;

namespace PaymentSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly IMediator mediator;

    public ReportController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpGet("RequestStatus")]
    [Authorize(Roles = "Manager")]
    public async Task<ApiResponse<IEnumerable<RequestStatusCountsResponse>>> GetRequestStatus()
    {
        var operation = new GetRequestStatusCountsQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("ExpenseSummary")]
    [Authorize(Roles = "Manager")]
    public async Task<ApiResponse<IEnumerable<ExpenseSummary>>> ExpenseSummary()
    {
        var operation = new GetExpensesByTimeQuery();
        var result = await mediator.Send(operation);
        return result;
    }

}
