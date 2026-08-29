using FluentValidation;
using UserManagement.DTO.Command;

namespace UserManagement.AggregateRoot.Validators
{
    public class UserDeleteCommandValidator : AbstractValidator<UserDeleteCommand>
    {
        public UserDeleteCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email is required and must be a valid email address");

            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("Full name is required");
        }
    }
}