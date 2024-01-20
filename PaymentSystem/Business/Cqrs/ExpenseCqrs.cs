using MediatR;
using PaymentSystem.Base.Enum;
using PaymentSystem.Base.Response;
using PaymentSystem.Schema;

namespace PaymentSystem.Business.Cqrs;
public record CreateEmployeeExpenseCommand(EmployeeExpenseRequest Model):IRequest<ApiResponse<EmployeeExpenseResponse>>;

public record UpdateEmployeeExpenseCommand(int Id, EmployeeExpenseRequest Model):IRequest<ApiResponse>;

public record DeleteEmployeeExpenseCommand(int Id) : IRequest<ApiResponse>;

public record GetAllEmployeeExpenseQuery(int UserId) : IRequest<ApiResponse<List<EmployeeExpenseResponse>>>;
public record GetEmployeeExpenseByIdQuery(int UserId, int Id) : IRequest<ApiResponse<EmployeeExpenseResponse>>;
public record GetEmployeeExpenseByParameterQuery(StatusEnum Status,string Location,DateTime ExpenseDate,DateTime RequestDate) : IRequest<ApiResponse<List<EmployeeExpenseResponse>>>;