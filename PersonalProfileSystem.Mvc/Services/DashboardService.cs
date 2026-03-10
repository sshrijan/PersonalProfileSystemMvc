using PersonalProfileSystem.Mvc.Data;
using PersonalProfileSystem.Mvc.Models;
using PersonalProfileSystem.Mvc.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PersonalProfileSystem.Mvc.Services
{
    public class DashboardService
    {
        private readonly PersonalProfileSystemContext _context;

        public DashboardService(PersonalProfileSystemContext context)
        {
            _context = context;
        }

        public DashboardViewModel GetDashboardData(int userId)
        {
            var person = _context.PersonInfos.FirstOrDefault(p => p.UserId == userId && !p.IsDeleted);

            if (person == null) return null!;

            var contact = _context.Contacts.FirstOrDefault(c => c.UserId == userId && !c.IsDeleted);

            var educations = _context.UserEducations
                                     .Include(ue => ue.Education)
                                     .Where(ue => ue.UserId == userId && ue.IsActive)
                                     .ToList();

            var addresses = _context.UserAddresses
                                    .Include(ua => ua.Address)
                                    .Where(ua => ua.UserId == userId && ua.IsActive)
                                    .ToList();

            var skills = _context.UserSkills
                .Include(us => us.Skill)
                .Where(us => us.UserId == userId && us.IsActive)
                .ToList();
                                    

            return new DashboardViewModel
            {
                Person = person,
                Contact = contact,
                Educations = educations,
                Addresses = addresses,
                Skills = skills
            };
        }
    }
}