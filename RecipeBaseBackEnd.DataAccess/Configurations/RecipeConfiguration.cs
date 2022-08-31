using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeBase_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.DataAccess.Configurations
{
    public class RecipeConfiguration : EntityConfiguration<Recipe>
    {
        protected override void ConfigureConstraints(EntityTypeBuilder<Recipe> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.PrepTime).HasMaxLength(35).IsRequired();

            builder.HasIndex(x => x.Title).IsUnique();

            builder.HasMany(x => x.Favorites).WithOne(x => x.Recipe).HasForeignKey(x => x.RecipeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x=>x.Ingredients).WithOne(x=>x.Recipe).HasForeignKey(x=>x.RecipeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x=>x.Directions).WithOne(x=>x.Recipe).HasForeignKey(x=>x.RecipeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
