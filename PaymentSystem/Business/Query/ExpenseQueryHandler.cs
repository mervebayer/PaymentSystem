using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Base.Response;
using PaymentSystem.Business.Cqrs;
using PaymentSystem.Data;
using PaymentSystem.Data.Entity;
using PaymentSystem.Schema;

namespace PaymentSystem.Business.Query;

public class ExpenseQueryHandler :
    IRequestHandler<GetAllEmployeeExpenseQuery, ApiResponse<List<EmployeeExpenseResponse>>>
    // ,
    // IRequestHandler<GetEmployeeExpenseByIdQuery, ApiResponse<EmployeeExpenseResponse>>,
    // IRequestHandler<GetEmployeeExpenseByParameterQuery, ApiResponse<List<EmployeeExpenseResponse>>>
{
    private readonly PaymentSystemDbContext dbContext;
    private readonly IMapper mapper;

    public ExpenseQueryHandler(PaymentSystemDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<EmployeeExpenseResponse>>> Handle(GetAllEmployeeExpenseQuery request, CancellationToken cancellationToken)
    {
         var list = await dbContext.Set<Expense>()
            .Include(x => x.User).Where(x => x.UserId == request.UserId).ToListAsync(cancellationToken);
        
        var mappedList = mapper.Map<List<Expense>, List<EmployeeExpenseResponse>>(list);
         return new ApiResponse<List<EmployeeExpenseResponse>>(mappedList);
    }

    // public async Task<ApiResponse<EmployeeExpenseResponse>> Handle(GetEmployeeExpenseByIdQuery request, CancellationToken cancellationToken)
    // {
    //     var list = await dbContext.Set<Expense>()
    //         .Include(x => x.User).Where(x => x.UserId == request.UserId).ToListAsync(cancellationToken);
        
    //     var mappedList = mapper.Map<List<Expense>, List<EmployeeExpenseResponse>>(list);
    //      return new ApiResponse<List<EmployeeExpenseResponse>>(mappedList);
    // }

 

    // public Task<ApiResponse<List<EmployeeExpenseResponse>>> Handle(GetEmployeeExpenseByParameterQuery request, CancellationToken cancellationToken)
    // {
    //     throw new NotImplementedException();
    // }
}