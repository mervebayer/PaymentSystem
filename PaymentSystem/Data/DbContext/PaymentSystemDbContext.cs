using Microsoft.EntityFrameworkCore;
using PaymentSystem.Base.Enum;
using PaymentSystem.Data.Entity;
using PaymentSystem.Schema;

namespace PaymentSystem.Data;
public class PaymentSystemDbContext: DbContext
{
    public PaymentSystemDbContext(DbContextOptions<PaymentSystemDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<BankInfo> BankInfos { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedData(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new BankInfoConfiguration());
        modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());

        modelBuilder.Entity<RequestStatusCountsResponse>().ToView("GetRequestStatusCounts").HasNoKey();;
        modelBuilder.Entity<RequestStatusCountsResponse>().ToView("GetExpensesByTime").HasNoKey();;

        base.OnModelCreating(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                IdentityNumber = "1234567890",
                FirstName = "Manager",
                LastName = "User",
                UserName = "manageruser",
                Password = "a4f64b517678640a0bd1d9b8b4e4f9b4 ", // manageruser
                Email = "manager@example.com",
                Role = RoleEnum.Manager,
                DateOfBirth = new DateTime(1980, 4, 4),
                LastActivityDate = DateTime.Now,
                PasswordRetryCount = 0,
                Status = 1,
                InsertDate = DateTime.Now,
                InsertUserId = 1,
                IsActive = true
            },
            new User
            {
                Id = 2,
                IdentityNumber = "9876543210",
                FirstName = "Employee",
                LastName = "User",
                UserName = "employeeuser",
                Password = "82eb8d92b631e08895878594ebeea3f1", // employeeuser
                Email = "employee@example.com",
                Role = RoleEnum.Employee,
                DateOfBirth = DateTime.Now.AddYears(-20),
                LastActivityDate = DateTime.Now,
                PasswordRetryCount = 0,
                Status = 1,
                InsertDate = DateTime.Now,
                InsertUserId = 1,
                IsActive = true
            }
        );
    }
}
