using FluentValidation;
using PaymentSystem.Schema;

namespace PaymentSystem.Business.Validator;

public class CreateUserValidator : AbstractValidator<UserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.IdentityNumber).NotEmpty().MaximumLength(11).WithName("User tax or identity number");
        RuleFor(x => x.DateOfBirth).NotEmpty();
        RuleFor(x => x.UserName).NotEmpty().MaximumLength(50).WithMessage("User name is required.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid email address.");
        RuleFor(x => x.Role).IsInEnum().WithMessage("Invalid role.");
        RuleFor(x => x.DateOfBirth).NotEmpty().Must(BeNotInFuture).WithName("Format must be YYYY-mm-DD").WithMessage("Invalid date of birth.");

        // RuleForEach(x => x.Expenses).SetValidator(new CreateEmployeeExpenseRequestValidator());
    }
    private bool BeNotInFuture(DateTime dateOfBirth)
    {
        return dateOfBirth <= DateTime.Today;
    }
}