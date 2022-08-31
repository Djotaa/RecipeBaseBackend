using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Application.UseCases.Queries
{
    public interface IGetFavoritesQuery : IQuery<PagedSearch, PagedResponse<RecipeDto>>
    {

    }
}
