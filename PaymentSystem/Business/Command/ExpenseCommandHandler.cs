using AutoMapper;
using MediatR;
using PaymentSystem.Base.Response;
using PaymentSystem.Business.Cqrs;
using PaymentSystem.Data;
using PaymentSystem.Data.Entity;
using PaymentSystem.Schema;

namespace PaymentSystem.Business.Command;

public class ExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, ApiResponse<ExpenseResponse>>
{
    private readonly PaymentSystemDbContext dbContext;
    private readonly IMapper mapper;
    public ExpenseCommandHandler(PaymentSystemDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }
    public async Task<ApiResponse<ExpenseResponse>> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<ExpenseRequest, Expense>(request.Model);
        
        var entityResult = await dbContext.AddAsync(entity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        var mapped = mapper.Map<Expense, ExpenseResponse>(entityResult.Entity);
        return new ApiResponse<ExpenseResponse>(mapped);
    }
}
