using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Application.UseCases.DTO
{
    public class RegisterDto : UserDto
    {
        public string Password { get; set; }
    }
}
