using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RecipeBase_Backend.Application.Exceptions;
using RecipeBase_Backend.Application.UseCases;
using RecipeBase_Backend.Application.UseCases.Commands.Categories;
using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.DataAccess;
using RecipeBase_Backend.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.UseCases.Commands.Categories
{
    public class EfUpdateCategory : EfUseCase, IUpdateCategory
    {
        public CategoryValidator validator { get; set; }

        public EfUpdateCategory(AppDbContext dbContext, CategoryValidator validator)
            : base(dbContext)
        {
            this.validator = validator;
        }
        public int Id => 12;

        public string Name => "Update Category";
        public string Description => "Update existing Category";

        public void Execute(UpdateCategoryDto request)
        {
            this.validator.ValidateAndThrow(request);

            var category = this.DbContext.Categories.Where(x=>x.IsActive).FirstOrDefault(x => x.Id == request.Id);

            if (category == null)
                throw new EntityNotFoundException();

            category.Name = request.Name;

            this.DbContext.SaveChanges();


        }
    }
}
