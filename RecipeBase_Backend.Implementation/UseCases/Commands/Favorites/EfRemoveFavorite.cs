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
    public class EfRemoveFavorite : EfUseCase, IRemoveFavorite
    {
        public EfRemoveFavorite(AppDbContext context) : base(context)
        {
        }

        public int Id => 17;

        public string Name => "Remove Favorite";

        public string Description => "Remove a recipe from users favorites";

        public void Execute(int request)
        {
            var userId = DbContext.AppUser.Id;
            var recipeId = request;

            var favorite = DbContext.Favorites.Where(x => x.UserId == userId && x.RecipeId == recipeId).FirstOrDefault();

            if (favorite == null)
                throw new EntityNotFoundException();

            DbContext.Favorites.Remove(favorite);
            DbContext.SaveChanges();
        }
    }
}
