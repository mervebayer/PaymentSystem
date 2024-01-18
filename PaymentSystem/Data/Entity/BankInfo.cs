using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentSystem.Base.Entity;

namespace PaymentSystem.Data.Entity;

[Table("BankInfo", Schema = "dbo")]
public class BankInfo : BaseEntityWithId
{
     public int UserId { get; set; }
    public virtual User User { get; set; }
    public string IBAN { get; set; }
    public string BankName { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}

public class BankInfoConfiguration : IEntityTypeConfiguration<BankInfo>
{
    public void Configure(EntityTypeBuilder<BankInfo> builder)
    {
        builder.Property(x => x.InsertDate).IsRequired(true);
        builder.Property(x => x.InsertUserId).IsRequired(true);
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.UpdateUserId).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired(true).HasDefaultValue(true);

        builder.Property(x => x.UserId).IsRequired(true);
        builder.Property(x => x.IBAN).IsRequired(true).HasMaxLength(16);
        builder.Property(x => x.BankName).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.Name).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.Surname).IsRequired(true).HasMaxLength(250);

    }
}