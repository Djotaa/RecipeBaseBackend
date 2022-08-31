using RecipeBase_Backend.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected EfUseCase(AppDbContext context)
        {
            this.DbContext = context;
        }

        protected AppDbContext DbContext { get; }
    }
}
