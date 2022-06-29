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
    public class PostEntityConfiguration : BaseEntityConfiguration<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            base.Configure(builder);

            builder.ToTable("post", InstagramCloneDbContext.DEFAULT_SCHEMA);

            builder.Property(i => i.Description).HasMaxLength(500);
        }
    }
}
