using PersonalProfileSystem.Mvc.Data;
using PersonalProfileSystem.Mvc.Models;

namespace PersonalProfileSystem.Mvc.Services
{
    public class RegisterService
    {
        private readonly PersonalProfileSystemContext _context;

        public RegisterService(PersonalProfileSystemContext context)
        {
            _context = context;
        }

        // Validate login (existing)
        public PersonInfo? ValidateLogin(int userId)
        {
            return _context.PersonInfos
                           .FirstOrDefault(p => p.UserId == userId && !p.IsDeleted);
        }

        // Register new user
        public PersonInfo RegisterUser(PersonInfo model)
        {
            model.CreatedDate = DateTime.Now;
            model.IsDeleted = false;

            _context.PersonInfos.Add(model);
            _context.SaveChanges();

            return model;
        }
    }
}