using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Application.UseCases.DTO
{
    public class BaseCategoryDto : BaseDto
    {
        public string Name { get; set; }
    }

    public class CreateCategoryDto
    {
        public string Name { get; set; }
    }

    public class UpdateCategoryDto : CreateCategoryDto
    {
        public int Id { get; set; }
    }

    public class CategoryDto : BaseCategoryDto
    {
        public ICollection<int> RecipeIds { get; set; }
    }
}
