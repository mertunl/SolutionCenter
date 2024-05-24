using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entites;
using EntityLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class ApplicationService(IApplicationDAL applicationDAL) : IApplicationService
	{
		private readonly IApplicationDAL _applicationDAL = applicationDAL;

		

		public Application TAdd(Application entity)
		{
			return _applicationDAL.Add(entity);
		}

		public void TDelete(Application application)
		{
			_applicationDAL.Delete(application);
		}

		public Application TGetByID(Guid id)
		{
			return _applicationDAL.GetByID(id);
		}

		public List<Application> TGetListAll()
		{
			return _applicationDAL.GetAll();
		}
		public List<Application> GetAccept()
		{
			return _applicationDAL.GetAll().Where(x=>x.ApplicationStatus == ApplicationStatus.Approved).ToList();
		}

		public List<Application> GetRefusal()
		{
			return _applicationDAL.GetAll().Where(x=>x.ApplicationStatus==ApplicationStatus.Rejected).ToList();
		}
		public List<Application> GetWaiting()
		{
			return _applicationDAL.GetAll().Where(x=>x.ApplicationStatus==ApplicationStatus.Pending).ToList();
		}

		public void TUpdate(Application entity)
		{
			_applicationDAL.Update(entity);
		}

		
	}
}
