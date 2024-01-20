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

public class ManagerExpenseQueryHandler :
    IRequestHandler<GetAllExpenseQuery, ApiResponse<List<ManagerExpenseResponse>>>,
    IRequestHandler<GetExpenseByIdQuery, ApiResponse<ManagerExpenseResponse>>,
    IRequestHandler<GetExpenseByParameterQuery, ApiResponse<List<ManagerExpenseResponse>>>
{
    private readonly PaymentSystemDbContext dbContext;
    private readonly IMapper mapper;

    public ManagerExpenseQueryHandler(PaymentSystemDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<ManagerExpenseResponse>>> Handle(GetAllExpenseQuery request, CancellationToken cancellationToken)
    {
        var list = await dbContext.Set<Expense>()
           .Include(x => x.User).Where(x => x.IsActive == true).ToListAsync(cancellationToken);

        var mappedList = mapper.Map<List<Expense>, List<ManagerExpenseResponse>>(list);
        return new ApiResponse<List<ManagerExpenseResponse>>(mappedList);
    }

    public async Task<ApiResponse<ManagerExpenseResponse>> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<Expense>()
            .FirstOrDefaultAsync(x => x.Id == request.Id && x.IsActive == true, cancellationToken);
        if (entity == null)
        {
            return new ApiResponse<ManagerExpenseResponse>("Record not found");
        }
        var mapped = mapper.Map<Expense, ManagerExpenseResponse>(entity);
        return new ApiResponse<ManagerExpenseResponse>(mapped);
    }


    public async Task<ApiResponse<List<ManagerExpenseResponse>>> Handle(GetExpenseByParameterQuery request,
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

        var mappedList = mapper.Map<List<Expense>, List<ManagerExpenseResponse>>(list);
        return new ApiResponse<List<ManagerExpenseResponse>>(mappedList);
    }
}