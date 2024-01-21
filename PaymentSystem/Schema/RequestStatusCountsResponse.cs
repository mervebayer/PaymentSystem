namespace PaymentSystem.Schema;
public class RequestStatusCountsResponse
{
    public string Type { get; set; }
    public int RejectedCount { get; set; }
    public int ApprovedCount { get; set; }
}
