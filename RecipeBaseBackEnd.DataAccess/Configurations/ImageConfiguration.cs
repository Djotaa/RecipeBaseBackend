using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeBase_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.DataAccess.Configurations
{
    public class ImageConfiguration : EntityConfiguration<Image>
    {
        protected override void ConfigureConstraints(EntityTypeBuilder<Image> builder)
        {
            builder.Property(x => x.Path).HasMaxLength(100).IsRequired();
        }
    }
}
