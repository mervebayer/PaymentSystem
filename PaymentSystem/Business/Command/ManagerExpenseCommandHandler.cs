using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Base.Response;
using PaymentSystem.Business.Cqrs;
using PaymentSystem.Data;
using PaymentSystem.Data.Entity;
using PaymentSystem.Schema;

namespace PaymentSystem.Business.Command;

public class ManagerExpenseCommandHandler : 
                    IRequestHandler<UpdateManagerExpenseCommand, ApiResponse>
{
    private readonly PaymentSystemDbContext dbContext;
    private readonly IMapper mapper;
    public ManagerExpenseCommandHandler(PaymentSystemDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<ApiResponse> Handle(UpdateManagerExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = await dbContext.Set<Expense>().Where(x => x.Id == request.Id && x.IsActive == true)
            .FirstOrDefaultAsync(cancellationToken);
        if (expense == null)
        {
            return new ApiResponse("Record not found");
        }

        expense.Status = request.Model.Status;
        expense.RejectionReason = request.Model.RejectionReason;
        expense.UpdateDate = DateTime.UtcNow;
        expense.UpdateUserId = request.Model.UpdateUserId;

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

    
}
