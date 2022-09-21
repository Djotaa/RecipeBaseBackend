using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.Validators
{
    public class RecipeValidator : AbstractValidator<CreateRecipeDtoWithImage>
    {
        public RecipeValidator(AppDbContext dbContext)
        {
            RuleFor(x => x).Cascade(CascadeMode.Stop)
                .Must(x => x is UpdateRecipeDtoWithImage || !dbContext.Recipes.Any(p => p.Title == x.Title)).WithMessage("Recipe with this title already exists or is inactive.");


            RuleFor(x => x.Title).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Recipe title is required.")
                .MinimumLength(3).WithMessage("Minimum title length is 3 characters.")
                .MaximumLength(50).WithMessage("Maximum title length is 50 characters.");

            RuleFor(x => x.PrepTime).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Recipe preparation time is required.")
                .MinimumLength(3).WithMessage("Minimum preparation time length is 3 characters.")
                .MaximumLength(50).WithMessage("Maximum preparation time length is 35 characters.");

            RuleFor(x => x.CategoryId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Category Id is required.")
                .Must(x => dbContext.Categories.Any(c => c.IsActive && c.Id == x)).WithMessage("Category Id {PropertyValue} doesn't exist");

            RuleFor(x => x.Ingredients).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Recipe ingredients are required.");

            RuleFor(x => x.Directions).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Recipe directions are required.");

            RuleForEach(x => x.Ingredients).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Ingredients are required and can't be empty.")
                .MinimumLength(4).WithMessage("Minimum ingredient length is 4 characters")
                .MaximumLength(100).WithMessage("Maximum ingredient length is 100 characters");

            RuleForEach(x => x.Directions).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Directions are required and can't be empty.")
                .MinimumLength(5).WithMessage("Minimum length of step is 5 characters.");
        }
    }

    //public class DirectionValidator : AbstractValidator<DirectionDto>
    //{
    //    public DirectionValidator()
    //    {
    //        RuleFor(x => x.Step).Cascade(CascadeMode.Stop)
    //            .NotEmpty().WithMessage("Directions are required and can't be empty")
    //            .MinimumLength(5).WithMessage("Minimum length of step is 5 characters.");

    //        RuleFor(x => x.StepNumber).Cascade(CascadeMode.Stop)
    //            .NotEmpty().WithMessage("Step number is required.")
    //            .Must(x => x > 0).WithMessage("Step number must be greater than 0");
    //    }
    //}
}
