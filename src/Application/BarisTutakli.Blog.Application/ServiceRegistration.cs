using BarisTutakli.Blog.Application.Concrete;
using BarisTutakli.Blog.Application.Interfaces;
using BarisTutakli.Blog.Domain.Common;
using BarisTutakli.Blog.Domain.Entities;
using BarisTutakli.Blog.DomainServices.Interfaces;
using BarisTutakli.Blog.WebAPI.Common.Loggers;
using Blog.Application.Concrete;
using Blog.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ICommentService, CommentService>();
           // services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddSingleton<ILoggerService<BaseEntity>, MongoDBLoggerService<BaseEntity>>();

        }
    }
}
