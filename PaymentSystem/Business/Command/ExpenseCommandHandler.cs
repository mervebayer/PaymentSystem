using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Base.Response;
using PaymentSystem.Business.Cqrs;
using PaymentSystem.Data;
using PaymentSystem.Data.Entity;
using PaymentSystem.Schema;

namespace PaymentSystem.Business.Command;

public class ExpenseCommandHandler : IRequestHandler<CreateEmployeeExpenseCommand, ApiResponse<EmployeeExpenseResponse>>,
                    IRequestHandler<DeleteEmployeeExpenseCommand, ApiResponse>,
                    IRequestHandler<UpdateEmployeeExpenseCommand, ApiResponse>
{
    private readonly PaymentSystemDbContext dbContext;
    private readonly IMapper mapper;
    public ExpenseCommandHandler(PaymentSystemDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }
    public async Task<ApiResponse<EmployeeExpenseResponse>> Handle(CreateEmployeeExpenseCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<EmployeeExpenseRequest, Expense>(request.Model);

        var entityResult = await dbContext.AddAsync(entity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        var mapped = mapper.Map<Expense, EmployeeExpenseResponse>(entityResult.Entity);
        return new ApiResponse<EmployeeExpenseResponse>(mapped);
    }

    public async Task<ApiResponse> Handle(UpdateEmployeeExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = await dbContext.Set<Expense>().Where(x => x.Id == request.Id && x.UserId == request.Model.UserId&& x.IsActive == true)
            .FirstOrDefaultAsync(cancellationToken);
        if (expense == null)
        {
            return new ApiResponse("Record not found");
        }

        expense.Amount = request.Model.Amount;
        expense.Location = request.Model.Location;
        expense.DocumentUrl = request.Model.DocumentUrl;
        expense.ExpenseDate = request.Model.ExpenseDate;

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeleteEmployeeExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = await dbContext.Set<Expense>().Where(x => x.Id == request.Id && x.UserId == request.UserId && x.IsActive == true)
            .FirstOrDefaultAsync(cancellationToken);

        if (expense == null)
        {
            return new ApiResponse("Record not found");
        }

        expense.IsActive = false;
        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }
}
