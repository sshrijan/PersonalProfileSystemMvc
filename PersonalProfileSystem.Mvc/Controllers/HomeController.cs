using Microsoft.AspNetCore.Mvc;
using PersonalProfileSystem.Mvc.Data;
using PersonalProfileSystem.Mvc.Models;
using PersonalProfileSystem.Mvc.Services;
using System.Linq;

namespace PersonalProfileSystem.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly LoginService _loginService;
        private readonly DashboardService _dashboardService;

        public HomeController(LoginService loginService, DashboardService dashboardService)
        {
            _loginService = loginService;
            _dashboardService = dashboardService;
        }

        // GET: Home or Login Page
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: Login validation
        [HttpPost]
        public IActionResult Index(int userId)
        {
            var person = _loginService.ValidateLogin(userId);

            if (person != null)
            {
                // Sucessful Login and redirect to dashboard
                return RedirectToAction("Dashboard", new { userId = person.UserId });
            }

            // Invalid User
            ViewBag.Error = "User not found !";
            return View();

        }

        // GET: Dashboard
        public IActionResult Dashboard(int userId)
        {
            var dashboardData = _dashboardService.GetDashboardData(userId);

            if (dashboardData == null)
            {
                return RedirectToAction("Index");
            }
            return View(dashboardData);
        }

    }
}
