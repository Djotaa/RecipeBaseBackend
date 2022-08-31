using FluentValidation;
using RecipeBase_Backend.Application.Exceptions;
using RecipeBase_Backend.Application.UseCases.Commands.Recipes;
using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.DataAccess;
using RecipeBase_Backend.Domain;
using RecipeBase_Backend.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.UseCases.Commands.Recipes
{
    public class EfUpdateRecipe : EfUseCase, IUpdateRecipe
    {
        public RecipeValidator validator { get; set; }

        public EfUpdateRecipe(AppDbContext context, RecipeValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 20;

        public string Name => "Update recipe";

        public string Description => "Users can update their recipes";

        public void Execute(UpdateRecipeDto request)
        {
            validator.ValidateAndThrow(request);

            var recipe = DbContext.Recipes.Where(x=>x.IsActive).FirstOrDefault(y=>y.Id == request.Id);

            if (recipe == null)
                throw new EntityNotFoundException();

            if (recipe.AuthorId != DbContext.AppUser.Id)
                throw new UseCaseConflictException("Users can only update their own recipes.");

            recipe.Title = request.Title;
            recipe.PrepTime = request.PrepTime;
            recipe.CategoryId = request.CategoryId;
            recipe.Image.Path = request.Image;
            DbContext.Ingredients.RemoveRange(recipe.Ingredients);
            DbContext.Directions.RemoveRange(recipe.Directions);
            recipe.Directions = request.Directions.Select(d => new Direction
            {
                Step = d.Step,
                StepNumber = d.StepNumber
            }).ToList();
            recipe.Ingredients = request.Ingredients.Select(x => new Ingredient
            {
                Value = x
            }).ToList();

            DbContext.SaveChanges();
        }
    }
}
