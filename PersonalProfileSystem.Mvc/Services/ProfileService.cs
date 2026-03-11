using PersonalProfileSystem.Mvc.Data;
using PersonalProfileSystem.Mvc.Models;
using PersonalProfileSystem.Mvc.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PersonalProfileSystem.Mvc.Services
{
    public class ProfileService : IProfileService
    {
        private readonly PersonalProfileSystemContext _context;

        public ProfileService(PersonalProfileSystemContext context)
        {
            _context = context;
        }

        public async Task AddContact(AddContactViewModel model)
        {
            var contact = new Contact
            {
                UserId = model.UserId,
                Email = model.Email,
                Phone = model.Phone
            };

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task AddAddress(AddAddressViewModel model)
        {
            var address = new Address
            {
                Tole = model.Tole,
                Ward = model.Ward,
                DistrictCity = model.DistrictCity,
                ProvinceState = model.ProvinceState,
                Country = model.Country
            };

            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
        }

        public async Task AddSkill(AddSkillViewModel model)
        {
            // Make sure the userId is valid
            if (model.UserId == 0) throw new ArgumentException("UserId cannot be 0");

            // 1️⃣ Check if skill already exists
            var skill = await _context.Skills
                .FirstOrDefaultAsync(s => s.SkillName == model.SkillName);

            if (skill == null)
            {
                skill = new Skill { SkillName = model.SkillName };
                _context.Skills.Add(skill);
                await _context.SaveChangesAsync(); // generate SkillId
            }

            // 2️⃣ Make sure this user doesn't already have this skill
            var existingUserSkill = await _context.UserSkills
                .FirstOrDefaultAsync(us => us.UserId == model.UserId && us.SkillId == skill.SkillId);

            if (existingUserSkill != null)
                return; // skip adding duplicate

            // 3️⃣ Add to UserSkills
            var userSkill = new UserSkill
            {
                UserId = model.UserId,
                SkillId = skill.SkillId,
                SkillLevel = model.SkillLevel,
                YearsOfExperience = model.YearsOfExperience,
                IsActive = true
            };

            _context.UserSkills.Add(userSkill);
            await _context.SaveChangesAsync();
        }

        public async Task AddEducation(AddEducationViewModel model)
        {
            var education = new Education
            {
                Degree = model.Degree,
                Field = model.Field,
                InstitutionName = model.InstitutionName,
                Location = model.Location
            };

            _context.Educations.Add(education);
            await _context.SaveChangesAsync();
        }
    }
}
