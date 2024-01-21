using Microsoft.EntityFrameworkCore;
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
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new BankInfoConfiguration());
        modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());

        modelBuilder.Entity<RequestStatusCountsResponse>().ToView("GetRequestStatusCounts").HasNoKey();;
        modelBuilder.Entity<RequestStatusCountsResponse>().ToView("GetExpensesByTime").HasNoKey();;

        base.OnModelCreating(modelBuilder);
    }
}
