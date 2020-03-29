using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Whitelabel.Service.Domain.Entities;

namespace Whitelabel.Service.APP.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u).
                NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentException("Can't found the object.");
                });

            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Is necessary to inform the Name.")
                .NotNull().WithMessage("Is necessary to inform the Name");
        }
    }
}
