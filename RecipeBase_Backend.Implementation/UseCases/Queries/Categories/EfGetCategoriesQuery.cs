using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.Application.UseCases.DTO.Searches;
using RecipeBase_Backend.Application.UseCases.Queries.Categories;
using RecipeBase_Backend.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.UseCases.Queries.Categories
{
    public class EfGetCategoriesQuery : EfUseCase, IGetCategoriesQuery
    {
        public EfGetCategoriesQuery(AppDbContext context) : base(context)
        {
        }

        public int Id => 7;

        public string Name => "Get Categories";

        public string Description => "Ef get all Categories";

        public PagedResponse<BaseCategoryDto> Execute(PagedSearch request)
        {

            var keyword = request.Keyword;

            var query = this.DbContext.Categories.Where(x=>x.IsActive).AsQueryable();

            if (!String.IsNullOrWhiteSpace(keyword))
                query = query.Where(x => x.Name.ToLower().Contains(keyword.ToLower()));

            var count = query.Count();

            var queryResponse = query.Skip((request.PageNo - 1) * request.PerPage).Take(request.PerPage).ToList();

            var categories = queryResponse.Select(x => new BaseCategoryDto
            {
                Id = x.Id,
                Name = x.Name
            });

            var response = new PagedResponse<BaseCategoryDto>(request, count);
            response.Items = categories;

            return response;
        }
    }
}
