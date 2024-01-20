using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentSystem.Base.Entity;

public abstract class BaseEntityWithId 
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int InsertUserId { get; set; }
    public DateTime InsertDate { get; set; } = DateTime.UtcNow;
    public int? UpdateUserId { get; set; }
    public DateTime? UpdateDate { get; set; } 
    public bool IsActive { get; set; }
}
