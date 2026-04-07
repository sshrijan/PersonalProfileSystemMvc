using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalProfileSystem.Mvc.Services;
using PersonalProfileSystem.Mvc.ViewModels;

namespace PersonalProfileSystem.Mvc.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IProfileService _dashboardManagerService;
        private readonly DashboardService _dashboardService;
        public DashboardController(IProfileService  dashboardManagerService, DashboardService dashboardService)
        {
            _dashboardManagerService = dashboardManagerService;
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

            await _dashboardManagerService.AddAddress(model);
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


            await _dashboardManagerService.AddSkill(model);

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

            await _dashboardManagerService.AddEducation(model);
            return RedirectToAction("Dashboard", new { userId = model.UserId });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAddress(int userId, int addressId)
        {
            var (success, message) = await _dashboardManagerService.DeleteAddressAsync(userId, addressId);

            if (success)
            {
                TempData["Success"] = message;
            }
            else
            {
                TempData["Error"] = message;
            }

            return RedirectToAction("Dashboard", new { userId = userId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSkill(int userId, int skillId)
        {
            var (success, message) = await _dashboardManagerService.DeleteSkillAsync(userId, skillId);

            if (success)
            {
                TempData["Success"] = message;
            }
            else
            {
                TempData["Error"] = message;
            }

            return RedirectToAction("Dashboard", new { userId = userId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEducation(int userId, int educationId)
        {
            var (success, message) = await _dashboardManagerService.DeleteEducationAsync(userId, educationId);

            if (success)
            {
                TempData["Success"] = message;
            }
            else
            {
                TempData["Error"] = message;
            }

            return RedirectToAction("Dashboard", new { userId = userId });
        }






    }
}
   