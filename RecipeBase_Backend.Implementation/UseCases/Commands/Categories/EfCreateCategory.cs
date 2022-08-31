using FluentValidation;
using RecipeBase_Backend.Application.UseCases.Commands.Categories;
using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.DataAccess;
using RecipeBase_Backend.Domain;
using RecipeBase_Backend.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.UseCases.Commands.Categories
{
    public class EfCreateCategory : EfUseCase, ICreateCategory
    {
        public CategoryValidator validator { get; set; }
        public EfCreateCategory(AppDbContext context, CategoryValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 11;

        public string Name => "Create Category";

        public string Description => "Insert new Category";

        public void Execute(CreateCategoryDto request)
        {
            validator.ValidateAndThrow(request);

            var category = new Category
            {
                Name = request.Name
            };

            this.DbContext.Categories.Add(category);
            this.DbContext.SaveChanges();
        }
    }
}
