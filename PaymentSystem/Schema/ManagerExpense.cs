using System.Text.Json.Serialization;
using PaymentSystem.Base.Enum;

namespace PaymentSystem.Schema;

public class ManagerExpenseRequest
{
    [JsonIgnore]
    public int Id { get; set; }
    [JsonIgnore]
    public int UserId { get; set; }
    [JsonIgnore]
    public int UpdateUserId { get; set; }
    public StatusEnum Status { get; set; }
    public string RejectionReason { get; set; }
    
}

public class ManagerExpenseResponse
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string DocumentUrl { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public StatusEnum Status { get; set; }
    public string RejectionReason { get; set; }
    public DateTime ExpenseDate { get; set; }
    public DateTime RequestDate { get; set; }
    public int? UpdateUserId { get; set; }
    public DateTime? UpdateDate { get; set; } 
     public int UserId { get; set; }
    
}

public class ManagerExpenseRequestQueryModel
{
    public StatusEnum Status { get; set; }
    public string? RejectionReason { get; set; }
}