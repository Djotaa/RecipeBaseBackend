using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RecipeBase_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.DataAccess.Configurations
{
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : Entity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.UpdatedBy).HasMaxLength(30);
            builder.Property(x => x.DeletedBy).HasMaxLength(30);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");

            ConfigureConstraints(builder);
        }

        protected abstract void ConfigureConstraints(EntityTypeBuilder<T> builder);
    }
}
