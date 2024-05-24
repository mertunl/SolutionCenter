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
    public class EfStatDAL : GenericRepository<Stat>, IStatDAL
    {
        private readonly Context context;
        public EfStatDAL(Context context): base(context) { 
            this.context = context;
        }
        public List<Stat> GetStat(string id)
        {
            var selected = context.Stats.Where(s=>s.AppUserID == id).ToList();
            return selected;

        }  
    }
}
