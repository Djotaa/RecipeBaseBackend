using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Application.UseCases.DTO
{
    public class UserDto : BaseDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; }
    }

    public class SingleUserDto : UserDto
    {
        public IEnumerable<int> FavoritesIds { get; set; }
        public IEnumerable<int> RecipeIds { get; set; }
    }


}

