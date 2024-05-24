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
	public class OfferService(IOfferDAL offerDAL,IPostService postService):IOfferService
	{
		private readonly IOfferDAL _offerDAL = offerDAL;
		private readonly IPostService _postService = postService;
		//private readonly IUserService _userService = userService;

		

		public Offer TAdd(Offer entity)
		{
			//var selectedPost = _postService.TGetByID(id);
			//var newOffer = new Offer
			//{
			//	Price = entity.Price,
			//	PostID = entity.PostID,
			//	UserID = entity.UserID,

			//};
			return _offerDAL.Add(entity);
		}

		public void TDelete(Offer entity)
		{
			_offerDAL.Delete(entity);
		}

		public Offer TGetByID(Guid id)
		{
			//return _offerDAL.GetAll().Where(offer => offer.UserID == id).ToList();
			return _offerDAL.GetByID(id);
		}
		public List<Offer> GetOffer(Guid id)
		{
			return _offerDAL.GetOffers(id);
		}

		public List<Offer> TGetListAll()
		{
			return _offerDAL.GetAll();
		}

		public void TUpdate(Offer entity)
		{
			 _offerDAL.Update(entity);
		}

        //public List<Offer> Update(Offer offer)
        //{
        //   return _offerDAL.Update(offer);
        //}
    }
}
