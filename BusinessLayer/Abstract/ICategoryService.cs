using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICategoryService:IGenericService<Category>
	{
		List<Category> GetIds(List<int> ids);
	}
}
