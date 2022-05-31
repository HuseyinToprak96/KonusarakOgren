using KonusarakOgren.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Data.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(25).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(25).IsRequired();
            builder.Property(x => x.Password).IsRequired().HasMaxLength(25);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(25);

        }
    }
}
