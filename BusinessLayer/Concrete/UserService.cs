using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class UserService(IUserDAL userDAL) : IUserService
	{
		private readonly IUserDAL _userDAL=userDAL;
		public AppUser TAdd(AppUser entity)
		{
			throw new NotImplementedException();
		}

		public void TDelete(AppUser entity)
		{
			throw new NotImplementedException();
		}

		public AppUser TGetByID(Guid id)
		{
			return _userDAL.GetByID(id);
		}
        public List<AppUser> GetUser(string id)
        {
            return _userDAL.GetUser(id);
        }
        public List<AppUser> TGetListAll()
		{
			return _userDAL.GetAll();
		}

		public void TUpdate(AppUser entity)
		{
			throw new NotImplementedException();
		}

        public AppUser GetUsers(string id)
        {
            return _userDAL.GetByUser(id);
        }
    }
}
