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


        public IActionResult Dashboard(int userId)
        {
            var dashboardVM = _dashboardService.GetDashboardData(userId);

            if (dashboardVM == null || dashboardVM.Person == null)
            {
                return RedirectToAction("Index");
            }

            dashboardVM.UserId = userId;

            return View(dashboardVM);
        }

        public IActionResult AddSkill(int userId)
        {
            var model = new AddSkillViewModel
            {
                UserId = userId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddSkill(AddSkillViewModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Dashboard", new { userId = model.UserId });

            await _service.AddSkill(model);

            return RedirectToAction("Dashboard", new { userId = model.UserId });
        }
    }
}
