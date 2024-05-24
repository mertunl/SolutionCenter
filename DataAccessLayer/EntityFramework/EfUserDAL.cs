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
	public class EfUserDAL : GenericRepository<AppUser>, IUserDAL
	{
		private readonly Context context;
		public EfUserDAL(Context context) : base(context)
		{
			this.context = context;
		}

        public AppUser GetByUser(string id)
        {
            var selected = context.Set<AppUser>().Find(id);
            return selected;
        }

        public List<AppUser> GetUser(string id)
        {

            var selected = context.AppUsers
                .Where(o => o.Id == id)
                .Select(o => new AppUser
                {

                    Name = o.Name,
                    Surname = o.Surname,

                }).ToList();

            return selected;
            //return context.Set<AppUser>().Find(id);
            //var selected = context.AppUsers
            //    .Where(x => x.Id == id).ToList();
            //return selected;

        }
    }
}
