using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Enum;

namespace BusinessLayer.Concrete
{
	public class PostService(IPostDAL postDAL,ICategoryDAL categoryDAL,ICategoryService categoryService) : IPostService
	{
		private readonly IPostDAL _postDAL = postDAL;
		private readonly ICategoryDAL _categoryDAL = categoryDAL;
		private readonly ICategoryService _categoryService= categoryService;

		public Post Add(Post entity, List<int> categoryIds)
		{
			//var selectedCategory = _categoryService.TGetByID(categoryId);
			var selectedCategory = _categoryService.GetIds(categoryIds);
			if (selectedCategory == null)
			{
				// Eğer kategori bulunamazsa bir hata mesajı eklenebilir veya başka bir işlem yapılabilir.
				return null;
			}
			var newPost = new Post
			{
				postStatus = PostStatus.Waiting,
				Title = entity.Title,
				Content = entity.Content,
				Price = entity.Price,
				AppUserId = entity.AppUserId,
				Categories = selectedCategory,

			};
			//newPost.Categories.AddRange(entity.Categories);
			return _postDAL.Add(newPost);
		}

		public void SetExistingCategories(Post post,List<int> categoryId)
		{
            //post.Categories =_categoryService.TGetListAll();
            //var selectedCategory = _categoryService.TGetByID(categoryId);
            var selectedCategory = _categoryService.GetIds(categoryId);
            //if (selectedCategory != null)
            //{
            //	post.Categories.Add(selectedCategory);
            //}
        }


		public Post TAdd(Post entity)
		{
			
			var newPost = new Post
			{
				postStatus = PostStatus.Waiting,
				Title=entity.Title,
				Content=entity.Content,
				Price=entity.Price,
				AppUserId=entity.AppUserId,
				Categories=new List<Category> { },
			};
			return _postDAL.Add(newPost);
		}

		public void TDelete(Post entity)
		{
			throw new NotImplementedException();
		}

		public Post TGetByID(Guid id)
		{
			return _postDAL.GetByID(id);
		}

		public List<Post> TGetListAll()
		{
			return _postDAL.GetAll();
		}

		public void TUpdate(Post entity)
		{
			throw new NotImplementedException();
		}

	}
}
