using KonusarakOgren.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Data.Configurations
{
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.Property(x => x.dateTime).IsRequired();
            builder.Property(x => x.ExamTitle).IsRequired().HasMaxLength(200);
            builder.Property(x => x.ExamParagraph).IsRequired().HasMaxLength(500);
           
        }
    }
}
