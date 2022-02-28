using BarisTutakli.Blog.Application.Interfaces;
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
    class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(UserDbContext context) : base(context)
        {

        }
        public async override Task<Tag> Get(Expression<Func<Tag, bool>> filter)
        {
            return await _dbcontext.Tags.Include(c=>c.Posts).SingleOrDefaultAsync(filter);
        }

        public async override Task<List<Tag>> GetAll(Expression<Func<Tag, bool>> filter = null)
        {
            return filter == null ? await _dbcontext.Tags.Include(c => c.Posts).ToListAsync() : await _dbcontext.Tags.Include(c => c.Posts).Where(filter).ToListAsync();
        }
    }
}
