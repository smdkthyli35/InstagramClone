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
    public class LikeEntityConfiguration : BaseEntityConfiguration<Like>
    {
        public override void Configure(EntityTypeBuilder<Like> builder)
        {
            base.Configure(builder);

            builder.ToTable("like", InstagramCloneDbContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.Post).WithMany(i => i.Likes).HasForeignKey(i => i.PostId);
        }
    }
}
