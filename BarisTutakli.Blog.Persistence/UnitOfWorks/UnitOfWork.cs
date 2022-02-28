using BarisTutakli.Blog.Application.Interfaces;
using BarisTutakli.Blog.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly UserDbContext _dbcontext;
        public IPostRepository Posts { get; private set; }

        public ICommentRepository Comments { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public ITagRepository Tags { get; private set; }

        public IUserRepository Users { get; private set; }
        public UnitOfWork(UserDbContext context)
        {
            _dbcontext = context;

        }
        public int Complete()
        {
            return _dbcontext.SaveChanges();
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }

        Task<int> IUnitOfWork.Complete()
        {
            throw new NotImplementedException();
        }
    }
}
