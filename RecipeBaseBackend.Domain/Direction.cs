using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Domain
{
    public class Direction : Entity
    {
        public string Step { get; set; }
        public int StepNumber { get; set; }
        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
