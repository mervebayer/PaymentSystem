using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentSystem.Base.Entity;
using PaymentSystem.Base.Enum;

namespace PaymentSystem.Data.Entity;

[Table("User", Schema = "dbo")]
public class User: BaseEntityWithId 
{
    public string IdentityNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public RoleEnum Role { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime LastActivityDate { get; set; }
    public int PasswordRetryCount { get; set; }
    public int Status { get; set; }

    public virtual List<ExpenseRequest> ExpenseRequests { get; set; }
    public virtual List<BankInfo> BankInfos { get; set; }

}

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.InsertDate).IsRequired(true);
        builder.Property(x => x.InsertUserId).IsRequired(true);
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.UpdateUserId).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired(true).HasDefaultValue(true);

        builder.Property(x => x.IdentityNumber).IsRequired(true);
        builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.UserName).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.Password).IsRequired(true).HasMaxLength(250);
        builder.Property(x => x.Role).IsRequired(true);
        builder.Property(x => x.Email).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.LastActivityDate).IsRequired(true);
        builder.Property(x => x.PasswordRetryCount).IsRequired(true).HasDefaultValue(0);
        builder.Property(x => x.Status).IsRequired(true).HasDefaultValue(1);

        builder.HasIndex(x => x.UserName).IsUnique(true);

        builder.HasMany(x => x.BankInfos)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .IsRequired(true);
        
        builder.HasMany(x => x.ExpenseRequests)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .IsRequired(true);

    }
}