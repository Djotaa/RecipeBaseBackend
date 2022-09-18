using RecipeBase_Backend.Application.Exceptions;
using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.Application.UseCases.Queries.Recipes;
using RecipeBase_Backend.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.UseCases.Queries.Recipes
{
    public class EfGetRecipeQuery : EfUseCase, IGetRecipeQuery
    {
        public EfGetRecipeQuery(AppDbContext context) : base(context)
        {
        }

        public int Id => 4;

        public string Name => "Ef get Recipe";

        public string Description => "Get single Recipe details by Id.";

        public RecipeDto Execute(int request)
        {
            var recipe = this.DbContext.Recipes.FirstOrDefault(x=> x.IsActive && x.Id == request );

            if (recipe == null)
                throw new EntityNotFoundException();

            var recipeDto = new RecipeDto
            {
                Author = recipe.Author.Username,
                Image = recipe.Image.Path,
                Title = recipe.Title,
                PrepTime = recipe.PrepTime,
                Id = recipe.Id,
                Category = recipe.Category.Name,
                Ingredients = recipe.Ingredients.Where(y => y.IsActive).Select(i => i.Value).ToList(),
                Directions = recipe.Directions.Where(z => z.IsActive).OrderBy(y => y.StepNumber).Select(d => d.Step).ToList(),
                CreatedAt = recipe.CreatedAt,
                CategoryId = recipe.CategoryId
            };

            return recipeDto;
        }
    }
}
