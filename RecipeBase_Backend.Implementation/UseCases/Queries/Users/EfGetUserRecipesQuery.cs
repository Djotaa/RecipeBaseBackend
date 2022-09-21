using RecipeBase_Backend.Application.Exceptions;
using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.Application.UseCases.DTO.Searches;
using RecipeBase_Backend.Application.UseCases.Queries.Recipes;
using RecipeBase_Backend.DataAccess;
using RecipeBase_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.UseCases.Queries.Users
{
    public class EfGetUserRecipesQuery : EfUseCase, IGetUserRecipesQuery
    {
        public EfGetUserRecipesQuery(AppDbContext context) : base(context)
        {
        }

        public int Id => 21;

        public string Name => "Ef get current users recipes";

        public string Description => "Get all recipes created by logged in user.";

        public PagedResponse<RecipeBlockDto> Execute(PagedSearch request)
        {
            

            var user = this.DbContext.Users.Where(x => x.IsActive && x.Id == DbContext.AppUser.Id).FirstOrDefault();

            if (user == null)
                throw new EntityNotFoundException();

            var query = user.Recipes.Where(x => x.IsActive).AsQueryable();

            var count = query.Count();

            var queryResponse = query.Skip((request.PageNo - 1) * request.PerPage).Take(request.PerPage).ToList();

            var recipes = queryResponse.Select(x =>
            {
                var recipe = new RecipeBlockDto
                {
                    Image = x.Image.Path,
                    Title = x.Title,
                    Id = x.Id,
                    Category = x.Category.Name,
                    CategoryId = x.CategoryId,
                    CreatedAt = x.CreatedAt
                };
                return recipe;
            });

            var response = new PagedResponse<RecipeBlockDto>(request, count);
            response.Items = recipes;

            return response;
        }
    }
}
