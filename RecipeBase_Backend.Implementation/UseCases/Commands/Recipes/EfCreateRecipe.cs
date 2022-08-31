using FluentValidation;
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
    public class EfCreateRecipe : EfUseCase, ICreateRecipe
    {
        public RecipeValidator validator;
        public EfCreateRecipe(AppDbContext context, RecipeValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 18;

        public string Name => "Create Recipe";

        public string Description => "Insert new Recipe";

        public void Execute(CreateRecipeDto request)
        {
            validator.ValidateAndThrow(request);

            var recipe = new Recipe
            {
                Title = request.Title,
                PrepTime = request.PrepTime,
                CategoryId = request.CategoryId,
                Ingredients = request.Ingredients.Select(x => new Ingredient
                {
                    Value = x
                }).ToList(),
                Image = new Image { Path = request.Image },
                Directions = request.Directions.Select(d => new Direction
                {
                    Step = d.Step,
                    StepNumber = d.StepNumber
                }).ToList(),
                AuthorId = DbContext.AppUser.Id
            };

            DbContext.Recipes.Add(recipe);
            DbContext.SaveChanges();
        }
    }
}
