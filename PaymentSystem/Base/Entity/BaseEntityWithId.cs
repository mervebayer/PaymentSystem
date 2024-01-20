using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentSystem.Base.Entity;

public abstract class BaseEntityWithId : BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
}
public abstract class BaseEntity
{
    public int InsertUserId { get; set; }
    public DateTime InsertDate { get; set; }
    public int? UpdateUserId { get; set; }
    public DateTime? UpdateDate { get; set; }
    public bool IsActive { get; set; }
}
