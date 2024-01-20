using FluentValidation;
using PaymentSystem.Base.Enum;
using PaymentSystem.Schema;

namespace PaymentSystem.Business.Validator;

public class CreateEmployeeExpenseValidator : AbstractValidator<EmployeeExpenseRequest>
{
    public CreateEmployeeExpenseValidator()
    {
        // RuleFor(x => x.UserId).GreaterThan(0).WithMessage("User ID must be greater than 0.");
        RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount must be greater than 0.");
        RuleFor(x => x.DocumentUrl).NotEmpty().WithMessage("Document URL is required.");
        RuleFor(x => x.Location).NotEmpty().WithMessage("Location is required.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
        RuleFor(x => x.ExpenseDate).NotEmpty().WithMessage("Expense date is required.");
        // RuleFor(x => x.RequestDate).NotEmpty().WithMessage("Request date is required."); 
    }
}