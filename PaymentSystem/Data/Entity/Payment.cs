using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentSystem.Base.Entity;
using PaymentSystem.Data.Entity;

namespace PaymentSystem.Data.Entity
{
    [Table("Payment", Schema = "dbo")]
    public class Payment : BaseEntityWithId
    {
        public int ExpenseId { get; set; }
        public virtual ExpenseRequest ExpenseRequest { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.Property(x => x.InsertDate).IsRequired(true);
        builder.Property(x => x.InsertUserId).IsRequired(true);
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.UpdateUserId).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired(true).HasDefaultValue(true);

        builder.Property(x => x.Amount).IsRequired(true).HasPrecision(18, 4);
             builder.Property(x => x.PaymentDate).IsRequired(true);

    }
}