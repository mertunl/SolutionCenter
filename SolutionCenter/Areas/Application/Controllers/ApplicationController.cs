using BusinessLayer.Abstract;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Blazor;

namespace SolutionCenter.Areas.Application.Controllers
{
    
    [Area("Application")]
    public class ApplicationController : Controller
    {
        private readonly IApplicationService applicationService;
        private readonly UserManager<AppUser> userManager;
        public ApplicationController(IApplicationService applicationService, UserManager<AppUser> userManager)
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
		public async Task<IActionResult> CreateApplication(EntityLayer.Entites.Application application)
		{
            if (!ModelState.IsValid)
            {
                // Model doğrulama hatalarını işleyin
                return View(application);
            }

            var user = await userManager.GetUserAsync(User);
            application.Name = user.Name;
            application.Surname = user.Surname;
            application.AppUserId = userManager.GetUserId(User);

            var existingApplication = applicationService.GetApplicationByUserId(application.AppUserId);
            if (existingApplication== null)
            {
                applicationService.TAdd(application);
            }
            else if(existingApplication != null)
            {
                ModelState.AddModelError("", "Başvuru zaten yapılmış.");
                return View(application);
            }
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
