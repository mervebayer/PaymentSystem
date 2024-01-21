using FluentValidation;
using PaymentSystem.Schema;

namespace PaymentSystem.Business.Validator;

public class CreateEmployeeExpenseRequestValidator : AbstractValidator<EmployeeExpenseCreateRequest>
{
    public CreateEmployeeExpenseRequestValidator()
    {
        RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount must be greater than 0");
        RuleFor(x => x.Location).NotEmpty().MaximumLength(50).WithMessage("Location is required");
        RuleFor(x => x.Description).NotEmpty().MaximumLength(500).WithMessage("Description is required");
        RuleFor(x => x.ExpenseDate).NotEmpty().WithMessage("ExpenseDate is required");
    }
}