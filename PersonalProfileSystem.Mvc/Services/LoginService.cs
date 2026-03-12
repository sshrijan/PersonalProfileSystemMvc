using PersonalProfileSystem.Mvc.Data;
using PersonalProfileSystem.Mvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PersonalProfileSystem.Mvc.Services
{
    public class LoginService
    {
        private readonly PersonalProfileSystemContext _context;

        public LoginService(PersonalProfileSystemContext context)
        {
            _context = context;
        }


        public async Task<PersonInfo?> ValidateLogin(int userId)
        {
            return await _context.PersonInfos
                .FirstOrDefaultAsync(p => p.UserId == userId && !p.IsDeleted);
        }
    }
}