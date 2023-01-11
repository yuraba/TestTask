using FluentValidation;

namespace WebApplication1.Models.Validator;

public class AccountValidator : AbstractValidator<Account>
{
    public AccountValidator()
    {
        RuleFor(x => x.Contacts).NotEmpty();
    }
}