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

public class UserCommandHandler : IRequestHandler<CreateUserCommand, ApiResponse<UserResponse>>
{
    private readonly PaymentSystemDbContext dbContext;
    private readonly IMapper mapper;
    public UserCommandHandler(PaymentSystemDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }
    public async Task<ApiResponse<UserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
      var checkIdentity = await dbContext.Set<User>().Where(x => x.IdentityNumber == request.Model.IdentityNumber)
            .FirstOrDefaultAsync(cancellationToken);
        if (checkIdentity != null)
        {
            return new ApiResponse<UserResponse>($"{request.Model.IdentityNumber} is used by another customer.");
        }
        var entity = mapper.Map<UserRequest, User>(request.Model);
        entity.Password = Md5Extension.GetHash(request.Model.Password);
        entity.InsertDate = DateTime.UtcNow;
        entity.LastActivityDate = DateTime.UtcNow;

        var entityResult = await dbContext.AddAsync(entity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        var mapped = mapper.Map<User, UserResponse>(entityResult.Entity);
        return new ApiResponse<UserResponse>(mapped);
    }

    public async Task<ApiResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Set<User>().Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
        if (user == null)
        {
            return new ApiResponse("Record not found");
        }
        
        user.FirstName = request.Model.FirstName;
        user.LastName = request.Model.LastName;
        
        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

       public async Task<ApiResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Set<User>().Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
        
        if (user == null)
        {
            return new ApiResponse("Record not found");
        }
        
        user.IsActive = false;
        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }
}
