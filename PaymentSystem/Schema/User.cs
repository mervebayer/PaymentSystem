using System.Text.Json.Serialization;
using PaymentSystem.Base.Enum;
using PaymentSystem.Data.Entity;

namespace PaymentSystem.Schema;

public class UserRequest
{
    public string IdentityNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public RoleEnum Role { get; set; }
    public DateTime DateOfBirth { get; set; }
    
    [JsonIgnore]
    public virtual List<Expense>? Expenses { get; set; }
    
    [JsonIgnore]

    public virtual List<BankInfo>? BankInfos { get; set; }
    
}

public class UserResponse
{
    public string IdentityNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public RoleEnum Role { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime LastActivityDate { get; set; }
    public int PasswordRetryCount { get; set; }
    public int Status { get; set; }

    public virtual List<Expense> Expenses { get; set; }
    public virtual List<BankInfo> BankInfos { get; set; }
    
}