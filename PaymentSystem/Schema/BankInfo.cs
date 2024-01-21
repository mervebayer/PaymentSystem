using System.Text.Json.Serialization;
using PaymentSystem.Base.Enum;
using PaymentSystem.Data.Entity;

namespace PaymentSystem.Schema;

public class BankInfoRequest
{
    [JsonIgnore]
    public int UserId { get; set; }
    public string IBAN { get; set; }
    public string BankName { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    
}

public class BankInfoResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string IBAN { get; set; }
    public string BankName { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    
}

public class BankInfoUserRequest
{
    public string IBAN { get; set; }
    public string BankName { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    
}