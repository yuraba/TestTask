using FluentValidation;

namespace WebApplication1.Models.Validator;

public class IncidentValidator : AbstractValidator<Incident>
{
    public IncidentValidator()
    {
        RuleFor(x => x.Accounts).NotEmpty();
    }
}