using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IGenericService<T> where T : class
	{
		T TAdd(T entity);

		void TUpdate(T entity);

		void TDelete(T entity);

		List<T> TGetListAll();

		T TGetByID(Guid id);
	}
}
