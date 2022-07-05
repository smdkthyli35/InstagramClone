using InstagramClone.Application.Interfaces.Repositories;
using InstagramClone.Domain.Entities.Identity;
using InstagramClone.Persistence.Contexts;
using InstagramClone.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InstagramCloneDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<InstagramCloneDbContext>();

            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IFollowRepository, FollowRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<IPostImageFileRepository, PostImageFileRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IProfileImageFileRepository, ProfileImageFileRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IReplyRepository, ReplyRepository>();
            services.AddScoped<IEmailConfirmationRepository, EmailConfirmationRepository>();
        }
    }
}
