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
    public class EfAdminDAL : GenericRepository<AppUser>, IAdminDAL
    {
        private readonly Context context;
        public EfAdminDAL(Context context) : base(context)
        {
            this.context = context;
        }

    }
}
