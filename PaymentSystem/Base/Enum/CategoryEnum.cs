using System.Text.Json.Serialization;

namespace PaymentSystem.Base.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CategoryEnum
{
    Transportation = 1,
    Food,
    Healthcare,
    DebtRepayment,
    Entertainment,
    Education,
    Travel,
    HomeOffice,
    Communication,
    Equipment,
    Miscellaneous

}
