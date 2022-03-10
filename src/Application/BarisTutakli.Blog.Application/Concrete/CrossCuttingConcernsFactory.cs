using BarisTutakli.Blog.Application.Interfaces;
using BarisTutakli.Blog.WebAPI.Common.Loggers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Concrete
{
    public class CrossCuttingConcernsFactory<T> : ICrossCuttingConcernsFactory<T> where T : class
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public CrossCuttingConcernsFactory(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }
        public ILoggerService<T> CreateFileLogging()
        {
            return new FileLoggerService<T>(_hostingEnvironment);
        }

        public ILoggerService<T> CreateMongoDBLogging()
        {
            return new MongoDBLoggerService<T>(_configuration);
        }
    }
}
