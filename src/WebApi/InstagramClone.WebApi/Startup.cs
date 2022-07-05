using InstagramClone.Application;
using InstagramClone.Infrastructure;
using InstagramClone.Infrastructure.Extensions;
using InstagramClone.Infrastructure.Services.Storage.Azure;
using InstagramClone.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddPersistenceServices(Configuration);
            services.AddApplicationServices();
            services.AddInfrastructureServices();

            services.AddStorage<AzureStorage>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InstagramClone.WebApi", Version = "v1" });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("Admin", options =>
                 {
                     options.TokenValidationParameters = new()
                     {
                         ValidateAudience = true,
                         ValidateIssuer = true,
                         ValidateIssuerSigningKey = true,
                         ValidateLifetime = true,

                         ValidAudience = Configuration["Token:Audience"],
                         ValidIssuer = Configuration["Token:Issuer"],
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]))
                     };
                 });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InstagramClone.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.ConfigureExceptionHandling(env.IsDevelopment());

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
