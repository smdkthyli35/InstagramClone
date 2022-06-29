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
    public class CommentEntryConfiguration : BaseEntityConfiguration<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            base.Configure(builder);

            builder.ToTable("comment", InstagramCloneDbContext.DEFAULT_SCHEMA);

            builder.Property(i => i.Description).IsRequired().HasMaxLength(100);

            builder.HasOne(i => i.Post).WithMany(i => i.Comments).HasForeignKey(i => i.PostId);
        }
    }
}
