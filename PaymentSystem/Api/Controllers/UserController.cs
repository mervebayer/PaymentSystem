using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Base.Response;
using PaymentSystem.Business.Cqrs;
using PaymentSystem.Schema;

namespace PaymentSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator mediator;

    public UserController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    // [Authorize(Roles = "Manager")]
    public async Task<ApiResponse<UserResponse>> Post([FromQuery] UserRequest User)
    {
        var operation = new CreateUserCommand(User);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    // [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Put(int id, [FromBody] UserRequest customer)
    {
        var operation = new UpdateUserCommand(id, customer);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    // [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Delete(int id)
    {
        var operation = new DeleteUserCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}
