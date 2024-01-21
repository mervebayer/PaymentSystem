using MediatR;
using PaymentSystem.Base.Response;
using PaymentSystem.Schema;

namespace PaymentSystem.Business.Cqrs;
public record GetRequestStatusCountsQuery : IRequest<ApiResponse<IEnumerable<RequestStatusCountsResponse>>>;
public record GetExpensesByTimeQuery : IRequest<ApiResponse<IEnumerable<ExpenseSummary>>>;

