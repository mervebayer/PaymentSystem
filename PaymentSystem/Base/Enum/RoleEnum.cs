using System.Text.Json.Serialization;

namespace PaymentSystem.Base.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RoleEnum
{
    Employee = 1,
    Manager
}
