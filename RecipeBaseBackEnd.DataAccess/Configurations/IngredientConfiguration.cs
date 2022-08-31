using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeBase_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.DataAccess.Configurations
{
    public class IngredientConfiguration : EntityConfiguration<Ingredient>
    {
        protected override void ConfigureConstraints(EntityTypeBuilder<Ingredient> builder)
        {
            builder.Property(x => x.Value).HasMaxLength(100).IsRequired();
        }
    }
}
