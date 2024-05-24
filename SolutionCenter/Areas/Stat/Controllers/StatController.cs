using Azure;
using BusinessLayer.Abstract;
using DataAccessLayer.DatabaseContext;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;


namespace SolutionCenter.Areas.Stat.Controllers
{
    [Area("Stat")]
    public class StatController : Controller
    {
        private readonly IStatService statService;
        private readonly Context context;
        private readonly IUserService userService;
		private readonly UserManager<AppUser> userManager;

		public StatController(IStatService statService, Context context, UserManager<AppUser> userManager, IUserService userService)
        {
            this.statService = statService;
            this.context = context;
            this.userService = userService;
			this.userManager = userManager;
		}
        
        public IActionResult GetStat(/*string id*//*, JsonPatchDocument<EntityLayer.Entites.Stat> patchDocument*/)
        {
			//var result = context.Stats.Where(s => s.AppUserID == id).FirstOrDefault();
			//var stat = new EntityLayer.Entites.Stat
			//{
			//    StatID = result.StatID,
			//    PostOfNumber = result.PostOfNumber + 1,
			//    SentOfOfferNumber = result.SentOfOfferNumber,
			//    ReceivedOfOfferNumber = result.ReceivedOfOfferNumber,

			//};
			//patchDocument.ApplyTo(stat, ModelState);
			//result.PostOfNumber = stat.PostOfNumber;
			var user = userManager.GetUserId(User);
			var result = context.Posts.Count(p=>p.AppUserId== user);
            ViewBag.PostOfNumber = result;

            return View();
            //var stat = statService.TGetByID()
            //var user = userService.GetUsers(id);
            //var userid = user.Id;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
