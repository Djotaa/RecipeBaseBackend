using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Domain
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
