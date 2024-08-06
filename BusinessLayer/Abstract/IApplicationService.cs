
using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{

	public interface IApplicationService:IGenericService<Application>
	{
		List<Application> GetPendingApplication();
        List<Application> GetApprovedApplication();
        List<Application> GetRejectedApplication();
        Application GetApplicationByUserId(string id);
        void ApproveApplicationForUser(string id);
    }
}
