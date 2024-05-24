
using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IUserService:IGenericService<AppUser>
	{
		List<AppUser> GetUser(string id);
		AppUser GetUsers(string id);
		
	}
}
