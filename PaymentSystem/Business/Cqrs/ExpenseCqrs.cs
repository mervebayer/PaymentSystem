using MediatR;
using PaymentSystem.Base.Enum;
using PaymentSystem.Base.Response;
using PaymentSystem.Schema;

namespace PaymentSystem.Business.Cqrs;
public record CreateExpenseCommand(EmployeeExpenseRequest Model):IRequest<ApiResponse<EmployeeExpenseResponse>>;

public record UpdateExpenseCommand(int Id, ExpenseRequest Model):IRequest<ApiResponse>;

public record DeleteExpenseCommand(int Id) : IRequest<ApiResponse>;

public record GetAllExpenseQuery() : IRequest<ApiResponse<List<ExpenseResponse>>>;
public record GetExpenseByIdQuery(int Id) : IRequest<ApiResponse<ExpenseResponse>>;
public record GetExpenseByParameterQuery(StatusEnum Status,string Location,DateTime ExpenseDate,DateTime RequestDate) : IRequest<ApiResponse<List<ExpenseResponse>>>;