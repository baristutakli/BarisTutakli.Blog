using BarisTutakli.Blog.Domain.Entities;
using BarisTutakli.Blog.DomainServices.Interfaces;
using BarisTutakli.Blog.Persistence.Context;
using BarisTutakli.Blog.Persistence.Repositories;
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

        public UnitOfWork(UserDbContext dbcontext, IPostRepository posts, ICommentRepository comments, ICategoryRepository categories, ITagRepository tags, IUserRepository users)
        {
            _dbcontext = dbcontext;
            Posts = posts;
            Comments = comments;
            Categories = categories;
            Tags = tags;
            Users = users;
        }

        public int Complete()
        {
            return _dbcontext.SaveChanges();
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}
