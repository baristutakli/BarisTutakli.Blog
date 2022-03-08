using BarisTutakli.Blog.DomainServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Persistence.Repositories
{
    public class LoggingRepositoryDecorator<TEntity> : DecoratorRepository<TEntity> where TEntity : class
    {
        readonly IRepository<TEntity> _repository;
        public LoggingRepositoryDecorator(IRepository<TEntity> repository) : base(repository)
        {
            _repository = repository;
        }
        public override void Delete(TEntity entity)
        {
            //Will be added logger 
            base.Delete(entity);
            Console.WriteLine($"Entity Deleted");
        }

        public override void Update(TEntity entity)
        {
            base.Update(entity);
            Console.WriteLine($"Entity Updated");
        }
    }
}
