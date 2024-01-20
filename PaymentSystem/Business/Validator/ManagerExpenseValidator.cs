using FluentValidation;
using PaymentSystem.Base.Enum;
using PaymentSystem.Schema;

namespace PaymentSystem.Business.Validator;

public class CreateManagerExpenseValidator : AbstractValidator<ManagerExpenseRequestQueryModel>
{
    public CreateManagerExpenseValidator()
    {
        // RuleFor(x => x.UserId).GreaterThan(0).WithMessage("User ID must be greater than 0.");     
        RuleFor(x => x.Status).IsInEnum().WithMessage("Invalid status.");
        When(x => x.Status == StatusEnum.Declined, () =>
        {
            RuleFor(x => x.RejectionReason).NotEmpty().WithMessage("Rejection reason is required for rejected expenses.");
        });
    }
}