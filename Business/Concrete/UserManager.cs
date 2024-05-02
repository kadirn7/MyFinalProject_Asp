using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        IUserDal _userdal;
        public UserManager(IUserDal userdal)
        {
            _userdal = userdal;
        }
        public List<OperationClaim>GetClaims(User user)
        {
            return _userdal.GetClaims(user);
        }
        public void Add(User user)
        {
            _userdal.Add(user);
        }
        public User GetByMail(string mail) 
        {
            return _userdal.Get(u => u.Email == mail);
        }
    }
}
