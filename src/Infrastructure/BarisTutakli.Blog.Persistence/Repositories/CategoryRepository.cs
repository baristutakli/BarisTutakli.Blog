using BarisTutakli.Blog.Application.Interfaces;
using BarisTutakli.Blog.Application.Wrappers;
using BarisTutakli.Blog.Domain.Entities;
using BarisTutakli.Blog.DomainServices.Interfaces;
using BarisTutakli.Blog.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        //private readonly ILoggerService<string> _loggerService;
        private readonly ICrossCuttingConcernsFactory<string> _crossCuttingConcernsFactory;
        public CategoryRepository(UserDbContext context,  ICrossCuttingConcernsFactory<string> crossCuttingConcernsFactory) : base(context)
        {
            _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
        }
        public async override Task<Category> Get(Expression<Func<Category, bool>> filter)
        {
            return await _dbcontext.Categories.Include(c=>c.Posts).SingleOrDefaultAsync(filter);
        }

        public async override Task<List<Category>> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            
           
            return filter == null ? await _dbcontext.Categories.Include(c => c.Posts).ToListAsync() : await _dbcontext.Categories.Include(c => c.Posts).Where(filter).ToListAsync();
        }
        // Save a category in mongodb before deleting it
        public override void Delete(Category entity)
        {
            _crossCuttingConcernsFactory.CreateMongoDBLogging().Log(new Logs<string>(data: System.Text.Json.JsonSerializer.Serialize(entity)));
            base.Delete(entity);
        }
        public async Task<List<Category>> GetTitles(Expression<Func<Category, bool>> filter = null)
        {
            return filter == null ? await _dbcontext.Categories.ToListAsync() : await _dbcontext.Categories.Where(filter).ToListAsync();
        }
    }
}
