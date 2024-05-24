
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
		List<Application> GetAccept();
		List<Application> GetRefusal();
		List<Application> GetWaiting();
	}
}
