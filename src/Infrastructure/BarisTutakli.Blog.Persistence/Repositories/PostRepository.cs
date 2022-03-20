using BarisTutakli.Blog.DomainServices.Interfaces;
using BarisTutakli.Blog.Domain.Entities;
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
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(UserDbContext context) : base(context)
        {

        }
        public async override Task<Post> Get(Expression<Func<Post, bool>> filter)
        {
            return await _dbcontext.Posts.Include(c=>c.Tags).Include(c => c.Categories).AsSplitQuery().SingleOrDefaultAsync(filter);
        }
        public async override Task<List<Post>> GetAll(Expression<Func<Post, bool>> filter = null)
        {
            return filter == null ? await _dbcontext.Posts.Include(c => c.Tags).Include(c => c.Categories).AsSplitQuery().ToListAsync() : await _dbcontext.Posts.Include(c => c.Tags).Include(c => c.Categories).Where(filter).AsSplitQuery().ToListAsync();
        }
    }
}
