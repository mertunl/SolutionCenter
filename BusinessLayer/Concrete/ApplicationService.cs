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

        public List<Application> GetApprovedApplication()
        {
            return _applicationDAL.GetAll().Where(a => a.ApplicationStatus == ApplicationStatus.Approved).ToList();
        }

        public List<Application> GetPendingApplication()
        {
			return _applicationDAL.GetAll().Where(a=>a.ApplicationStatus == ApplicationStatus.Pending).ToList();
        }

        public List<Application> GetRejectedApplication()
        {
            return _applicationDAL.GetAll().Where(a => a.ApplicationStatus == ApplicationStatus.Rejected).ToList();
        }

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

		public void TUpdate(Application entity)
		{
			_applicationDAL.Update(entity);
		}

		
	}
}
