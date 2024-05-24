using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IGenericDAL<T> where T : class
	{
		T Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		List<T> GetAll();
		T GetByID(Guid id);
	}
}
