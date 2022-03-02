using Blog.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Application.Concrete
{
    //public class UserService : IUserService
    //{
    //    private readonly IUserDal _userDal;
    //    public UserService(IUserDal userDal)
    //    {
    //        _userDal = userDal;
    //    }
    //    public bool Add(CreateUserModel createUserModel)
    //    {
    //        // Düzenlenecek
    //        return true;
    //    }

    //    public bool Delete(User user)
    //    {
    //        var selectedUser = _userDal.Get(p => p.Id == user.Id);
    //        return _userDal.Delete(selectedUser);
    //    }

    //    public User Get(Expression<Func<User, bool>> filter)
    //    {
    //        return _userDal.Get(filter);
    //    }

    //    public List<User> GetAll(Expression<Func<User, bool>> filter = null)
    //    {
    //        return _userDal.GetAll(filter);
    //    }

    //    public bool Update(int id, User user)
    //    {
    //        // Düzenlenecek
    //        var selectedUSer = _userDal.Get(p => p.Id == id);
    
    //        return _userDal.Delete(selectedUSer);
    //    }
    //}
}
