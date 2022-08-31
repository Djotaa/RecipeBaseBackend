using RecipeBase_Backend.Application.Exceptions;
using RecipeBase_Backend.Application.UseCases.Commands.Recipes;
using RecipeBase_Backend.DataAccess;
using System.Linq;

namespace RecipeBase_Backend.Implementation.UseCases.Commands.Recipes
{
    public class EfDeleteRecipe : EfUseCase, IDeleteRecipe
    {
        public EfDeleteRecipe(AppDbContext context) : base(context)
        {
        }

        public int Id => 19;

        public string Name => "Delete Recipe";

        public string Description => "Soft delete Recipe";

        public void Execute(int request)
        {
            var recipe = DbContext.Recipes.FirstOrDefault(x=>x.IsActive && x.Id == request);

            if (recipe == null)
                throw new EntityNotFoundException();

            if (recipe.AuthorId != DbContext.AppUser.Id)
                throw new UseCaseConflictException("Users can only delete their own recipes.");

            DbContext.Favorites.RemoveRange(recipe.Favorites);
            DbContext.Remove(recipe);
            DbContext.SaveChanges();
        }
    }
}
