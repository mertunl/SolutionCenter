using BusinessLayer.Abstract;
using EntityLayer.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utility.Constants;

namespace SolutionCenter.Areas.Admin.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IApplicationService _applicationService;
        public AdminController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllStatus()
        {
            return Ok(_applicationService.TGetListAll());
        }
        [HttpPatch]
        public IActionResult UpdateApprovalStatus(Guid id)
        {
            var application = _applicationService.TGetByID(id);
            application.ApplicationStatus = ApplicationStatus.Approved;
            _applicationService.TUpdate(application);
            return Ok(application);
        }
        [HttpPatch]
        public IActionResult UpdateRefusalStatus(Guid id)
        {
            var application = _applicationService.TGetByID(id);
            application.ApplicationStatus = ApplicationStatus.Denied;
            _applicationService.TUpdate(application);
            return Ok(application);
        }
        public IActionResult GetAcceptStatus()
        {
            var acceptApp = _applicationService.GetAccept();
            return Ok(acceptApp);
        }
        public IActionResult GetRefusalStatus()
        {
            var refusalApp = _applicationService.GetRefusal();
            return Ok(refusalApp);
        }
        public IActionResult GetWaitingStatus()
        {
            var waitingApp = _applicationService.GetWaiting();
            return Ok(waitingApp);
        }
    }
}
