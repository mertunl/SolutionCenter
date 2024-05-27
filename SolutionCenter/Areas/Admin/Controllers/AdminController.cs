﻿using BusinessLayer.Abstract;
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

        public IActionResult GetAllStatus()
        {
            return Ok(_applicationService.TGetListAll());
        }
        

       
    }
}
