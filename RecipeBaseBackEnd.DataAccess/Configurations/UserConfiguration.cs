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
    internal class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureConstraints(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Username).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(100).IsRequired();

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Username).IsUnique();

            builder.HasMany(x=> x.Recipes).WithOne(x=>x.Author).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x=>x.Favorites).WithOne(x=>x.User).HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x=>x.UseCases).WithOne(x=>x.User).HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
