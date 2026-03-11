using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly RegisterService _registerService;

        public HomeController(LoginService loginService, DashboardService dashboardService, RegisterService registerService)
        {
            _loginService = loginService;
            _dashboardService = dashboardService;
            _registerService = registerService;
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
                return RedirectToAction("Dashboard","Dashboard", new { userId = person.UserId });
            }

            // Invalid User
            ViewBag.Error = "User not found !";
            return View();

        }

        // GET: Dashboard
        

        // GET: Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public IActionResult Register(PersonInfo model)
        {
            if (ModelState.IsValid)
            {
                var user = _registerService.RegisterUser(model);

                // Redirect to Login page after successful registration
                return RedirectToAction("Index");
            }

            return View(model);
        }

    }
}
