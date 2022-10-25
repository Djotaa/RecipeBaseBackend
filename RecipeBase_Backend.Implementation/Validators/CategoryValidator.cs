using FluentValidation;
using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.Validators
{
    public class CategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        public CategoryValidator(AppDbContext dbContext)
        {
            RuleFor(x => x).Cascade(CascadeMode.Stop)
                           .Must(x => x is UpdateCategoryDto ? !dbContext.Categories.Where(c => c.Id != x.Id).Any(y => y.Name == x.Name) : true).WithMessage("Category Name must be unique");

            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                                .NotEmpty().WithMessage("Category name is required.")
                                .MinimumLength(3).WithMessage("Minimum length is 3.")
                                .MaximumLength(50).WithMessage("Maximum length is 50.");
        }
    }
}
