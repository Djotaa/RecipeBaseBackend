using Microsoft.EntityFrameworkCore;
using RecipeBase_Backend.Application.Exceptions;
using RecipeBase_Backend.Application.UseCases.Commands.Categories;
using RecipeBase_Backend.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.UseCases.Commands.Categories
{
    public class EfDeleteCategory : EfUseCase, IDeleteCategory
    {
        public EfDeleteCategory(AppDbContext context) : base(context)
        {
        }

        public int Id => 13;

        public string Name => "Delete Category";

        public string Description => "Soft delete Category";

        public void Execute(int request)
        {
            var category = this.DbContext.Categories.FirstOrDefault(x => x.Id == request);

            if (category == null)
                throw new EntityNotFoundException();

            if (category.Recipes.Any())
                throw new UseCaseConflictException("Can't delete category because it has recipes linked to it.");

            this.DbContext.Categories.Remove(category);
            this.DbContext.SaveChanges();
        }
    }
}
