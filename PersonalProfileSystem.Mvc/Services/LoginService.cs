using PersonalProfileSystem.Mvc.Data;
using PersonalProfileSystem.Mvc.Models;
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

        
        public PersonInfo? ValidateLogin(int userId)
        {
            return _context.PersonInfos
                           .FirstOrDefault(p => p.UserId == userId && !p.IsDeleted);
        }
    }
}