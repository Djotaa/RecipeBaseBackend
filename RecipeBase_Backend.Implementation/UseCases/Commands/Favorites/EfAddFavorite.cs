using RecipeBase_Backend.Application.Exceptions;
using RecipeBase_Backend.Application.UseCases.Commands.Favorites;
using RecipeBase_Backend.DataAccess;
using RecipeBase_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.UseCases.Commands.Favorites
{
    public class EfAddFavorite : EfUseCase, IAddFavorite
    {
        public EfAddFavorite(AppDbContext context) : base(context)
        {
        }

        public int Id => 16;

        public string Name => "Add Favorite";

        public string Description => "Add a recipe to users favorites";

        public void Execute(int request)
        {
            var userId = DbContext.AppUser.Id;
            var recipeId = request;

            if (!DbContext.Recipes.Any(x => x.IsActive && x.Id == recipeId))
                throw new EntityNotFoundException();

            if (DbContext.Favorites.Any(x => x.UserId == userId && x.RecipeId == recipeId))
                throw new UseCaseConflictException("Recipe is already in users favorites.");

            DbContext.Favorites.Add(new Favorite { RecipeId = recipeId, UserId = userId });
            DbContext.SaveChanges();
        }
    }
}
