using BarisTutakli.Blog.Application.Concrete;
using BarisTutakli.Blog.Application.Interfaces;
using BarisTutakli.Blog.Domain.Common;
using BarisTutakli.Blog.Domain.Entities;
using BarisTutakli.Blog.DomainServices.Interfaces;
using BarisTutakli.Blog.Persistence.Context;
using BarisTutakli.Blog.Persistence.Repositories;
using BarisTutakli.Blog.Persistence.UnitOfWorks;
using BarisTutakli.Blog.WebAPI.Common.Loggers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddDbContext<UserDbContext>(opts => opts.UseSqlServer(configuration["ConnectionString:DBBlog"]));
           services.AddScoped<UserDbContext>();
            // Logging
           
            // Repositories
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton<ILoggerService<BaseEntity>, MongoDBLoggerService<BaseEntity>>();
            //UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
