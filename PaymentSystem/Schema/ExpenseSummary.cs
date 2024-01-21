namespace PaymentSystem.Schema;
public class ExpenseSummary
{
    public string Type { get; set; }
    public int UniqueUserCount { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal AverageAmount { get; set; }
}