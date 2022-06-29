using InstagramClone.Domain.Entities;
using InstagramClone.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Persistence.EntityConfigurations
{
    public class ProfileEntityConfiguration : BaseEntityConfiguration<Profile>
    {
        public override void Configure(EntityTypeBuilder<Profile> builder)
        {
            base.Configure(builder);

            builder.ToTable("profile", InstagramCloneDbContext.DEFAULT_SCHEMA);

            builder.Property(i => i.UserName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(i => i.Biography)
                .HasMaxLength(100);
        }
    }
}
