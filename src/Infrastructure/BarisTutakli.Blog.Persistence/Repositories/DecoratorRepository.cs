using BarisTutakli.Blog.DomainServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Persistence.Repositories
{
    public class DecoratorRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        readonly IRepository<TEntity> _repository;

        public DecoratorRepository(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public virtual  Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
           return  _repository.Get(filter);
        }

        public virtual Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return _repository.GetAll(filter);
        }

        public virtual  Task<TEntity> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
        }
    }
}
