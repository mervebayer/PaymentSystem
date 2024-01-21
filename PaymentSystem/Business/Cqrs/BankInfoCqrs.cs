using MediatR;
using PaymentSystem.Base.Response;
using PaymentSystem.Schema;

namespace PaymentSystem.Business.Cqrs;
public record CreateBankInfoCommand(BankInfoRequest Model) : IRequest<ApiResponse<BankInfoResponse>>;
public record UpdateBankInfoCommand(int Id, BankInfoRequest Model) : IRequest<ApiResponse>;

public record DeleteBankInfoCommand(int Id) : IRequest<ApiResponse>;

public record GetAllBankInfoQuery() : IRequest<ApiResponse<List<BankInfoResponse>>>;
public record GetBankInfoByIdQuery(int Id) : IRequest<ApiResponse<BankInfoResponse>>;
public record GetBankInfoByParameterQuery(string FirstName, string LastName, string IdentityNumber) : IRequest<ApiResponse<List<BankInfoResponse>>>;