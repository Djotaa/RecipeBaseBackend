using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Domain
{
    public class Message : Entity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MessageContent { get; set; }
    }
}
