using BarisTutakli.Blog.Application.Concrete;
using BarisTutakli.Blog.Application.Interfaces;
using BarisTutakli.Blog.Domain.Common;
using BarisTutakli.Blog.Domain.Entities;
using BarisTutakli.Blog.DomainServices.Interfaces;
using BarisTutakli.Blog.WebAPI.Common.Loggers;
using Blog.Application.Concrete;
using Blog.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ICommentService, CommentService>();
           // services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();


            services.AddScoped<IAuthenticateService, AuthenticateService>();

            services.AddSingleton<ILoggerService<BaseEntity>, MongoDBLoggerService<BaseEntity>>();


    
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
     .AddJwtBearer(options =>
     {
         options.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidateIssuerSigningKey = true,
             ValidIssuer = configuration["Jwt:ValidIssuer"],
             ValidAudience = configuration["Jwt:ValidAudience"],
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]))
         };
     });

            // Token Generator
            services.AddScoped<ITokenService, TokenService>();

        }
    }
}
