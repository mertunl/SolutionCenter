
using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IPostService:IGenericService<Post>
	{
		void SetExistingCategories(Post post, List<int> categoryIds);
		Post Add(Post entity, List<int> categoryId);
	}
}
