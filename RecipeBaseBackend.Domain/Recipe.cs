using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Domain
{
    public class Recipe : Entity
    {
        public string Title { get; set; }
        public string PrepTime { get; set; }
        public int ImageId { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Image Image { get; set; }
        public virtual User Author { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<Direction> Directions { get; set; }

    }
}
