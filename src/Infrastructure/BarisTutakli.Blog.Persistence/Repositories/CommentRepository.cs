
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
   public  class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(UserDbContext context) : base(context)
        {

        }
        public async override Task<Comment> Get(Expression<Func<Comment, bool>> filter)
        {
            return await _dbcontext.Comments.Include(c=>c.User).SingleOrDefaultAsync(filter);
        }

        public async override Task<List<Comment>> GetAll(Expression<Func<Comment, bool>> filter = null)
        {
            return filter == null ? await _dbcontext.Comments.Include(c => c.User).ToListAsync() : await _dbcontext.Comments.Include(c => c.User).Where(filter).ToListAsync();
        }
    }
}
