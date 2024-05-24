using DataAccessLayer.Abstract;
using DataAccessLayer.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
	public class GenericRepository<T> : IGenericDAL<T> where T : class
	{
		private readonly Context context;
        public GenericRepository(Context context)
        {
            this.context = context;
        }
        public T Add(T entity)
		{
			context.Set<T>().Add(entity);
			context.SaveChanges();
			return entity;
		}

		public void Delete(T entity)
		{
			context.Remove(entity);
			context.SaveChanges();
		}

		public List<T> GetAll()
		{
			return context.Set<T>().ToList();
		}

		public T GetByID(Guid id)
		{
			return context.Set<T>().Find(id);
		}
        

        public void Update(T entity)
		{
			context.Set<T>().Update(entity);
			context.SaveChanges();
		}
	}
}
