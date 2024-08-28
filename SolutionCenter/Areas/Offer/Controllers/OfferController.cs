using BusinessLayer.Abstract;
using DataAccessLayer.DatabaseContext;
using EntityLayer.Entites;
using EntityLayer.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using static System.Net.Mime.MediaTypeNames;

namespace SolutionCenter.Areas.Offer.Controllers
{
    [Area("Offer")]
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;
        private readonly Context _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IPostService _postService; 
        public OfferController(IOfferService offerService,Context context, UserManager<AppUser> userManager, IPostService postService)
        {
            _offerService = offerService;
            _context = context;
            _userManager = userManager;
            _postService = postService;
        }
        [HttpPost]
        public IActionResult CreateOffer(EntityLayer.Entites.Offer offer)
        {
            var userId = _userManager.GetUserId(User);
            
            if (offer.Offeree == offer.AppUserId)
            {
                TempData["ErrorMessage"] = "Bu post sana ait olduğu için teklif yapamazsın";
                return RedirectToAction("GetPost", "Post", new { area = "Post", id = offer.PostID });
                
            }
            else
            {
                _offerService.TAdd(offer);
                var post = _postService.TGetByID(offer.PostID);
                post.postStatus = PostStatus.Offered;
                _postService.TUpdate(post);
            }
            return RedirectToAction("GetPost", "Post", new { area = "Post", id = offer.PostID });

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
            var post = _postService.TGetByID(getOffer.PostID);
            post.postStatus = PostStatus.Approved;
            _postService.TUpdate(post);

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
