using KonusarakOgren.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(x => x.question).IsRequired().HasMaxLength(150);
            builder.Property(x => x.A).IsRequired().HasMaxLength(50);
            builder.Property(x => x.B).IsRequired().HasMaxLength(50);
            builder.Property(x => x.C).IsRequired().HasMaxLength(50);
            builder.Property(x => x.D).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Answer).IsRequired().HasMaxLength(1);
        }
    }
}
