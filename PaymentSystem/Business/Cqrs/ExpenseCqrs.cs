using MediatR;
using PaymentSystem.Base.Response;
using PaymentSystem.Schema;

namespace PaymentSystem.Business.Cqrs;
public record CreateExpenseCommand(ExpenseRequest Model):IRequest<ApiResponse<ExpenseResponse>>;