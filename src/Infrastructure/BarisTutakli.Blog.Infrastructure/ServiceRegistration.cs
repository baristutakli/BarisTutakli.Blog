using BarisTutakli.Blog.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarisTutakli.Blog.Infrastructure.RabbitMQServices;
namespace BarisTutakli.Blog.Infrastructure
{
   public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddScoped<IRabbitMQService, RabbitMQService>();
        }
    }
}
