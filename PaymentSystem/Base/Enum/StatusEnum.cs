using System.Text.Json.Serialization;

namespace PaymentSystem.Base.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StatusEnum
{
    Pending = 1,
    Approved,
    Declined
}
