using BarisTutakli.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.DomainServices.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
    }
}
