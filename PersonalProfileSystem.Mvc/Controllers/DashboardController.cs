using Microsoft.AspNetCore.Mvc;
using PersonalProfileSystem.Mvc.Services;
using PersonalProfileSystem.Mvc.ViewModels;

namespace PersonalProfileSystem.Mvc.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IProfileService _service;
        private readonly DashboardService _dashboardService;
        public DashboardController(IProfileService service, DashboardService dashboardService)
        {
            _service = service;
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public async  Task<IActionResult> Dashboard(int userId)
        {
            var dashboardVM = await _dashboardService.GetDashboardData(userId);

            if (dashboardVM == null || dashboardVM.Person == null)
            {
                return RedirectToAction("Index");
            }

            dashboardVM.UserId = userId;

            return View(dashboardVM);
        }


        [HttpPost]
        public async Task<IActionResult> AddAddress(AddAddressViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var dashboardModel = await _dashboardService.GetDashboardData(model.UserId);
            return View("Dashboard", dashboardModel);

            }

            await _service.AddAddress(model);
            return RedirectToAction("Dashboard", new { userId = model.UserId });

        }

        [HttpPost]
        public async Task<IActionResult> AddSkill(AddSkillViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var dashboardModel = await _dashboardService.GetDashboardData(model.UserId);
                return View("Dashboard", dashboardModel);
            }


            await _service.AddSkill(model);

            return RedirectToAction("Dashboard", new { userId = model.UserId });
        }

        [HttpPost]
        public async Task<IActionResult> AddEducation(AddEducationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var dashboardModel = await _dashboardService.GetDashboardData(model.UserId);
                return View("Dashboard", dashboardModel);

            }

            await _service.AddEducation(model);
            return RedirectToAction("Dashboard", new { userId = model.UserId });

        }
    }
}
