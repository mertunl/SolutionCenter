using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DatabaseContext;
using EntityLayer.Entites;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{

	public class EfOfferDAL : GenericRepository<Offer>, IOfferDAL
	{
		private readonly Context context;
		public EfOfferDAL(Context context) : base(context)
		{
			this.context = context;
		}
		
		public List<Offer> GetOffers(Guid id)
		{
			
			var selected = context.Offers.Where(o=>o.PostID == id).Select(o=> new Offer
			{
				Price = o.Price,
				AppUserId = o.AppUserId,

			}).ToList();
			
			return selected;
		}
	}
}
