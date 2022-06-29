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
    public class ReplyEntityConfiguration : BaseEntityConfiguration<Reply>
    {
        public override void Configure(EntityTypeBuilder<Reply> builder)
        {
            base.Configure(builder);

            builder.ToTable("reply", InstagramCloneDbContext.DEFAULT_SCHEMA);

            builder.Property(i => i.Message).IsRequired().HasMaxLength(300);

            builder.HasOne(i => i.Post).WithMany(i => i.Replies).HasForeignKey(i => i.PostId);
        }
    }
}
