using MediatR;
using PaymentSystem.Base.Enum;
using PaymentSystem.Base.Response;
using PaymentSystem.Schema;

namespace PaymentSystem.Business.Cqrs;
public record CreateManagerExpenseCommand(ManagerExpenseRequest Model) : IRequest<ApiResponse<ManagerExpenseResponse>>;

public record UpdateManagerExpenseCommand(int Id, ManagerExpenseRequest Model) : IRequest<ApiResponse>;

// public record DeleteManagerExpenseCommand(int Id, int UserId) : IRequest<ApiResponse>;

public record GetAllExpenseQuery() : IRequest<ApiResponse<List<ManagerExpenseResponse>>>;
public record GetExpenseByIdQuery(int Id) : IRequest<ApiResponse<ManagerExpenseResponse>>;
public record GetExpenseByParameterQuery(StatusEnum Status, string Location, DateTime ExpenseDate, DateTime RequestDate) : IRequest<ApiResponse<List<ManagerExpenseResponse>>>;