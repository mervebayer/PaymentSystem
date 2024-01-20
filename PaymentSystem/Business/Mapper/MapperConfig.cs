using AutoMapper;
using PaymentSystem.Data.Entity;
using PaymentSystem.Schema;

namespace PaymentSystem.Business.Mapper;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<ExpenseRequest, Expense>();
        CreateMap<Expense, ExpenseResponse>();

        CreateMap<EmployeeExpenseRequest, Expense>();
        CreateMap<Expense, EmployeeExpenseResponse>();

        CreateMap<ManagerExpenseRequest, Expense>();
        CreateMap<Expense, ManagerExpenseResponse>();

        CreateMap<UserRequest, User>();
        CreateMap<User, UserResponse>();
    }
}
