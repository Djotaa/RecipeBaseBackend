using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Domain
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<UseCase> UseCases { get; set; }
    }
}
