using RecipeBase_Backend.Application.Exceptions;
using RecipeBase_Backend.Application.UseCases;
using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.Application.UseCases.DTO.Searches;
using RecipeBase_Backend.Application.UseCases.Queries;
using RecipeBase_Backend.DataAccess;
using RecipeBase_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.UseCases.Queries
{
    public class EfGetFavoritesQuery : EfUseCase, IGetFavoritesQuery
    {
        public EfGetFavoritesQuery(AppDbContext context) : base(context)
        {
        }

        public int Id => 15;

        public string Name => "Get Favorites";

        public string Description => "Ef get Favorites of user by his username";

        public PagedResponse<RecipeBlockDto> Execute(PagedSearch request)
        {
            var keyword = request.Keyword;

            var query = this.DbContext.Users.Where(x => x.IsActive && x.Id == DbContext.AppUser.Id).AsQueryable();

            var user = query.FirstOrDefault();

            if (user == null)
                throw new EntityNotFoundException();

            if (!String.IsNullOrWhiteSpace(keyword))
                query = query.Where(x => x.Favorites.Any(f=>f.Recipe.Title.ToLower().Contains(keyword.ToLower())));

            var count = user.Favorites.Where(x=>x.Recipe.IsActive).Count();

            var queryResponse = user.Favorites.Where(x => x.Recipe.IsActive).Skip((request.PageNo - 1) * request.PerPage).Take(request.PerPage).ToList();


            var favorites = queryResponse.Select(x => new RecipeBlockDto
                {
                    Image = x.Recipe.Image.Path,
                    Title = x.Recipe.Title,
                    Id = x.Recipe.Id,
                    Category = x.Recipe.Category.Name,
                    CategoryId = x.Recipe.CategoryId,
                    CreatedAt = x.Recipe.CreatedAt
                }).ToList();

            var response = new PagedResponse<RecipeBlockDto>(request, count);
            response.Items = favorites;

            return response;
        }
    }
}
