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
	public class EfCategoryDAL : GenericRepository<Category>,ICategoryDAL
	{
		private readonly Context _context;

        public EfCategoryDAL(Context context) : base(context)
        {
            _context = context;
        }

		public  List<Category> GetIds(List<int> ids)
		{
			var selected= _context.Categories.Where(c => ids.Contains(c.CategoryID)).ToList();
			return selected;
		}
        
    }
}
