using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class CategoryService(ICategoryDAL categoryDAL): ICategoryService
	{
		private readonly ICategoryDAL _categoryDAL = categoryDAL;

		public List<Category> GetIds(List<int> ids)
		{
			return _categoryDAL.GetIds(ids);	
		}

		public Category TAdd(Category entity)
		{
			throw new NotImplementedException();
		}

		public void TDelete(Category entity)
		{
			throw new NotImplementedException();
		}

        public Category TGetByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Category> TGetListAll()
		{
			return _categoryDAL.GetAll();
		}

		public void TUpdate(Category entity)
		{
			throw new NotImplementedException();
		}
	}
}
