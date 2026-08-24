using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.DTO.Command;

namespace UserManagement.AggregateRoot.Validators
{
    internal class UserUpdateCommandValidator : AbstractValidator<UserUpdateCommand>
    {
        public UserUpdateCommandValidator() { 
            
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("Full Name is required.");
            
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone Number is required.");
            
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long.");
            
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .Equal(x => x.Password)
                .WithMessage("Passwords do not match.");
        }
    }
}
