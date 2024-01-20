using FluentValidation;
using PaymentSystem.Base.Enum;
using PaymentSystem.Schema;

namespace PaymentSystem.Business.Validator;

public class CreateExpenseValidator : AbstractValidator<ExpenseRequest>
{
    public CreateExpenseValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0).WithMessage("User ID must be greater than 0.");
        RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount must be greater than 0.");
        RuleFor(x => x.DocumentUrl).NotEmpty().WithMessage("Document URL is required.");
        RuleFor(x => x.Location).NotEmpty().WithMessage("Location is required.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
        RuleFor(x => x.Status).IsInEnum().WithMessage("Invalid status.");
        RuleFor(x => x.ExpenseDate).NotEmpty().WithMessage("Expense date is required.");
        RuleFor(x => x.RequestDate).NotEmpty().WithMessage("Request date is required.");
        When(x => x.Status == StatusEnum.Declined, () =>
        {
            RuleFor(x => x.RejectionReason).NotEmpty().WithMessage("Rejection reason is required for rejected expenses.");
        });
    }
}