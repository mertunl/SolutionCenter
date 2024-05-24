using DataAccessLayer.Abstract;
using DataAccessLayer.DatabaseContext;
using DataAccessLayer.Repositories;
using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfApplicationDAL : GenericRepository<Application>, IApplicationDAL
	{
		private readonly Context context;
		public EfApplicationDAL(Context context) : base(context)
		{
			this.context = context;
		}

	}
}
