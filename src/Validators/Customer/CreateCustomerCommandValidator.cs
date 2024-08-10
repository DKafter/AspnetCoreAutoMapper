using dotnetautomapper.Commands.Customer;
using FluentValidation;

namespace dotnetautomapper.Validators.Customer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateNewCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(t => t.customer.Name).NotEmpty()
            .WithMessage("{PropertyName} is required").MaximumLength(50);
        RuleFor(t => t.customer.Email).NotEmpty().MaximumLength(50);
        RuleFor(t => t.customer.LastName).NotEmpty().MaximumLength(50);
    }
}