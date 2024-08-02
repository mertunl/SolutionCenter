using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SolutionCenter.Models;
using System.Diagnostics;
using Utility.Constants;

namespace SolutionCenter.Controllers
{

    
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole(Roles.Admin))
                {
                    return RedirectToAction("Index","Admin",new {area=Roles.Admin});
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}