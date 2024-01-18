using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentSystem.Base.Entity;
using PaymentSystem.Base.Enum;

namespace PaymentSystem.Data.Entity;

[Table("ExpenseRequest", Schema = "dbo")]
public class ExpenseRequest : BaseEntityWithId 
{
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public decimal Amount { get; set; }
    public string DocumentUrl { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public StatusEnum Status { get; set; }
    public string RejectionReason { get; set; }
    public DateTime ExpenseDate { get; set; }
    public DateTime RequestDate { get; set; }
    
}
public class ExpenseRequestConfiguration : IEntityTypeConfiguration<ExpenseRequest>
{
    public void Configure(EntityTypeBuilder<ExpenseRequest> builder)
    {
        builder.Property(x => x.InsertDate).IsRequired(true);
        builder.Property(x => x.InsertUserId).IsRequired(true);
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.UpdateUserId).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired(true).HasDefaultValue(true);

        builder.Property(x => x.UserId).IsRequired(true);
        builder.Property(x => x.Location).IsRequired(true);
        builder.Property(x => x.Description).IsRequired(true);
        builder.Property(x => x.Amount).IsRequired(true).HasPrecision(18, 4);
        builder.Property(x => x.DocumentUrl).IsRequired(true);
        builder.Property(x => x.Status).IsRequired(true);
        builder.Property(x => x.RejectionReason).IsRequired(true);
        builder.Property(x => x.ExpenseDate).IsRequired(true);
        builder.Property(x => x.RequestDate).IsRequired(true);

    }
}