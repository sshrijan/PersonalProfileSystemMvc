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

        public async Task<DashboardViewModel> GetDashboardData(int userId)
        {
            var person = await _context.PersonInfos
                .FirstOrDefaultAsync(p => p.UserId == userId && !p.IsDeleted);

            if (person == null) return null!;

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(c => c.UserId == userId && !c.IsDeleted);

            var educations = await _context.UserEducations
                .Include(ue => ue.Education)
                .Where(ue => ue.UserId == userId && ue.IsActive)
                .ToListAsync();

            var addresses = await _context.UserAddresses
                .Include(ua => ua.Address)
                .Where(ua => ua.UserId == userId && ua.IsActive)
                .ToListAsync();

            var skills = await _context.UserSkills
                .Include(us => us.Skill)
                .Where(us => us.UserId == userId && us.IsActive)
                .ToListAsync();

            return new DashboardViewModel
            {
                Person = person,
                Contact = contact,
                Educations = educations,
                Addresses = addresses,
                Skills = skills,
                UserId = userId
            };
        }
    }
}