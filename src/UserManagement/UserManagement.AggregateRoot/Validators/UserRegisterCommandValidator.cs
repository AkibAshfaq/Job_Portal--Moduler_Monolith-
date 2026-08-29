using FluentValidation;
using UserManagement.DTO.Command;

namespace UserManagement.AggregateRoot.Validators
{
    public class UserRegisterCommandValidator : AbstractValidator<UserRegisterCommand>
    {
        public UserRegisterCommandValidator() {

            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("Full Name is required.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email is required and must be a valid email address.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MaximumLength(11)
                .MinimumLength(11)
                .WithMessage("Phone Number is required and must be exactly 11 characters long.");

            RuleFor(x => x.UserType)
                .NotEmpty()
                .IsInEnum()
                .WithMessage("User Type is required and must be a valid enum value.");
        }
    }
}
