using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Application.UseCases.DTO
{
    public class RecipeBlockDto : BaseDto
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class RecipeDto : RecipeBlockDto
    {
        public string PrepTime { get; set; }
        public string Author { get; set; }
        public List<string> Directions { get; set; }
        public List<string> Ingredients { get; set; }
    }

    public class CreateRecipeDto
    {
        public string Title { get; set; }
        public string PrepTime { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Directions { get; set; }
    }

    public class CreateRecipeDtoWithImage
    {
        public string Title { get; set; }
        public string PrepTime { get; set; }
        public IFormFile Image { get; set; }
        public int CategoryId { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Directions { get; set; }
    }

    public class UpdateRecipeDtoWithImage : CreateRecipeDtoWithImage
    {
        public int Id { get; set; }
    }

    public class UpdateRecipeDto : CreateRecipeDto
    {
        public int Id { get; set; }
    }
}
