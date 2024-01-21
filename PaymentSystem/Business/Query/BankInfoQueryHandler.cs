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

public class BankInfoQueryHandler :
    IRequestHandler<GetAllBankInfoQuery, ApiResponse<List<BankInfoResponse>>>,
    IRequestHandler<GetBankInfoByIdQuery, ApiResponse<BankInfoResponse>>
    
{
    private readonly PaymentSystemDbContext dbContext;
    private readonly IMapper mapper;

    public BankInfoQueryHandler(PaymentSystemDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<BankInfoResponse>>> Handle(GetAllBankInfoQuery request, CancellationToken cancellationToken)
    {
        var list = await dbContext.Set<BankInfo>()
           .Where(x => x.IsActive == true).ToListAsync(cancellationToken);

        var mappedList = mapper.Map<List<BankInfo>, List<BankInfoResponse>>(list);
        return new ApiResponse<List<BankInfoResponse>>(mappedList);
    }

     public async Task<ApiResponse<BankInfoResponse>> Handle(GetBankInfoByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<BankInfo>()
            .FirstOrDefaultAsync(x => x.Id == request.Id && x.IsActive == true, cancellationToken);
        if (entity == null)
        {
            return new ApiResponse<BankInfoResponse>("Record not found");
        }
        var mapped = mapper.Map<BankInfo, BankInfoResponse>(entity);
        return new ApiResponse<BankInfoResponse>(mapped);
    }

}