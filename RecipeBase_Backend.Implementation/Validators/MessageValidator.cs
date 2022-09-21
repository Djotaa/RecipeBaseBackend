using FluentValidation;
using RecipeBase_Backend.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.Validators
{
    public class MessageValidator : AbstractValidator<CreateMessageDto>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid Email format.");

            var imePrezimeRegex = @"^\p{Lu}\p{Ll}{1,20}(\s\p{L}{2,20}){1,}$";
            RuleFor(x => x.FullName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Full Name is required.")
                .Matches(imePrezimeRegex).WithMessage("Full Name is invalid.");

            RuleFor(x => x.Message)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Message is required.")
                .MinimumLength(10).WithMessage("Minimum message length is 10 characters");
        }
    }
}
