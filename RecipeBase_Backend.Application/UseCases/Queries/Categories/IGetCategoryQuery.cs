using RecipeBase_Backend.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Application.UseCases.Queries.Categories
{
    public interface IGetCategoryQuery : IQuery<int, CategoryDto>
    {
    }
}
