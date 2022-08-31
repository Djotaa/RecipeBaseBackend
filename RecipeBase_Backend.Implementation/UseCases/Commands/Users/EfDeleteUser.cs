using RecipeBase_Backend.Application.Exceptions;
using RecipeBase_Backend.Application.UseCases.Commands.Users;
using RecipeBase_Backend.DataAccess;
using RecipeBase_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.UseCases.Commands.Users
{
    public class EfDeleteUser : EfUseCase, IDeleteUser
    {
        public EfDeleteUser(AppDbContext context) : base(context)
        {
        }

        public int Id => 14;

        public string Name => "Delete User";

        public string Description => "Soft delete a User";

        public void Execute(int request)
        {
            var user = DbContext.Users.Where(x => x.IsActive).FirstOrDefault(x => x.Id == request);

            if (user == null)
                throw new EntityNotFoundException();

            if (user.Recipes.Any())
                throw new UseCaseConflictException("Can't delete user because it has recipes linked to it.");

            DbContext.Users.Remove(user);
            DbContext.Favorites.RemoveRange(user.Favorites);
            DbContext.SaveChanges();
        }
    }
}
