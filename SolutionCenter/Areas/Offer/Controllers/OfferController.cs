using BusinessLayer.Abstract;
using DataAccessLayer.DatabaseContext;
using EntityLayer.Entites;
using EntityLayer.Enum;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace SolutionCenter.Areas.Offer.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;
        private readonly Context _context;
        public OfferController(IOfferService offerService,Context context)
        {
            _offerService = offerService;
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateOffer(EntityLayer.Entites.Offer offer)
        {
            return Created("Teklif gönderildi", _offerService.TAdd(offer));
        } 

        public IActionResult GetOffer(Guid id)
        {
            return Ok(_offerService.GetOffer(id));
        }

        [HttpPost]
        public IActionResult DeleteOffer(Guid id)
        {
            var getOffer = _offerService.TGetByID(id);
            getOffer.OfferStatus = OfferStatus.Rejected;
            _offerService.TUpdate(getOffer);
            return RedirectToAction("GetOffer","User", new {area="User"});
        }

        [HttpPost]
        public IActionResult AcceptOffer(Guid id/*,EntityLayer.Entites.Offer offer */)
        {
            var getOffer = _offerService.TGetByID(id);

            getOffer.OfferStatus = OfferStatus.Approved;
            _offerService.TUpdate(getOffer);

            var getAllOffer = _offerService.TGetListAll();
            foreach ( var offer in getAllOffer )
            {
                if (offer.OfferID != id && offer.PostID==getOffer.PostID)
                {
                    
                    offer.OfferStatus = OfferStatus.Rejected;
                    _offerService.TUpdate(offer);
                }
               
            }

            //var allOffers = _offerService.TGetListAll();
            //var offersToDelete = allOffers.Where(o=>o.OfferID != id).ToList();

            //foreach(var offer in offersToDelete)
            //{
            //    _offerService.TDelete(offer);
            //}

            return RedirectToAction("GetOffer","User", new {area="User"});
        }
    }
}
