using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeBase_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.DataAccess.Configurations
{
    internal class DirectionConfiguration : EntityConfiguration<Direction>
    {
        protected override void ConfigureConstraints(EntityTypeBuilder<Direction> builder)
        {
            builder.Property(x => x.Step).IsRequired();
            builder.Property(x => x.StepNumber).IsRequired();
        }
    }
}
