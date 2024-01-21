using FluentValidation;
using PaymentSystem.Base.Enum;
using PaymentSystem.Schema;

namespace PaymentSystem.Business.Validator;

public class CreateBankInfoValidator : AbstractValidator<BankInfoRequest>
{
    public CreateBankInfoValidator()
    {
        RuleFor(x => x.IBAN)
            .NotEmpty().WithMessage("IBAN is required")
            .Length(16).WithMessage("IBAN must be exactly 16 characters");

        RuleFor(x => x.BankName)
            .NotEmpty().WithMessage("Bank Name is required")
            .MaximumLength(100).WithMessage("Bank Name cannot exceed 100 characters");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(50).WithMessage("Name cannot exceed 50 characters");

        RuleFor(x => x.Surname)
            .NotEmpty().WithMessage("Surname is required")
            .MaximumLength(50).WithMessage("Surname cannot exceed 50 characters");
    }
}