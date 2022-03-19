using BarisTutakli.Blog.Application;
using BarisTutakli.Blog.Application.Concrete;
using BarisTutakli.Blog.Application.Interfaces;
using BarisTutakli.Blog.Domain.Entities;
using BarisTutakli.Blog.Infrastructure;
using BarisTutakli.Blog.Persistence;
using BarisTutakli.Blog.Persistence.Context;
using BarisTutakli.Blog.WebAPI.Common.Loggers;
using BarisTutakli.Blog.WebAPI.Common.Settings;
using BarisTutakli.Blog.WebAPI.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.WebAPI
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BarisTutakli.Blog.WebAPI", Version = "v1" });
            });
            //Persistence dependency resolver
            services.AddPersistenceServices(Configuration);
            // Application leyer dependency resolver
            services.AddApplicationServices(Configuration);
            // RabittMQService 
            //services.AddInfrastructureServices(Configuration);
            services.AddSingleton<ILoggerService<string>, MongoDBLoggerService<string>>();
            services.AddSingleton<ICrossCuttingConcernsFactory<string>, CrossCuttingConcernsFactory<string>>();
            // services.AddSingleton<ILoggerService<>, FileLoggerService>();
            services.Configure<MongoDatabaseSettings>(
               Configuration.GetSection("LoggingDatabase"));

            services.AddIdentity<User, IdentityRole>(option =>
            {
                option.Lockout.AllowedForNewUsers = true;
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                option.Lockout.MaxFailedAccessAttempts = 3;
            }).AddEntityFrameworkStores<UserDbContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BarisTutakli.Blog.WebAPI v1"));
            }

            app.UseRouting();
            app.UseCustomExceptionMiddleware();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
