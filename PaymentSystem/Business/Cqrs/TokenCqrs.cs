using MediatR;
using PaymentSystem.Base.Response;
using PaymentSystem.Schema;

namespace PaymentSystem.Business.Cqrs;

public record CreateTokenCommand(TokenRequest Model) : IRequest<ApiResponse<TokenResponse>>;


