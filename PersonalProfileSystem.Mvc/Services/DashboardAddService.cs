using PersonalProfileSystem.Mvc.Data;
using PersonalProfileSystem.Mvc.Models;
using PersonalProfileSystem.Mvc.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;

namespace PersonalProfileSystem.Mvc.Services
{
    public class DashboardAddService : IProfileService
    {
        private readonly PersonalProfileSystemContext _context;

        public DashboardAddService(PersonalProfileSystemContext context)
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
            try
            {
                // Check if context is null
                if (_context == null)
                    throw new Exception("DbContext is null");

                // Check model
                if (model == null)
                    throw new Exception("Model is null");

                // Validate
                if (model.UserId == 0)
                    throw new ArgumentException("UserId cannot be 0");

                // Check if address exists
                var existingAddress = await _context.Addresses
                    .FirstOrDefaultAsync(a =>
                        a.Tole == model.Tole &&
                        a.Ward == model.Ward);

                if (existingAddress == null)
                {
                    // Add new address
                    var newAddress = new Address
                    {
                        Tole = model.Tole,
                        Ward = model.Ward,
                        DistrictCity = model.DistrictCity,
                        ProvinceState = model.ProvinceState,
                        Country = model.Country
                    };

                    _context.Addresses.Add(newAddress);
                    var saveResult = await _context.SaveChangesAsync();

                    if (saveResult > 0)
                    {
                        // Add to UserAddresses
                        var userAddress = new UserAddress
                        {
                            UserId = model.UserId,
                            AddressId = newAddress.AddressId,
                            IsActive = true
                        };

                        _context.UserAddresses.Add(userAddress);
                        await _context.SaveChangesAsync();
                    }
                }
                else
                {
                    // Check if user already has this address
                    var existingUserAddress = await _context.UserAddresses
                        .FirstOrDefaultAsync(ua =>
                            ua.UserId == model.UserId &&
                            ua.AddressId == existingAddress.AddressId);

                    if (existingUserAddress == null)
                    {
                        var userAddress = new UserAddress
                        {
                            UserId = model.UserId,
                            AddressId = existingAddress.AddressId,
                            IsActive = true
                        };

                        _context.UserAddresses.Add(userAddress);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw; // This will show the error in your UI
            }
        }

        public async Task AddSkill(AddSkillViewModel model)
        {
            // Make sure the userId is valid
            if (model.UserId == 0) throw new ArgumentException("UserId cannot be 0");

            // Check if skill already exists
            var skill = await _context.Skills
                .FirstOrDefaultAsync(s => 
                s.SkillName == model.SkillName);

            if (skill == null)
            {
                skill = new Skill { SkillName = model.SkillName };
                _context.Skills.Add(skill);
                await _context.SaveChangesAsync();
            }

            // Check if user already linked to this address
            var existingUserSkill = await _context.UserSkills
                .FirstOrDefaultAsync(us => 
                us.UserId == model.UserId && 
                us.SkillId == skill.SkillId);

            if (existingUserSkill != null)
                return; // skip adding duplicate

            // Add to UserSkills
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
            // Make sure the userId is valid
            if (model.UserId == 0) throw new ArgumentException("UserId cannot be 0");

            // Check if Education already exists
            var education = await _context.Educations.FirstOrDefaultAsync(e => 
            e.InstitutionName == model.InstitutionName &&
            e.Degree == model.Degree &&
            e.Field == model.Field &&
            e.Location == model.Location);

            // If not, create new Education
            if (education == null)
            {
                education = new Education
                {
                    Degree = model.Degree,
                    Field = model.Field,
                    InstitutionName = model.InstitutionName,
                    Location = model.Location
                };

                _context.Educations.Add(education);
               await _context.SaveChangesAsync();
                
            }

            // Check if user already linked to this Education
            var existingUserEducation = await _context.UserEducations.FirstOrDefaultAsync(ue =>
            ue.UserId == model.UserId &&
            ue.EducationId == education.EducationId);

            if (existingUserEducation != null)
                return; // skip adding duplicate


            // Add to userEducations
            var userEducation = new UserEducation
            {
                UserId = model.UserId,
                EducationId = education.EducationId,
                CurrentlyStudying = model.CurrentlyStudying,
                Grade = model.Grade,
                PassedYear = model.PassedYear,
                IsActive = true
            };
            _context.UserEducations.Add(userEducation);
            await _context.SaveChangesAsync();

        }
    }
}
