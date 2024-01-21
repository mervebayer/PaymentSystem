using System.Text.Json.Serialization;
using PaymentSystem.Base.Enum;

namespace PaymentSystem.Schema;

public class EmployeeExpenseRequest
{
    [JsonIgnore]
    public int Id { get; set; }
    [JsonIgnore]
    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public string DocumentUrl { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public DateTime ExpenseDate { get; set; }
    [JsonIgnore]
    public DateTime RequestDate { get; set; }
    
}

public class EmployeeExpenseResponse
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
    
}

public class EmployeeExpenseCreateRequest
{
    public decimal Amount { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public DateTime ExpenseDate { get; set; }
    
}