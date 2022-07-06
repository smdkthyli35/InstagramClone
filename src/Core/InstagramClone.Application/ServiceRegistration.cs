using FluentValidation;
using InstagramClone.Application.Pipelines.Caching;
using InstagramClone.Application.Pipelines.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(assembly);
            services.AddAutoMapper(assembly);
            services.AddValidatorsFromAssembly(assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        }
    }
}
