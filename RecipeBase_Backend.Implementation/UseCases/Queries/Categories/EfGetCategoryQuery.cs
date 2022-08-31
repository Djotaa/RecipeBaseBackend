using RecipeBase_Backend.Application.Exceptions;
using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.Application.UseCases.Queries.Categories;
using RecipeBase_Backend.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.UseCases.Queries.Categories
{
    public class EfGetCategoryQuery : EfUseCase, IGetCategoryQuery
    {
        public EfGetCategoryQuery(AppDbContext context) : base(context)
        {
        }

        public int Id => 8;

        public string Name => "Get Category";

        public string Description => "Get Category and its Recipes by Id";

        public CategoryDto Execute(int request)
        {
            var category = this.DbContext.Categories.FirstOrDefault(c => c.IsActive && c.Id == request);

            if (category == null)
                throw new EntityNotFoundException();

            var categoryDto = new CategoryDto
            {
                Name = category.Name,
                Id = category.Id,
                RecipeIds = category.Recipes.Select(x => x.Id).ToList()
            };

            return categoryDto;
        }
    }
}
