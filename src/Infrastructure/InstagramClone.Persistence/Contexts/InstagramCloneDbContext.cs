using InstagramClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Persistence.Contexts
{
    public class InstagramCloneDbContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "dbo";

        public InstagramCloneDbContext()
        {
        }

        public InstagramCloneDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<PostImageFile> PostImageFiles { get; set; }
        public DbSet<ProfileImageFile> ProfileImageFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //public override int SaveChanges()
        //{
        //    OnBeforeSave();
        //    return base.SaveChanges();
        //}

        //public override int SaveChanges(bool acceptAllChangesOnSuccess)
        //{
        //    OnBeforeSave();
        //    return base.SaveChanges(acceptAllChangesOnSuccess);
        //}

        //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        //{
        //    OnBeforeSave();
        //    return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSave()
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                    _ => DateTime.UtcNow
                };
            }
        }
    }
}
