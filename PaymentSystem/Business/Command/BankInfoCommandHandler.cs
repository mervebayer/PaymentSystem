using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Base.Encryption;
using PaymentSystem.Base.Response;
using PaymentSystem.Business.Cqrs;
using PaymentSystem.Data;
using PaymentSystem.Data.Entity;
using PaymentSystem.Schema;

namespace PaymentSystem.Business.Command;

public class BankInfoCommandHandler : IRequestHandler<CreateBankInfoCommand, ApiResponse<BankInfoResponse>>
{
    private readonly PaymentSystemDbContext dbContext;
    private readonly IMapper mapper;
    public BankInfoCommandHandler(PaymentSystemDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }
    public async Task<ApiResponse<BankInfoResponse>> Handle(CreateBankInfoCommand request, CancellationToken cancellationToken)
    {
      var checkIdentity = await dbContext.Set<BankInfo>().Where(x => x.IBAN == request.Model.IBAN)
            .FirstOrDefaultAsync(cancellationToken);
        if (checkIdentity != null)
        {
            return new ApiResponse<BankInfoResponse>($"{request.Model.IBAN} is already in use.");
        }
        var entity = mapper.Map<BankInfoRequest, BankInfo>(request.Model);

        var entityResult = await dbContext.AddAsync(entity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        var mapped = mapper.Map<BankInfo, BankInfoResponse>(entityResult.Entity);
        return new ApiResponse<BankInfoResponse>(mapped);

       
    }

    public async Task<ApiResponse> Handle(UpdateBankInfoCommand request, CancellationToken cancellationToken)
    {
        var bankInfo = await dbContext.Set<BankInfo>().Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
        if (bankInfo == null)
        {
            return new ApiResponse("Record not found");
        }
        
        bankInfo.BankName = request.Model.BankName;
        bankInfo.IBAN = request.Model.IBAN;
        bankInfo.Surname = request.Model.Surname;
        
        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

       public async Task<ApiResponse> Handle(DeleteBankInfoCommand request, CancellationToken cancellationToken)
    {
        var bankInfo = await dbContext.Set<BankInfo>().Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
        
        if (bankInfo == null)
        {
            return new ApiResponse("Record not found");
        }
        
        bankInfo.IsActive = false;
        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }
}


