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

public class UserQueryHandler :
    IRequestHandler<GetAllUserQuery, ApiResponse<List<UserResponse>>>
    
{
    private readonly PaymentSystemDbContext dbContext;
    private readonly IMapper mapper;

    public UserQueryHandler(PaymentSystemDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<UserResponse>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var list = await dbContext.Set<User>()
           .Include(x => x.BankInfos)
           .Include(x => x.Expenses)
           .Where(x => x.IsActive == true).ToListAsync(cancellationToken);

        var mappedList = mapper.Map<List<User>, List<UserResponse>>(list);
        return new ApiResponse<List<UserResponse>>(mappedList);
    }

}