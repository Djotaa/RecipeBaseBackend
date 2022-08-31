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

        public PagedResponse<RecipeDto> Execute(PagedSearch request)
        {
            var keyword = request.Keyword;

            var query = this.DbContext.Users.Where(x => x.IsActive && x.Id == DbContext.AppUser.Id).AsQueryable();

            var user = query.FirstOrDefault();

            if (user == null)
                throw new EntityNotFoundException();

            if (!String.IsNullOrWhiteSpace(keyword))
                query = query.Where(x => x.Favorites.Any(f=>f.Recipe.Title.ToLower().Contains(keyword.ToLower())));

            var count = user.Favorites.Count();

            var queryResponse = user.Favorites.Skip((request.PageNo - 1) * request.PerPage).Take(request.PerPage).ToList();


            var favorites = user.Favorites.Select(x => new RecipeDto
            {
                Author = x.Recipe.Author.Username,
                Image = x.Recipe.Image.Path,
                Title = x.Recipe.Title,
                PrepTime = x.Recipe.PrepTime,
                Id = x.Recipe.Id,
                Category = x.Recipe.Category.Name,
                Ingredients = x.Recipe.Ingredients.Select(i => i.Value).ToList(),
                Directions = x.Recipe.Directions.OrderBy(y => y.StepNumber).Select(d => d.Step).ToList()
            }).ToList();

            var response = new PagedResponse<RecipeDto>(request, count);
            response.Items = favorites;

            return response;
        }
    }
}
