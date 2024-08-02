using BusinessLayer.Abstract;
using EntityLayer.Entites;
using EntityLayer.Enum;
using EntityLayer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utility.Constants;

namespace SolutionCenter.Areas.Admin.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IApplicationService _applicationService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserService _userService;
        public AdminController(IApplicationService applicationService,IUserService userService,UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _applicationService = applicationService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            var PendingApplicationCount = _applicationService.GetPendingApplication().Count();
            var ApprovedApplicationCount = _applicationService.GetApprovedApplication().Count();
            var RejectedApplicationCount = _applicationService.GetRejectedApplication().Count();
            ViewBag.PendingApplicationCount = PendingApplicationCount;
            ViewBag.ApprovedApplicationCount = ApprovedApplicationCount;
            ViewBag.RejectedApplicationCount = RejectedApplicationCount;
            return View();
        }

        public IActionResult GetPendingApplication()
        {
            var GetApplication = _applicationService.GetPendingApplication();
            ViewBag.PendingApplication = GetApplication;
            return View();
        }
        public IActionResult GetRejectedApplication()
        {
            var GetApplication = _applicationService.GetRejectedApplication();
            ViewBag.RejectedApplication = GetApplication;
            return View();
        }

        public IActionResult GetAllStatus()
        {
            return Ok(_applicationService.TGetListAll());
        }
        [HttpPost]        
        public IActionResult AcceptApplication(Guid id)
        {
            var getApplication = _applicationService.TGetByID(id);
            getApplication.ApplicationStatus = ApplicationStatus.Approved;
            _applicationService.TUpdate(getApplication);
            return RedirectToAction("GetPendingApplication", "Admin", new { area = "Admin" });

        }
        [HttpPost]
        public IActionResult WithDrawApplication(Guid id)
        {
            var getApplication = _applicationService.TGetByID(id);
            getApplication.ApplicationStatus = ApplicationStatus.Pending;
            _applicationService.TUpdate(getApplication);
            return RedirectToAction("GetRejectedApplication", "Admin", new { area = "Admin" });

        }
        [HttpPost]
        public IActionResult RejectApplication(Guid id, string reasonRejection)
        {
            var getApplication = _applicationService.TGetByID(id);
            getApplication.ReasonRejection = reasonRejection;
            getApplication.ApplicationStatus = ApplicationStatus.Rejected;
            _applicationService.TUpdate(getApplication);
            return RedirectToAction("GetPendingApplication", "Admin", new { area = "Admin" });

        }
        
        public async Task<IActionResult> UserManager(string role)
        {
            var users = await _userManager.Users.ToListAsync();
            var userViewModels = new List<UserViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (!roles.Contains(Roles.Admin) && (string.IsNullOrEmpty(role) || roles.Contains(role)))
                {
                    userViewModels.Add(new UserViewModel { Id = user.Id, Name = user.UserName, Roles = roles });
                }
            }
            ViewBag.User= userViewModels;
            return View(userViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeUserRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"ID'si {userId} olan kullanıcı bulunamadı.");
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);

            if (!removeResult.Succeeded)
            {
                return BadRequest("Mevcut roller kaldırılırken bir hata oluştu.");
            }

            var addResult = await _userManager.AddToRoleAsync(user, roleName);
            if (!addResult.Succeeded)
            {
                return BadRequest("Yeni rol eklenirken bir hata oluştu.");
            }

            return RedirectToAction("UserManager");
        }
        public async Task<IActionResult> UserManagerSearch(string searchQuery)
        {
            var users = await _userManager.Users
                .Where(u => u.UserName.Contains(searchQuery) || u.Email.Contains(searchQuery))
                .ToListAsync();

            // Kullanıcıları rollerine göre filtreleyin veya diğer işlemleri yapın
            // Sonuçları bir ViewModel veya ViewBag üzerinden View'a gönderin

            return View("UserManager", users); // UserManager view'ını kullanıcı listesi ile döndür
        }
        [HttpPost]
        public async Task<IActionResult> AcceptUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var currentRoles = await _userManager.GetRolesAsync(user);
            var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!await _roleManager.RoleExistsAsync(Roles.SuperUser))
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(Roles.SuperUser));
                if (!roleResult.Succeeded)
                {
                    return BadRequest("Yeni rol oluşturulurken bir hata oluştu.");
                }
            }
            var addResult = await _userManager.AddToRoleAsync(user, Roles.SuperUser);
            _applicationService.ApproveApplicationForUser(id);

            return RedirectToAction("UserManager", "Admin", new { area = "Admin" });

        }

        [HttpPost]
        public async Task<IActionResult> RejectUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var currentRoles = await _userManager.GetRolesAsync(user);
            if (currentRoles.Contains(Roles.SuperUser))
            {
                var removeResult = await _userManager.RemoveFromRoleAsync(user, Roles.SuperUser);
                if (!removeResult.Succeeded)
                {
                    return BadRequest("Rol kaldırılırken bir hata oluştu.");
                }
            }
            var addResult = await _userManager.AddToRoleAsync(user, Roles.User);
            if (!addResult.Succeeded)
            {
                return BadRequest("Rol eklenirken bir hata oluştu.");
            }

            return RedirectToAction("UserManager", "Admin", new { area = "Admin" });
        }
        public async Task<IActionResult> GetUsersInRole(string role)
        {
            var users = await _userManager.GetUsersInRoleAsync(role);
            return View(users);
        }

    }
}
