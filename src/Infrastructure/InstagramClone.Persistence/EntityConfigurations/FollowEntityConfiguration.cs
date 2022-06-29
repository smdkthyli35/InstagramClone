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
    public class FollowEntityConfiguration : BaseEntityConfiguration<Follow>
    {
        public override void Configure(EntityTypeBuilder<Follow> builder)
        {
            base.Configure(builder);

            builder.ToTable("follow", InstagramCloneDbContext.DEFAULT_SCHEMA);

            builder.Property(i => i.FollowedCount).IsRequired();
            builder.Property(i => i.FollowerCount).IsRequired();
        }
    }
}
