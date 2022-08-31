using RecipeBase_Backend.Application.Exceptions;
using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.Application.UseCases.Queries.Users;
using RecipeBase_Backend.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.UseCases.Queries.Users
{
    public class EfGetUserQuery : EfUseCase, IGetUserQuery
    {
        public EfGetUserQuery(AppDbContext context) : base(context)
        {
        }

        public int Id => 6;

        public string Name => "Get User";

        public string Description => "Get user by Id and his favorites and recipes.";

        public SingleUserDto Execute(int request)
        {
            var user = this.DbContext.Users.FirstOrDefault(u => u.IsActive && u.Id == request);

            if(user == null)
                throw new EntityNotFoundException();

            var userDto = new SingleUserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Username = user.Username,
                Email = user.Email,
                UseCaseIds = user.UseCases.Select(x => x.UseCaseId).ToList(),
                RecipeIds = user.Recipes.Select(r => r.Id).ToList(),
                FavoritesIds = user.Favorites.Select(x => x.Recipe.Id).ToList()
            };

            return userDto;
        }
    }
}
