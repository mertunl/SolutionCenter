using DataAccessLayer.Abstract;
using DataAccessLayer.DatabaseContext;
using DataAccessLayer.Repositories;
using EntityLayer.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfPostDAL : GenericRepository<Post>, IPostDAL
	{
		private readonly Context _context;
		public EfPostDAL(Context context) : base(context)
		{
			_context = context;
		}

		//public Post StatusPost(Post post)
		//{
		//	return context.Posts
		//}

		//public void Task<Post>
		//{
		//	public async Task<List<Question>> GetAcceptQuestion()
		//	{
		//		return await _context.Questions
		//						.Where(q => q.Status == Status.Onaylandı).ToListAsync();
		//	}
		//}
	}
}
