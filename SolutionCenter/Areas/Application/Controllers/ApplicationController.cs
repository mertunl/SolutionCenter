using BusinessLayer.Abstract;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SolutionCenter.Areas.Application.Controllers
{
    [Area("Application")]
    public class ApplicationController : Controller
    {
        private readonly IApplicationService applicationService;
        private readonly UserManager<AppUser> userManager;
        public ApplicationController(IApplicationService applicationService, UserManager<EntityLayer.Entites.AppUser> userManager)
        {
            this.applicationService = applicationService;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateApplication()
        {
            return View();
        }

        [HttpPost]
		public IActionResult CreateApplication(EntityLayer.Entites.Application application)
		{
            applicationService.TAdd(application);
			return RedirectToAction("CreateApplication");
		}

        public IActionResult GetApplication()
        {
            var user = userManager.GetUserId(User);
            var getApplication = applicationService.TGetListAll().Where(a => a.AppUserId == user);
            ViewBag.Application = getApplication;
            return View();
        }

	}
}
