
using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IUserDAL:IGenericDAL<AppUser>
	{
        List<AppUser> GetUser(string id);
        AppUser GetByUser(string id);
    }
}
