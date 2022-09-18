using RecipeBase_Backend.DataAccess;
using RecipeBase_Backend.Application.UseCases.Queries.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.Application.UseCases.DTO.Searches;
using System.Net.Http.Headers;

namespace RecipeBase_Backend.Implementation.UseCases.Queries.Recipes
{
    public class EfGetRecipesQuery : EfUseCase, IGetRecipesQuery
    {
        public EfGetRecipesQuery(AppDbContext context) : base(context)
        {
        }

        public int Id => 3;

        public string Name => "EF Get recipes";

        public string Description => "Get all recipes using EF";

        public PagedResponse<RecipeDto> Execute(PagedSearch request)
        {
            var keyword = request.Keyword;

            var query = this.DbContext.Recipes.Where(x=>x.IsActive).AsQueryable();

            if (!String.IsNullOrWhiteSpace(keyword))
                query = query.Where(x => x.Title.ToLower().Contains(keyword.ToLower()));

            var count = query.Count();

            var queryResponse = query.Skip((request.PageNo - 1) * request.PerPage).Take(request.PerPage).ToList();

            var recipes = queryResponse.Select(x =>
            {
                var recipe = new RecipeDto
                {
                    Author = x.Author.Username,
                    Image = x.Image.Path,
                    Title = x.Title,
                    PrepTime = x.PrepTime,
                    Id = x.Id,
                    Category = x.Category.Name,
                    Ingredients = x.Ingredients.Where(y=>y.IsActive).Select(i=> i.Value).ToList(),
                    Directions = x.Directions.Where(z => z.IsActive).OrderBy(y=>y.StepNumber).Select(d=>d.Step).ToList(),
                    CategoryId = x.CategoryId,
                    CreatedAt = x.CreatedAt
                };
            return recipe;
            });

            var response = new PagedResponse<RecipeDto>(request, count);
            response.Items = recipes;

            return response;
        }
    }
}
