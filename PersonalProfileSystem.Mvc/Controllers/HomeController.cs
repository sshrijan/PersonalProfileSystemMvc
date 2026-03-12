using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalProfileSystem.Mvc.Data;
using PersonalProfileSystem.Mvc.Models;
using PersonalProfileSystem.Mvc.Services;
using PersonalProfileSystem.Mvc.ViewModels;
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
        public async Task<IActionResult> Index(int userId)
        {
            var person = await _loginService.ValidateLogin(userId);

            if (person != null)
            {
                // Sucessful Login and redirect to dashboard
                return RedirectToAction("Dashboard","Dashboard", new { userId = person.UserId });
            }

            // Invalid User
            ViewBag.Error = "User not found !";
            return View();

        }


        // GET: Register
        [HttpGet]
        public IActionResult Register()
        {
            return View(new PersonInfo());
        }

        // POST: Register
        [HttpPost]
        public IActionResult Register(PersonInfo person, string Email, string Phone)
        {
            if (!ModelState.IsValid)
                return View(person);

            // Save Person
            var createdPerson = _registerService.RegisterUser(person);

            // Parse Phone safely
            long phoneNumber = 0;
            if (!string.IsNullOrEmpty(Phone))
            {
                long.TryParse(Phone, out phoneNumber);
            }

            // Save Contact
            var contact = new Contact
            {
                UserId = createdPerson.UserId,
                Email = Email,
                Phone = phoneNumber
            };

            _registerService.AddContact(contact);

            return RedirectToAction("Index");
        }

    }
}
