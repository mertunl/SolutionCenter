using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class AdminService(IAdminDAL adminDAL) : IAdminService
	{
		private readonly IAdminDAL _adminDAL= adminDAL;
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
			throw new NotImplementedException();
		}

		public List<AppUser> TGetListAll()
		{
			throw new NotImplementedException();
		}

		public void TUpdate(AppUser entity)
		{
			throw new NotImplementedException();
		}
	}
}
