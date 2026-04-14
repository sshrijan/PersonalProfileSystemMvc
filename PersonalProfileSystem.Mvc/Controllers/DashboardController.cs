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
        public async Task<IActionResult> AddAddress(AddressViewModel model)
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
        public async Task<IActionResult> AddSkill(SkillViewModel model)
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
        public async Task<IActionResult> AddEducation(EducationViewModel model)
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



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateContact(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Invalid contact data.";
                return RedirectToAction("Dashboard", new { userId = model.UserId });
            }

            var result = await _dashboardManagerService.UpdateContactAsync(model);

            if (result)
            {
                TempData["Success"] = "Contact updated successfully.";
            }
            else
            {
                TempData["Error"] = "Failed to update contact.";
            }

            return RedirectToAction("Dashboard", new { userId = model.UserId });
        }

        // UPDATE ADDRESS
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAddress(AddressViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Invalid address data.";
                return RedirectToAction("Dashboard", new { userId = model.UserId });
            }

            var result = await _dashboardManagerService.UpdateAddressAsync(model);

            if (result)
            {
                TempData["Success"] = "Address updated successfully.";
            }
            else
            {
                TempData["Error"] = "Failed to update address.";
            }

            return RedirectToAction("Dashboard", new { userId = model.UserId });
        }

        // UPDATE SKILL
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSkill(SkillViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Invalid skill data.";
                return RedirectToAction("Dashboard", new { userId = model.UserId });
            }

            var result = await _dashboardManagerService.UpdateSkillAsync(model);

            if (result)
            {
                TempData["Success"] = "Skill updated successfully.";
            }
            else
            {
                TempData["Error"] = "Failed to update skill.";
            }

            return RedirectToAction("Dashboard", new { userId = model.UserId });
        }

        // UPDATE EDUCATION
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEducation(EducationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Invalid education data.";
                return RedirectToAction("Dashboard", new { userId = model.UserId });
            }

            var result = await _dashboardManagerService.UpdateEducationAsync(model);

            if (result)
            {
                TempData["Success"] = "Education updated successfully.";
            }
            else
            {
                TempData["Error"] = "Failed to update education.";
            }

            return RedirectToAction("Dashboard", new { userId = model.UserId });
        }




    }
}
   