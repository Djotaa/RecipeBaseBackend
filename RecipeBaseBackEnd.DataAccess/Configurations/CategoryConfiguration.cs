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
    internal class CategoryConfiguration : EntityConfiguration<Category>
    {
        protected override void ConfigureConstraints(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x=>x.Recipes).WithOne(x=>x.Category).HasForeignKey(x=>x.CategoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
