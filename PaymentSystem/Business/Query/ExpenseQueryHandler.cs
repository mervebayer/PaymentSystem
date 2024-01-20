using AutoMapper;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Base.Response;
using PaymentSystem.Business.Cqrs;
using PaymentSystem.Data;
using PaymentSystem.Data.Entity;
using PaymentSystem.Schema;



namespace PaymentSystem.Business.Query;

public class ExpenseQueryHandler :
    IRequestHandler<GetAllEmployeeExpenseQuery, ApiResponse<List<EmployeeExpenseResponse>>>,
    IRequestHandler<GetEmployeeExpenseByIdQuery, ApiResponse<EmployeeExpenseResponse>>
   ,IRequestHandler<GetEmployeeExpenseByParameterQuery, ApiResponse<List<EmployeeExpenseResponse>>>
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
           .Include(x => x.User).Where(x => x.UserId == request.UserId && x.IsActive == true).ToListAsync(cancellationToken);

        var mappedList = mapper.Map<List<Expense>, List<EmployeeExpenseResponse>>(list);
        return new ApiResponse<List<EmployeeExpenseResponse>>(mappedList);
    }

    public async Task<ApiResponse<EmployeeExpenseResponse>> Handle(GetEmployeeExpenseByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<Expense>()
            .FirstOrDefaultAsync(x => x.UserId == request.UserId && x.Id == request.Id && x.IsActive == true, cancellationToken);
        if (entity == null)
        {
            return new ApiResponse<EmployeeExpenseResponse>("Record not found");
        }
        var mapped = mapper.Map<Expense, EmployeeExpenseResponse>(entity);
        return new ApiResponse<EmployeeExpenseResponse>(mapped);
    }


    public async Task<ApiResponse<List<EmployeeExpenseResponse>>> Handle(GetEmployeeExpenseByParameterQuery request,
           CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.New<Expense>(true);

        if (request.Status != 0)
            predicate.And(x => x.Status == request.Status);

        if (!string.IsNullOrEmpty(request.Location))
            predicate.And(x => x.Location.ToUpper().Contains(request.Location.ToUpper()));

        if (request.ExpenseDate != default)
            predicate.And(x => x.ExpenseDate == request.ExpenseDate);

        if (request.RequestDate != default)
            predicate.And(x => x.RequestDate == request.RequestDate);

        var list = await dbContext.Set<Expense>().Where(x => x.IsActive == true)
            .Where(predicate)
            .ToListAsync(cancellationToken);

        var mappedList = mapper.Map<List<Expense>, List<EmployeeExpenseResponse>>(list);
        return new ApiResponse<List<EmployeeExpenseResponse>>(mappedList);
    }
}