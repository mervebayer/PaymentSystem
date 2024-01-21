using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Base.Response;
using PaymentSystem.Business.Cqrs;
using PaymentSystem.Schema;

namespace PaymentSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BankInfoController : ControllerBase
{
    private readonly IMediator mediator;

    public BankInfoController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = "Manager")]
    public async Task<ApiResponse<BankInfoResponse>> Post([FromQuery] BankInfoRequest BankInfo)
    {
        var operation = new CreateBankInfoCommand(BankInfo);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Manager")]
    public async Task<ApiResponse> Put(int id, [FromBody] BankInfoRequest customer)
    {
        var operation = new UpdateBankInfoCommand(id, customer);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Manager")]
    public async Task<ApiResponse> Delete(int id)
    {
        var operation = new DeleteBankInfoCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }

     [HttpGet]
    [Authorize(Roles = "Manager")]
    public async Task<ApiResponse<List<BankInfoResponse>>> Get()
    {
        var operation = new GetAllBankInfoQuery();
        var result = await mediator.Send(operation);
        return result;
    }

     [HttpGet("{id}")]
    [Authorize(Roles = "Manager")]
    public async Task<ApiResponse<BankInfoResponse>> Get(int id)
    {
        var operation = new GetBankInfoByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }
}
