using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeBase_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.DataAccess.Configurations
{
    public class MessageConfiguration : EntityConfiguration<Message>
    {
        protected override void ConfigureConstraints(EntityTypeBuilder<Message> builder)
        {
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.FullName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.MessageContent).HasMaxLength(200).IsRequired();
        }
    }
}
