using BarisTutakli.Blog.Application.Interfaces;
using BarisTutakli.Blog.Application.Wrappers;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.WebAPI.Common.Loggers
{
    public class MongoDBLoggerService<T> : ILoggerService<T> where T : class
    {
       
        private readonly IConfiguration _configuration;
        private readonly IMongoCollection<Logs<T>> _booksCollection;
        public MongoDBLoggerService(IConfiguration configuration)
        {
            _configuration = configuration;
            var mongoClient = new MongoClient(
                configuration["MongoDBLogging:ConnectionString"]);

            var mongoDatabase = mongoClient.GetDatabase(
                configuration["MongoDBLogging:DatabaseName"]);

            _booksCollection = mongoDatabase.GetCollection<Logs<T>>(configuration["MongoDBLogging:CollectionName"]);
        }
        public void Log(Logs<T> logs)
        {
            _booksCollection.InsertOne(logs);
        }

      
    }
}
