using MediatR;
using PaymentSystem.Base.Enum;
using PaymentSystem.Base.Response;
using PaymentSystem.Schema;

namespace PaymentSystem.Business.Cqrs;
public record CreateEmployeeExpenseCommand(EmployeeExpenseCreateRequest Model, int userId, string fileUrl):IRequest<ApiResponse<EmployeeExpenseResponse>>;

public record UpdateEmployeeExpenseCommand(int Id, EmployeeExpenseRequest Model):IRequest<ApiResponse>;

public record DeleteEmployeeExpenseCommand(int Id, int UserId) : IRequest<ApiResponse>;

public record GetAllEmployeeExpenseQuery(int UserId) : IRequest<ApiResponse<List<EmployeeExpenseResponse>>>;
public record GetEmployeeExpenseByIdQuery(int UserId, int Id) : IRequest<ApiResponse<EmployeeExpenseResponse>>;
public record GetEmployeeExpenseByParameterQuery(StatusEnum Status,string Location,DateTime ExpenseDate,DateTime RequestDate, int UserId) : IRequest<ApiResponse<List<EmployeeExpenseResponse>>>;